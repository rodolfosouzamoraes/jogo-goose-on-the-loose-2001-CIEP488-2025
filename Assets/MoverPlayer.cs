using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    //Variaveis para configurar a camera
    private Transform cameraPlayer;
    private float valorDeGiroSuave = 0.1f;
    private float velocidadeDeGiroSuave;

    //Variaveis de movimentação do player
    [Header("Config Movimento")]
    [SerializeField] float velocidadeCaminhada; //Velocidade de caminhada do player
    [SerializeField] float velocidadeCorrida; //Velocidade de corrida do player
    [SerializeField] float forcaPulo; //Força de subida do player
    [SerializeField] float forcaQueda; //Força de queda do player
    private CharacterController playerController; //O controlador da movimentação do player
    private float velocidadeVertical = 0; //A velocidade na vertical do player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configurar a variavel playerController
        playerController = GetComponent<CharacterController>();

        //Configurar a posicao da camera do player
        cameraPlayer = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarXYZ();
    }

    //Método para movimentar o player nos eixos xyz
    private void MovimentarXYZ()
    {
        //Verificar se o player esta correndo
        bool estaCorrendo = Input.GetAxisRaw("Correr") > 0;

        //Definir a velocidade de movimentação do player
        float velocidade = estaCorrendo == true ? velocidadeCorrida : velocidadeCaminhada;

        //Definir a direção de movimentação vertical
        float direcaoVertical = Input.GetAxisRaw("Vertical");

        //Definir a direção de movimentação horizontal
        float direcaoHorizontal = Input.GetAxisRaw("Horizontal");

        //Definir a direção no plano X e Z
        Vector3 direcaoXZ = new Vector3(direcaoHorizontal,0,direcaoVertical).normalized;

        //Verificar se o jogador está no chão para poder pular
        if (playerController.isGrounded == true) {
            //Verificar se a tecla do pulo foi acionada
            if (Input.GetButtonDown("Jump"))
            {
                velocidadeVertical = forcaPulo;
            }
            else
            {
                //Fazer o personagem se manter no chão após cair
                velocidadeVertical = -1;
            }
        }
        else
        {
            //Fazer o player descer
            velocidadeVertical -= forcaQueda * Time.deltaTime;
        }

        //Combinar a direção do plano X e Z com a velocidade de movimentação
        Vector3 direcaoFinal = direcaoXZ * velocidade;

        //Definir a direcao em Y
        direcaoFinal.y = velocidadeVertical;

        //Movimentar o player
        playerController.Move(direcaoFinal * Time.deltaTime);
    }
}
