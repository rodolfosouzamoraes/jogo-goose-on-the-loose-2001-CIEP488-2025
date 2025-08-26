using UnityEngine;

public class DanificarPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<DanoPlayer>().DanoArmadilhas();
        }
    }
}
