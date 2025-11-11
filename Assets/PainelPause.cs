using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelPause : MonoBehaviour
{
    [SerializeField] GameObject pnlPause;
    private bool jogoPausado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Garante que o pause começe desativado
        pnlPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (jogoPausado == true) return;

        if (Input.GetKeyDown(KeyCode.P))
        {
            PausarJogo();
        }
    }

    public void PausarJogo()
    {
        //Exibir o painel de pause
        pnlPause.SetActive(true);
        //Definir que está pausado
        jogoPausado = true;
        //Pausar o jogo
        Time.timeScale = 0;
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1;
        pnlPause.SetActive(false);
        jogoPausado = false;        
    }

    public void Sair()
    {
        Time.timeScale = 1;
        CanvasLoadingMng.Instance.ExibirTela();
        SceneManager.LoadScene(0);
    }
}
