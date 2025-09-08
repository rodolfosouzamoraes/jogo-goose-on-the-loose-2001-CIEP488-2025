using UnityEngine;

public class DanificarPlayer : MonoBehaviour
{
    [SerializeField] bool destruirObjeto = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<DanoPlayer>().Dano();

            if(destruirObjeto == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
