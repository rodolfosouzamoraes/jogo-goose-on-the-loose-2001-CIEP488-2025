using UnityEngine;

public class ChavePortao : MonoBehaviour
{
    [SerializeField] Fechadura fechaduraPortao;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Informo que peguei a chave do portao
            fechaduraPortao.ColetouChave();

            //Destruo o objeto da chave
            Destroy(gameObject);
        }
    }
}
