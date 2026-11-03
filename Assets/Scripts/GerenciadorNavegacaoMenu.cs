using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Gerencia somente a exibicao dos paineis e a selecao dos elementos da UI.
/// O carregamento dos niveis, o encerramento do jogo e o controle de volume
/// permanecem nos scripts que ja existem no projeto.
/// </summary>
public class GerenciadorNavegacaoMenu : MonoBehaviour
{
    private enum TipoPainel
    {
        Menu,
        Niveis,
        Opcoes,
        Sobre,
        Tutorial
    }

    [Header("Paineis do menu")]
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelNiveis;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelSobre;
    [SerializeField] private GameObject painelTutorial;

    [Header("Primeiro elemento selecionado em cada painel")]
    [SerializeField] private Selectable primeiroBotaoMenu;
    [SerializeField] private Selectable primeiroBotaoNiveis;
    [SerializeField] private Selectable primeiroElementoOpcoes;
    [SerializeField] private Selectable primeiroBotaoSobre;
    [SerializeField] private Selectable primeiroBotaoTutorial;

    [Header("Input System")]
    [SerializeField] private InputActionReference acaoVoltar;

    private TipoPainel painelAtual = TipoPainel.Menu;

    /*
     * Garante que a Action Cancel esteja habilitada quando o menu entra em cena.
     * Nao desabilitamos a Action ao sair porque ela pode ser compartilhada
     * com o Input System UI Input Module do EventSystem.
     */
    private void OnEnable()
    {
        if (acaoVoltar != null && acaoVoltar.action != null &&
            !acaoVoltar.action.enabled)
        {
            acaoVoltar.action.Enable();
        }
    }

    /*
     * Verifica se os paineis foram associados e abre o Menu Principal.
     */
    private void Start()
    {
        if (painelMenu == null || painelNiveis == null ||
            painelOpcoes == null || painelSobre == null ||
            painelTutorial == null)
        {
            Debug.LogError(
                "GerenciadorNavegacaoMenu: associe todos os paineis no Inspector.",
                this
            );
            enabled = false;
            return;
        }

        if (acaoVoltar == null || acaoVoltar.action == null)
        {
            Debug.LogWarning(
                "GerenciadorNavegacaoMenu: associe UI/Cancel no campo Acao Voltar.",
                this
            );
        }

        AbrirMenu();
    }

    /*
     * Verifica o comando Cancel (Xbox B ou Escape) e volta para
     * o painel anterior. No Menu principal, Cancel nao faz nada.
     */
    private void Update()
    {
        if (acaoVoltar != null && acaoVoltar.action != null &&
            acaoVoltar.action.WasPressedThisFrame())
        {
            Voltar();
        }
    }

    /*
     * Ativa somente o painel solicitado, oculta os demais
     * e seleciona o primeiro elemento para uso com controle.
     */
    private void ExibirPainel(TipoPainel destino, Selectable primeiroElemento)
    {
        painelAtual = destino;

        painelMenu.SetActive(destino == TipoPainel.Menu);
        painelNiveis.SetActive(destino == TipoPainel.Niveis);
        painelOpcoes.SetActive(destino == TipoPainel.Opcoes);
        painelSobre.SetActive(destino == TipoPainel.Sobre);
        painelTutorial.SetActive(destino == TipoPainel.Tutorial);

        if (EventSystem.current == null)
        {
            Debug.LogWarning(
                "GerenciadorNavegacaoMenu: nao ha EventSystem ativo na cena.",
                this
            );
            return;
        }

        // Remove a selecao de um elemento que ficou oculto.
        EventSystem.current.SetSelectedGameObject(null);

        if (primeiroElemento != null && primeiroElemento.IsActive() &&
            primeiroElemento.IsInteractable())
        {
            EventSystem.current.SetSelectedGameObject(primeiroElemento.gameObject);
        }
    }

    /*
     * Abre o painel principal: Play, Opcoes, Sobre e Sair.
     */
    public void AbrirMenu()
    {
        ExibirPainel(TipoPainel.Menu, primeiroBotaoMenu);
    }

    /*
     * Abre o painel com os nove niveis e os botoes Tutorial e Voltar.
     */
    public void AbrirNiveis()
    {
        ExibirPainel(TipoPainel.Niveis, primeiroBotaoNiveis);
    }

    /*
     * Abre o painel de volume. O primeiro elemento pode ser
     * o Slider de musica, que aceita esquerda/direita do controle.
     */
    public void AbrirOpcoes()
    {
        ExibirPainel(TipoPainel.Opcoes, primeiroElementoOpcoes);
    }

    /*
     * Abre o painel de creditos e seleciona o botao Voltar.
     */
    public void AbrirSobre()
    {
        ExibirPainel(TipoPainel.Sobre, primeiroBotaoSobre);
    }

    /*
     * Abre o tutorial a partir do painel de niveis.
     */
    public void AbrirTutorial()
    {
        ExibirPainel(TipoPainel.Tutorial, primeiroBotaoTutorial);
    }

    /*
     * Volta ao painel adequado com o botao B, Escape
     * ou o OnClick de um botao Voltar.
     */
    public void Voltar()
    {
        switch (painelAtual)
        {
            case TipoPainel.Niveis:
            case TipoPainel.Opcoes:
            case TipoPainel.Sobre:
                AbrirMenu();
                break;

            case TipoPainel.Tutorial:
                AbrirNiveis();
                break;

            case TipoPainel.Menu:
            default:
                // Nada a fazer: o usuario ja esta no menu principal.
                break;
        }
    }
}
