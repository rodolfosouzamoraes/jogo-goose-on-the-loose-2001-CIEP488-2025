using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelFimDeJogo : MonoBehaviour
{
    [SerializeField] GameObject pnlFimDeJogo;
    
    public void ExibirFimDeJogo()
    {
        pnlFimDeJogo.SetActive(true);
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continuar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Rejogar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
