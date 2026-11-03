using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciadorMenusGameplay : MonoBehaviour
{
    private enum EstadoTela
    {
        Jogando,
        Pausado,
        Vitoria
    }

    [Header("Painéis da Interface")]
    [SerializeField] private GameObject painelPausa;
    [SerializeField] private GameObject painelVitoria;

    [Header("Primeiros Botões Selecionados")]
    [SerializeField] private Button botaoContinuar;
    [SerializeField] private Button botaoProximoNivel;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference acaoPausar;
    [SerializeField] private InputActionReference acaoCancelar;

    [Header("Scripts Suspensos Durante os Menus")]
    [SerializeField] private MonoBehaviour[] scriptsGameplay = new MonoBehaviour[0];

    [Header("Nomes das Cenas")]
    [SerializeField] private string nomeCenaMenu = "MenuPrincipal";
    [SerializeField] private string nomeCenaProximoNivel;

    private EstadoTela estadoAtual = EstadoTela.Jogando;
    private float escalaTempoAntesDoMenu = 1f;

    /*
     * Inicia a fase com as telas de pausa e vitória ocultas.
     * Não desativa a UI nem o EventSystem.
     */
    private void Start()
    {
        if (painelPausa != null)
            painelPausa.SetActive(false);

        if (painelVitoria != null)
            painelVitoria.SetActive(false);
    }

    /*
     * Habilita o comando de pausa e acompanha o botão B (Cancelar).
     * O Input System UI Input Module é responsável por habilitar
     * a Action UI/Cancel; por isso não a habilitamos aqui.
     */
    private void OnEnable()
    {
        if (acaoPausar != null && acaoPausar.action != null)
        {
            acaoPausar.action.performed += AoPressionarPausa;
            acaoPausar.action.Enable();
        }

        if (acaoCancelar != null && acaoCancelar.action != null)
            acaoCancelar.action.performed += AoPressionarCancelar;
    }

    /*
     * Remove os eventos registrados, evitando callbacks duplicados.
     * Desabilita somente a Action Pausar, gerenciada por este script.
     */
    private void OnDisable()
    {
        if (acaoPausar != null && acaoPausar.action != null)
        {
            acaoPausar.action.performed -= AoPressionarPausa;
            acaoPausar.action.Disable();
        }

        if (acaoCancelar != null && acaoCancelar.action != null)
            acaoCancelar.action.performed -= AoPressionarCancelar;
    }

    /*
     * Abre ou fecha a pausa pelo Esc ou botão Menu do Xbox.
     * Durante a tela de vitória, não permite reabrir a pausa.
     */
    private void AoPressionarPausa(InputAction.CallbackContext contexto)
    {
        if (estadoAtual == EstadoTela.Jogando)
            AbrirPausa();
        else if (estadoAtual == EstadoTela.Pausado)
            Continuar();
    }

    /*
     * Retoma o jogo ao apertar B no controle enquanto
     * a tela de pausa estiver aberta.
     */
    private void AoPressionarCancelar(InputAction.CallbackContext contexto)
    {
        if (estadoAtual == EstadoTela.Pausado)
            Continuar();
    }

    /*
     * Abre o painel de pausa, suspende scripts do jogador,
     * congela o tempo do gameplay e seleciona Continuar.
     */
    public void AbrirPausa()
    {
        if (estadoAtual != EstadoTela.Jogando)
            return;

        estadoAtual = EstadoTela.Pausado;
        escalaTempoAntesDoMenu = Time.timeScale;

        if (painelPausa != null)
            painelPausa.SetActive(true);

        Time.timeScale = 0f;
        SelecionarBotao(botaoContinuar);
    }

    /*
     * Fecha a pausa, restaura o tempo e reativa apenas
     * os scripts que estavam habilitados anteriormente.
     */
    public void Continuar()
    {
        if (estadoAtual != EstadoTela.Pausado)
            return;

        if (painelPausa != null)
            painelPausa.SetActive(false);

        SelecionarBotao(null);
        Time.timeScale = escalaTempoAntesDoMenu;
        estadoAtual = EstadoTela.Jogando;
    }

    /*
     * Exibe o menu de vitória. Deve ser chamado pelo sistema
     * de conclusão da fase que seu jogo já possui.
     */
    public void MostrarVitoria()
    {
        if (estadoAtual == EstadoTela.Vitoria)
            return;

        if (estadoAtual == EstadoTela.Jogando)
        {
            escalaTempoAntesDoMenu = Time.timeScale;
        }

        estadoAtual = EstadoTela.Vitoria;

        if (painelPausa != null)
            painelPausa.SetActive(false);

        if (painelVitoria != null)
            painelVitoria.SetActive(true);

        Time.timeScale = 0f;
        SelecionarBotao(botaoProximoNivel);
    }

    /*
     * Carrega a próxima fase definida no Inspector.
     * A cena deve existir na Scene List do Build Profile ativo.
     */
    public void ProximoNivel()
    {
        CarregarCena(nomeCenaProximoNivel);
    }

    /*
     * Reinicia a fase atualmente carregada.
     */
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*
     * Retorna ao menu principal indicado no Inspector.
     */
    public void SairParaMenu()
    {
        CarregarCena(nomeCenaMenu);
    }

    /*
     * Valida o nome e carrega uma cena, restaurando antes
     * o tempo para que a próxima cena não comece congelada.
     */
    private void CarregarCena(string nomeCena)
    {
        if (string.IsNullOrWhiteSpace(nomeCena))
        {
            Debug.LogWarning("GerenciadorMenusGameplay: nome da cena não configurado.", this);
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(nomeCena))
        {
            Debug.LogError("GerenciadorMenusGameplay: cena não incluída no Build Profile: " + nomeCena, this);
            return;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeCena);
    }

    /*
     * Seleciona o botão inicial para que a navegação com
     * D-Pad ou analógico funcione imediatamente.
     */
    private void SelecionarBotao(Button botao)
    {
        if (EventSystem.current == null)
            return;

        EventSystem.current.SetSelectedGameObject(null);

        if (botao != null && botao.gameObject.activeInHierarchy && botao.IsInteractable())
            EventSystem.current.SetSelectedGameObject(botao.gameObject);
    }
}
