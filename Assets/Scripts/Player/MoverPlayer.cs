
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverPlayer : MonoBehaviour
{
    // Variáveis para configurar a câmera
    private Transform cameraPlayer;
    private float valorDeGiroSuave = 0.1f;
    private float velocidadeDeGiroSuave;

    [Header("Config Movimento")]
    [SerializeField] private float velocidadeCaminhada;
    [SerializeField] private float velocidadeCorrida;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float forcaQueda;

    [Header("Config Animação")]
    [SerializeField] private SuporteAnimacaoPlayer animacaoPlayer;

    [Header("Input Actions - Jogador")]
    [SerializeField] private InputActionReference acaoMover;
    [SerializeField] private InputActionReference acaoPular;
    [SerializeField] private InputActionReference acaoCorrer;

    private CharacterController playerController;
    private float velocidadeVertical = 0f;
    private bool habilitarMovimentacao;

    /*
     * Habilita as ações do jogador quando
     * este componente é ativado.
     */
    private void OnEnable()
    {
        if (acaoMover != null && acaoMover.action != null)
            acaoMover.action.Enable();

        if (acaoPular != null && acaoPular.action != null)
            acaoPular.action.Enable();

        if (acaoCorrer != null && acaoCorrer.action != null)
            acaoCorrer.action.Enable();
    }

    /*
     * Desabilita as ações quando
     * este componente é desativado.
     */
    private void OnDisable()
    {
        if (acaoMover != null && acaoMover.action != null)
            acaoMover.action.Disable();

        if (acaoPular != null && acaoPular.action != null)
            acaoPular.action.Disable();

        if (acaoCorrer != null && acaoCorrer.action != null)
            acaoCorrer.action.Disable();
    }

    /*
     * Configura o controlador, a câmera e
     * valida as ações associadas no Inspector.
     */
    private void Start()
    {
        playerController = GetComponent<CharacterController>();

        if (acaoMover == null || acaoMover.action == null ||
            acaoPular == null || acaoPular.action == null ||
            acaoCorrer == null || acaoCorrer.action == null)
        {
            Debug.LogError(
                "MoverPlayer: associe as ações Mover, Pular e Correr no Inspector.",
                this
            );

            enabled = false;
            return;
        }

        cameraPlayer = Camera.main.transform;
        habilitarMovimentacao = true;
    }

    /*
     * Atualiza o movimento enquanto
     * o jogador estiver habilitado.
     */
    private void Update()
    {
        if (CanvasGameMng.Instance.FimDeJogo == true ||
            habilitarMovimentacao == false)
            return;

        MovimentarXYZ();
    }

    /*
     * Lê teclado ou Xbox, calcula movimento,
     * corrida, pulo, gravidade e animações.
     */
    private void MovimentarXYZ()
    {
        // Verificar se o jogador está correndo
        bool estaCorrendo = acaoCorrer.action.IsPressed();

        // Definir a velocidade
        float velocidade = estaCorrendo
            ? velocidadeCorrida
            : velocidadeCaminhada;

        // Ler WASD ou analógico esquerdo
        Vector2 entradaMovimento =
            acaoMover.action.ReadValue<Vector2>();

        // Converter Vector2 para Vector3
        Vector3 direcaoXZ = new Vector3(
            entradaMovimento.x,
            0f,
            entradaMovimento.y
        );

        // Limitar a diagonal e manter a
        // intensidade parcial do analógico
        direcaoXZ = Vector3.ClampMagnitude(direcaoXZ, 1f);

        // Rotacionar em relação à câmera
        if (direcaoXZ != Vector3.zero)
        {
            direcaoXZ =
                RotacionarParaOndeACameraEstaVisualizando(direcaoXZ);
        }

        // Verificar se está no chão
        if (playerController.isGrounded == true)
        {
            // Verificar botão de pulo
            if (acaoPular.action.WasPressedThisFrame())
            {
                velocidadeVertical = forcaPulo;
            }
            else
            {
                velocidadeVertical = -1f;
            }
        }
        else
        {
            // Aplicar gravidade
            velocidadeVertical -= forcaQueda * Time.deltaTime;
        }

        // Calcular direção final
        Vector3 direcaoFinal = direcaoXZ * velocidade;
        direcaoFinal.y = velocidadeVertical;

        // Movimentar usando CharacterController
        if (direcaoFinal != new Vector3(0f, -1f, 0f))
        {
            playerController.Move(
                direcaoFinal * Time.deltaTime
            );
        }

        // Atualizar animação
        AtivaAnimacao(direcaoXZ, estaCorrendo);
    }

    /*
     * Calcula a direção relativa à câmera,
     * suaviza a rotação e mantém a intensidade
     * da movimentação analógica.
     */
    private Vector3 RotacionarParaOndeACameraEstaVisualizando(
        Vector3 direcao)
    {
        float anguloAlvo =
            Mathf.Atan2(direcao.x, direcao.z) *
            Mathf.Rad2Deg + cameraPlayer.eulerAngles.y;

        float angulo = Mathf.SmoothDampAngle(
            transform.eulerAngles.y,
            anguloAlvo,
            ref velocidadeDeGiroSuave,
            valorDeGiroSuave
        );

        transform.rotation = Quaternion.Euler(0f, angulo, 0f);

        return Quaternion.Euler(0f, anguloAlvo, 0f)
               * Vector3.forward * direcao.magnitude;
    }

    /*
     * Impede o jogador de se movimentar.
     */
    public void BloquearMovimentacao()
    {
        habilitarMovimentacao = false;
    }

    /*
     * Permite novamente a movimentação.
     */
    public void PermitirMovimentacao()
    {
        habilitarMovimentacao = true;
    }

    /*
     * Controla as animações de caminhada,
     * corrida, pulo e personagem parado.
     */
    private void AtivaAnimacao(
        Vector3 direcaoFinal, bool estaCorrendo)
    {
        if (playerController.isGrounded == true)
        {
            if (direcaoFinal != Vector3.zero)
            {
                if (estaCorrendo == true)
                {
                    animacaoPlayer.PlayCorrendo();
                }
                else
                {
                    animacaoPlayer.PlayAndando();
                }
            }
            else
            {
                animacaoPlayer.PlayParado();
            }
        }
        else
        {
            animacaoPlayer.PlayPulando();
        }
    }
}
