using UnityEngine;

public class ColetarItemFinal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            CanvasGameMng.Instance.DefinirFimDeJogo();
        }
    }
}
