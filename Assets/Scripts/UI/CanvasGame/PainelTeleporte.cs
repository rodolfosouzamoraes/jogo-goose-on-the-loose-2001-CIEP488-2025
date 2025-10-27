using UnityEngine;

public class PainelTeleporte : MonoBehaviour
{
    [SerializeField] GameObject pnlTeleporte;
    
    public void AtivarPainelTeleporte()
    {
        pnlTeleporte.SetActive(true);
    }
}
