using UnityEngine;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] GameObject[] Telas;

    

    public void SairJogo()
    {
        Application.Quit();
    }
}
