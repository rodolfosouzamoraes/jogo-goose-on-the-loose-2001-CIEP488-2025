using Unity.VisualScripting;
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
        //Verificar se o level pode ser carregado, se ele foi desbloqueado
        bool foiDesbloqueado = DBMng.ObterLevelDesbloqueado(id) == 1;

        if(foiDesbloqueado == true)
        {
            //Exibir a tela de loading
            CanvasLoadingMng.Instance.ExibirTela();

            //Carregar cena do level id
            SceneManager.LoadScene(id);
        }        
    }

    public void CarregarPrimeiroLevel()
    {
        //Exibir a tela de loading
        CanvasLoadingMng.Instance.ExibirTela();

        //Carregar cena do level id
        SceneManager.LoadScene(1);
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}
