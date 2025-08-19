using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    //Variaveis para configurar a camera
    private Transform cameraPlayer;
    private float valorDeGiroSuave = 0.1f;
    private float velocidadeDeGiroSuave;

    //Variaveis de movimenta��o do player
    [Header("Config Movimento")]
    [SerializeField] float velocidadeCaminhada; //Velocidade de caminhada do player
    [SerializeField] float velocidadeCorrida; //Velocidade de corrida do player
    [SerializeField] float forcaPulo; //For�a de subida do player
    [SerializeField] float forcaQueda; //For�a de queda do player
    private CharacterController playerController; //O controlador da movimenta��o do player
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

    //M�todo para movimentar o player nos eixos xyz
    private void MovimentarXYZ()
    {
        //Verificar se o player esta correndo
        bool estaCorrendo = Input.GetAxisRaw("Correr") > 0;

        //Definir a velocidade de movimenta��o do player
        float velocidade = estaCorrendo == true ? velocidadeCorrida : velocidadeCaminhada;

        //Definir a dire��o de movimenta��o vertical
        float direcaoVertical = Input.GetAxisRaw("Vertical");

        //Definir a dire��o de movimenta��o horizontal
        float direcaoHorizontal = Input.GetAxisRaw("Horizontal");

        //Definir a dire��o no plano X e Z
        Vector3 direcaoXZ = new Vector3(direcaoHorizontal,0,direcaoVertical).normalized;

        //Verificar se o jogador est� no ch�o para poder pular
        if (playerController.isGrounded == true) {
            //Verificar se a tecla do pulo foi acionada
            if (Input.GetButtonDown("Jump"))
            {
                velocidadeVertical = forcaPulo;
            }
            else
            {
                //Fazer o personagem se manter no ch�o ap�s cair
                velocidadeVertical = -1;
            }
        }
        else
        {
            //Fazer o player descer
            velocidadeVertical -= forcaQueda * Time.deltaTime;
        }

        //Combinar a dire��o do plano X e Z com a velocidade de movimenta��o
        Vector3 direcaoFinal = direcaoXZ * velocidade;

        //Definir a direcao em Y
        direcaoFinal.y = velocidadeVertical;

        //Movimentar o player
        playerController.Move(direcaoFinal * Time.deltaTime);
    }
}
