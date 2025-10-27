using UnityEngine;

public class ColisaoProjetil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Efetuar dano no player

        }

        //Destruir o objeto
        Destroy(gameObject);
    }
}
