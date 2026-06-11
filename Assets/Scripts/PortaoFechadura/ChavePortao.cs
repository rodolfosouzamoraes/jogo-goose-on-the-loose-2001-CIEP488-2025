using UnityEngine;

public class ChavePortao : MonoBehaviour
{
    [SerializeField] Fechadura fechaduraPortao;
    [SerializeField] GameObject efeitoChave;
    [SerializeField] AudioClip audioColetaChave;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Informo que peguei a chave do portao
            fechaduraPortao.ColetouChave();

            GameObject novoEfeito = Instantiate(efeitoChave);
            novoEfeito.transform.position = transform.position;

            AudioMng.Instance.PlayAudioSFX(audioColetaChave);

            //Destruo o objeto da chave
            Destroy(gameObject);
        }
    }
}
