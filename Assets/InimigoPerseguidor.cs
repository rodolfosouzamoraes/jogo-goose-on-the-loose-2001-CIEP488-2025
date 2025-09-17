using UnityEngine;
using UnityEngine.AI;

public class InimigoPerseguidor : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 posicaoInicial;
    [SerializeField] float velocidade;
    [SerializeField] float distanciaParaPerseguir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referenciar a IA do inimigo
        agent = GetComponent<NavMeshAgent>();

        //Referenciar o objeto do player
        player = FindFirstObjectByType<MoverPlayer>().gameObject;

        //Definir a posição inicial
        posicaoInicial = transform.position;

        //Definir a velocidade de movimentação da IA
        agent.speed = velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        //Calcular a distancia entre o jogador e o inimigo
        float distanciaDoPlayer = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        //Verificar se pode perseguir o player
        if (distanciaDoPlayer < distanciaParaPerseguir) { 
            //Ir até a posição do player
            agent.destination = player.transform.position;
        }
        else
        {
            agent.destination = posicaoInicial;
        }
    }
}
