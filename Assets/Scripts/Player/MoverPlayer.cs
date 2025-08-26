using Unity.VisualScripting;
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

        //Rotacionar o jogador em referencia a camera
        if (direcaoXZ != Vector3.zero) { 
            direcaoXZ = RotacionarParaOndeACameraEstaVisualizando(direcaoXZ);
        }

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
        if(direcaoFinal != new Vector3(0,-1,0))
        {
            playerController.Move(direcaoFinal * Time.deltaTime);
        }
            
    }

    private Vector3 RotacionarParaOndeACameraEstaVisualizando(Vector3 direcao)
    {
        //Converter a dire��o de entrada em um angulo no plano XZ e
        //depois transformar em graus para conseguir usar a camera como referencia
        float anguloAlvo = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg + cameraPlayer.eulerAngles.y;

        //Fazer uma rota��o suave entre o angulo que o jogador est� para o angulo alvo
        float angulo = Mathf.SmoothDampAngle(
            transform.eulerAngles.y, 
            anguloAlvo, 
            ref velocidadeDeGiroSuave, 
            valorDeGiroSuave
        );

        //Atualizar a rota��o do player no mundo do jogo, girando ele no eixo y
        transform.rotation = Quaternion.Euler(0, angulo, 0);

        //Retornar a dire��o ajustada pela rota��o do player
        return Quaternion.Euler(0,anguloAlvo,0) * Vector3.forward;
    }
}
