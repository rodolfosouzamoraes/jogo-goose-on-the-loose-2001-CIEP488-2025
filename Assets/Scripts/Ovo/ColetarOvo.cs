using UnityEngine;

public class ColetarOvo : MonoBehaviour
{
    [SerializeField] GameObject efeitoOvo;
    [SerializeField] AudioClip audioColetarOvo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Incrementar ovo 
            CanvasGameMng.PainelTopo.IncrementarOvo();

            GameObject novoEfeito = Instantiate(efeitoOvo);
            novoEfeito.transform.position = transform.position;

            AudioMng.Instance.PlayAudioSFX(audioColetarOvo);

            //Destruir ovo
            Destroy(gameObject);
        }
    }
}
