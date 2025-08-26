using UnityEngine;

public class MoverParaDestinos : MonoBehaviour
{
    [SerializeField] Vector3[] destinos;//Todos os destinos que a plataforma irá
    [SerializeField] float velocidade;//Velocidade de movimentação
    [SerializeField] float tempoEspera; //Tempo para esperar a se mover
    private int destinoId;//Identificar qual destino ele está
    private bool proximoDestino;//Verificar se está habilitado da plataforma ir para o proximo destino
    private float proximoTempo;//Tempo para ir para o proximo destino

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definir a posição inicial da plataforma
        transform.localPosition = destinos[0];

        //Definir o proximo destino com o seu identificador do vetor
        destinoId = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoverPlataforma();
    }

    private void MoverPlataforma()
    {
        //verificar se a plataforma pode ir para o proximo destino
        if(proximoDestino == true)
        {
            //Verificar se deu o tempo de espera para mudar o destino
            if (Time.timeSinceLevelLoad > proximoTempo) { 
                
                //Incrementar o proximo destino no id
                destinoId++;

                //Verificar se já passou do ultimo destino
                if (destinoId == destinos.Length) {
                    
                    //Voltar para o id do destino inicial
                    destinoId = 0;
                }

                //Após fazer a troca do destino, desabilitar nova troca
                proximoDestino = false;                
            }
        }
        else //Mover a plataforma até o destino atual
        {
            //definir a velocidade de movimento
            float velocidadeMovimento = velocidade * Time.deltaTime;

            //mover o objeto até o destino
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition, 
                destinos[destinoId],
                velocidadeMovimento
            );

            //Verificar se chegou no destino
            if(Vector3.Distance(transform.localPosition, destinos[destinoId]) < 0.001f)
            {
                //Habilitar para mudar o destino da plataforma
                proximoDestino = true;

                //Atualizar o tempo de espera
                proximoTempo = Time.timeSinceLevelLoad + tempoEspera;
            }
        }
    }
}
