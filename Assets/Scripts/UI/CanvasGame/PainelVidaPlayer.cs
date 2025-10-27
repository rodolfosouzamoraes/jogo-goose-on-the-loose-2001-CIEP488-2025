using UnityEngine;

public class PainelVidaPlayer : MonoBehaviour
{
    [SerializeField] GameObject pnlVidaPlayer;
    [SerializeField] GameObject[] vidas;

    public void AtualizarVidaUI(int totalVidaPlayer)
    {
        //Ocultar todas as vidas para ativar apenas a quantidade de vidas correta
        foreach (var vida in vidas)
        {
            vida.SetActive(false);
        }

        if (totalVidaPlayer !=0) {
            //Exibir a quantidade de vidas disponiveis
            for (int i = 0; i < totalVidaPlayer; i++)
            {
                vidas[i].SetActive(true);
            }
        }
    }
}
