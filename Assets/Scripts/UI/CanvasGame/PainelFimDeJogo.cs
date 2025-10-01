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
        //Verificar se coletou todos os ovos e todas as moedas
        if(totalMoedasLevel == totalMoedasColetadas && totalOvosColetados == 3)
        {
            //Jogador recebe o ganso e o ovo de ouro
            imgGansoFinal.sprite = sptsGanso[0];
            imgOvoFinal.sprite = sptsOvo[0];
        }
        else
        {
            //Calcular a porcentagem de coleta de moedas
            float porcentagem = ((float)totalMoedasColetadas / (float)totalMoedasLevel) * 100;
            //Verificar se coletou acima de 50% das moedas e se tem mais de 1 ovo
            if (porcentagem >=50 && totalOvosColetados > 1)
            {
                //Jogador recebe o ganso e o ovo de prata
                imgGansoFinal.sprite = sptsGanso[1];
                imgOvoFinal.sprite = totalOvosColetados == 2 ? sptsOvo[1] : sptsOvo[0];
            }
            else
            {
                //Jogador recebe o ganso bronze
                imgGansoFinal.sprite = sptsGanso[2];
                //Verifica a coleta dos ovos
                switch (totalOvosColetados)
                {
                    case 2:
                        imgOvoFinal.sprite = sptsOvo[1];
                        break;
                    case 1:
                        imgOvoFinal.sprite = sptsOvo[2];
                        break;
                    case 0:
                        imgOvoFinal.enabled =false;
                        break;
                }
            }
        }

        //Exibir o total de moedas coletadas
        txtMoedasTotais.text = $"x{totalMoedasColetadas}";

        ExibirFimDeJogo();
    }
}
