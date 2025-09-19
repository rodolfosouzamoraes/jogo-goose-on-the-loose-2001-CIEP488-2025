using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    [SerializeField] GameObject pnlGameOver;

    public void GameOver()
    {
        CanvasGameMng.Instance.FimDeJogo = true;

        pnlGameOver.SetActive(true);

        Invoke("ReiniciarJogo", 3f);
    }

    private void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
