using UnityEngine;

public class MoverParaDestinos : MonoBehaviour
{
    [SerializeField] Vector3[] destinos;//Todos os destinos que a plataforma ir�
    [SerializeField] float velocidade;//Velocidade de movimenta��o
    [SerializeField] float tempoEspera; //Tempo para esperar a se mover
    private int destinoId;//Identificar qual destino ele est�
    private bool proximoDestino;//Verificar se est� habilitado da plataforma ir para o proximo destino
    private float proximoTempo;//Tempo para ir para o proximo destino

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
