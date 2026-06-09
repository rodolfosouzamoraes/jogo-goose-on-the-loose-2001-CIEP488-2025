using UnityEngine;
using UnityEngine.UI;

public class PainelVidaPlayer : MonoBehaviour
{
    [SerializeField] GameObject pnlVidaPlayer;
    [SerializeField] GameObject[] vidas;

    public void AtualizarVidaUI(int totalVidaPlayer)
    {
        //Ocultar todas as vidas para ativar apenas a quantidade de vidas correta
        for(int i = 0; i < vidas.Length; i++)
        {
            vidas[i].GetComponent<RawImage>().color = Color.black;
        }

        if (totalVidaPlayer !=0) {
            //Exibir a quantidade de vidas disponiveis
            for (int i = 0; i < totalVidaPlayer; i++)
            {
                vidas[i].GetComponent<RawImage>().color = Color.white;
            }
        }
    }
}
