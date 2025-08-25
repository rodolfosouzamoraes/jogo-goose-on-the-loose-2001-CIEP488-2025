using UnityEngine;

public class PisoPlataforma : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
}
