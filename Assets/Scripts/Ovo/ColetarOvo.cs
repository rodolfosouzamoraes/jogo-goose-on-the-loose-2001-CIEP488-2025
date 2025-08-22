using UnityEngine;

public class ColetarOvo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Incrementar ovo 
            CanvasGameMng.PainelTopo.IncrementarOvo();

            //Destruir ovo
            Destroy(gameObject);
        }
    }
}
