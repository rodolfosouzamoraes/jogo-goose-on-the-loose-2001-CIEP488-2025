using UnityEngine;

public class ColetarMoeda : MonoBehaviour
{
    [SerializeField] GameObject efeitoMoeda;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Acessar diretamente o incremento de moedas
            CanvasGameMng.PainelTopo.IncrementarMoeda();

            //Instanciar o efeito da moeda
            GameObject novoEfeito = Instantiate(efeitoMoeda);
            novoEfeito.transform.position = transform.position;

            //Destruir a moeda
            Destroy(gameObject);
        }
    }
}
