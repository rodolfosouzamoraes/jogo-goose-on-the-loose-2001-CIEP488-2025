using UnityEngine;

public class ChavePortao : MonoBehaviour
{
    [SerializeField] Fechadura fechaduraPortao;

    [SerializeField] GameObject efeitoChave;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Informo que peguei a chave do portao
            fechaduraPortao.ColetouChave();

            GameObject novoEfeito = Instantiate(efeitoChave);
            novoEfeito.transform.position = transform.position;

            //Destruo o objeto da chave
            Destroy(gameObject);
        }
    }
}
