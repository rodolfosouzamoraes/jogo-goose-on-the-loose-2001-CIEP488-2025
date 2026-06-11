using UnityEngine;
using UnityEngine.Events;

public class SuporteEventosAnimacao : MonoBehaviour
{
    public UnityEvent evento1;
    public UnityEvent evento2;
    public UnityEvent evento3;
    public UnityEvent evento4;
    public UnityEvent evento5;
    

    public void ChamarEvento1(int i)
    {
        evento1.Invoke();
    }
}
