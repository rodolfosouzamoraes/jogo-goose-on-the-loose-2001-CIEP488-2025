using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PainelFimDeJogo : MonoBehaviour
{
    [SerializeField] GameObject pnlFimDeJogo;
    [SerializeField] Image imgGansoFinal;
    [SerializeField] Image imgOvoFinal;
    [SerializeField] TextMeshProUGUI txtMoedasTotais;
    [SerializeField] Sprite[] sptsGanso;
    [SerializeField] Sprite[] sptsOvo;
    
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

    public void CalcularPontosLevel(int totalMoedasLevel, int totalMoedasColetadas, int totalOvosColetados)
    {
        int ovoFinal = 4;
        int gansoFinal = 4;

        //Calcular a porcentagem de coleta de moedas
        float porcentagem = ((float)totalMoedasColetadas / (float)totalMoedasLevel) * 100;

        //Verifica a coleta dos ovos
        switch (totalOvosColetados)
        {
            case 3:
                imgOvoFinal.sprite = sptsOvo[0];
                ovoFinal = 1;
                break;
            case 2:
                imgOvoFinal.sprite = sptsOvo[1];
                ovoFinal = 2;
                break;
            case 1:
                imgOvoFinal.sprite = sptsOvo[2];
                ovoFinal = 3;
                break;
            case 0:
                imgOvoFinal.enabled = false;
                ovoFinal = 4;
                break;
        }

        //Verificar se coletou acima de 50% das moedas e se tem mais de 1 ovo
        if (porcentagem >= 50 && porcentagem < 100)
        {
            //Jogador recebe o ganso e o ovo de prata
            imgGansoFinal.sprite = sptsGanso[1];
            gansoFinal = 2;
        }
        else if (porcentagem >= 100)
        {
            imgGansoFinal.sprite = sptsGanso[0];
            gansoFinal = 1;
        }
        else if(porcentagem > 0)
        {
            //Jogador recebe o ganso bronze
            imgGansoFinal.sprite = sptsGanso[2];
            gansoFinal = 3;
        }

        //Exibir o total de moedas coletadas
        txtMoedasTotais.text = $"x{totalMoedasColetadas}";

        //Salvar na memoria os dados
        DBMng.Save(
            SceneManager.GetActiveScene().buildIndex,
            totalOvosColetados,
            totalMoedasColetadas,
            ovoFinal,
            gansoFinal
        );

        ExibirFimDeJogo();
    }
}
