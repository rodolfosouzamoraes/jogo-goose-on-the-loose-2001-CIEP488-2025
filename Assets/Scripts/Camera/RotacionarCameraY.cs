using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionarCameraY : MonoBehaviour
{
    [Header("Velocidade de Rotação")]
    [SerializeField] private float velocidadeRotacao = 0.1f; // Sensibilidade do mouse (graus por pixel)
    [SerializeField] private float velocidadeRotacaoControle = 180f; // Velocidade do analógico (graus por segundo)

    [Header("Input Actions")]
    [SerializeField] private InputActionReference acaoCamera; // Jogador > Camera

    private InputAction acaoCameraInstancia; // Cópia independente da Action Camera

    /*
     * Confere se a Action foi associada e cria uma cópia
     * independente para este componente da câmera.
     */
    private void Awake()
    {
        if (acaoCamera == null || acaoCamera.action == null)
        {
            Debug.LogError("RotacionarCameraY: associe a Action Jogador/Camera no Inspector.", this);
            enabled = false;
            return;
        }

        acaoCameraInstancia = acaoCamera.action.Clone();
    }

    /*
     * Habilita a leitura da Action Camera ao ativar o componente.
     */
    private void OnEnable()
    {
        if (acaoCameraInstancia != null)
            acaoCameraInstancia.Enable();
    }

    /*
     * Desabilita a leitura ao desativar este componente.
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
     * Lê o movimento horizontal do mouse ou do analógico direito,
     * diferencia as velocidades e rotaciona a câmera no eixo Y.
     */
    private void Update()
    {
        // Manter a regra já existente para o fim do jogo.
        if (CanvasGameMng.Instance.FimDeJogo == true)
            return;

        // Receber movimento horizontal e vertical da Action Camera.
        Vector2 entradaCamera = acaoCameraInstancia.ReadValue<Vector2>();

        // Detectar se a Action está sendo comandada pelo controle.
        bool usandoControle = acaoCameraInstancia.activeControl?.device is Gamepad;

        // Mouse utiliza delta em pixels; controle usa graus por segundo.
        float rotacaoY = usandoControle
            ? entradaCamera.x * velocidadeRotacaoControle * Time.deltaTime
            : entradaCamera.x * velocidadeRotacao;

        // Preservar a rotação incremental do código original.
        transform.rotation *= Quaternion.Euler(0f, rotacaoY, 0f);
    }
}
