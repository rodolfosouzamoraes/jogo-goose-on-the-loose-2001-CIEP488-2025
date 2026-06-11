using UnityEngine;

public class ColetarItemFinal : MonoBehaviour
{
    [SerializeField] AudioClip audioColetaItem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            AudioMng.Instance.PlayAudioSFX(audioColetaItem);
            CanvasGameMng.Instance.DefinirFimDeJogo();
        }
    }
}
