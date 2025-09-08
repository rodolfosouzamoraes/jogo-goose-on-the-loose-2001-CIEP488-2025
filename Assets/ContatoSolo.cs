using UnityEngine;
using UnityEngine.Events;

public class ContatoSolo : MonoBehaviour
{
    public UnityEvent eventos;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Solo"))
        {
            eventos.Invoke();
        }        
    }
}
