using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] GameObject[] Telas;

    private void Start()
    {
        //Ocultar a tela de loading
        CanvasLoadingMng.Instance.OcultarTela();
    }

    public void CarregarLevel(int id)
    {
        //Exibir a tela de loading
        CanvasLoadingMng.Instance.ExibirTela();

        //Carregar cena do level id
        SceneManager.LoadScene(id);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
