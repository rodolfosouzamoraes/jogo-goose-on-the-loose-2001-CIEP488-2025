using UnityEngine;

public class LimiteMundo : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<DanoPlayer>().MatarPlayer();
        }
    }
}
