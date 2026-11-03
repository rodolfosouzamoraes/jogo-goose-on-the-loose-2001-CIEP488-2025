using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionarCameraX : MonoBehaviour
{
    [Header("Velocidade de Rotação")]
    [SerializeField] private float velocidadeRotacao = 0.1f; // Sensibilidade do mouse (graus por pixel)
    [SerializeField] private float velocidadeRotacaoControle = 120f; // Velocidade do analógico (graus por segundo)

    [Header("Limites da Câmera")]
    [SerializeField] private float limiteNegativoX;
    [SerializeField] private float limitePositivoX;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference acaoCamera; // Jogador > Camera

    private float cameraAnguloX; // Ângulo vertical atual da câmera
    private InputAction acaoCameraInstancia; // Cópia independente da Action Camera

    /*
     * Valida a Action Camera, cria uma cópia para uso exclusivo
     * deste componente e recupera a rotação vertical inicial.
     */
    private void Awake()
    {
        if (acaoCamera == null || acaoCamera.action == null)
        {
            Debug.LogError("RotacionarCameraX: associe a Action Jogador/Camera no Inspector.", this);
            enabled = false;
            return;
        }

        acaoCameraInstancia = acaoCamera.action.Clone();
        cameraAnguloX = Mathf.DeltaAngle(0f, transform.localEulerAngles.x);
    }

    /*
     * Habilita a leitura de mouse e controle quando
     * este componente fica ativo.
     */
    private void OnEnable()
    {
        if (acaoCameraInstancia != null)
            acaoCameraInstancia.Enable();
    }

    /*
     * Interrompe a leitura de entrada quando
     * este componente fica inativo.
     */
    private void OnDisable()
    {
        if (acaoCameraInstancia != null)
            acaoCameraInstancia.Disable();
    }

    /*
     * Libera os recursos da Action criada para este componente.
     */
    private void OnDestroy()
    {
        acaoCameraInstancia?.Dispose();
    }

    /*
     * Lê o movimento vertical do mouse ou do analógico direito,
     * aplica a velocidade adequada a cada dispositivo,
     * limita o ângulo e rotaciona a câmera no eixo X.
     */
    private void Update()
    {
        // Manter a regra já existente para o fim do jogo.
        if (CanvasGameMng.Instance.FimDeJogo == true)
            return;

        // A Action Camera é do tipo Value / Vector2.
        Vector2 entradaCamera = acaoCameraInstancia.ReadValue<Vector2>();

        // O controle ativo informa se a leitura veio de um Gamepad.
        bool usandoControle = acaoCameraInstancia.activeControl?.device is Gamepad;

        // Mouse: delta em pixels, sem multiplicar por Time.deltaTime.
        // Controle: posição do analógico, com rotação em graus por segundo.
        float movimentoVertical = usandoControle
            ? entradaCamera.y * velocidadeRotacaoControle * Time.deltaTime
            : entradaCamera.y * velocidadeRotacao;

        // Preservar o sentido vertical do código original.
        cameraAnguloX -= movimentoVertical;

        // Impedir que a câmera ultrapasse os limites informados.
        cameraAnguloX = Mathf.Clamp(
            cameraAnguloX,
            limiteNegativoX,
            limitePositivoX
        );

        // Aplicar a rotação vertical local.
        transform.localRotation = Quaternion.Euler(cameraAnguloX, 0f, 0f);
    }
}
