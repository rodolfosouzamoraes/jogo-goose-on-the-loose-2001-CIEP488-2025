using UnityEngine;

public class ColetarMoeda : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Acessar diretamente o incremento de moedas
            CanvasGameMng.PainelTopo.IncrementarMoeda();

            //Destruir a moeda
            Destroy(gameObject);
        }
    }
}
