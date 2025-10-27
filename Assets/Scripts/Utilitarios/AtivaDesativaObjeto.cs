using UnityEngine;

public class AtivaDesativaObjeto : MonoBehaviour
{
    public void AtivarObjeto()
    {
        gameObject.SetActive(true);
    }

    public void DesativarObjeto()
    {
        gameObject.SetActive(false);
    }
}
