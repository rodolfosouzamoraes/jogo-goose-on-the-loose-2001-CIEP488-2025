using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] MoverPlayer moverPlayer;
    
    public void Dano()
    {
        //Verificar se o jogo acabou
        if (CanvasGameMng.Instance.FimDeJogo == true) return;

        //Diminuir a vida
        vida--;

        //Atualizar UI vida
        CanvasGameMng.PainelVidaPlayer.AtualizarVidaUI(vida);

        //verificar se a vida acabou
        if(vida == 0)
        {
            MatarPlayer();
        }
    }

    public void MatarPlayer()
    {
        vida = 0;
        gameObject.SetActive(false);

        //Atualizar UI vida
        CanvasGameMng.PainelVidaPlayer.AtualizarVidaUI(vida);

        //Game Over
        CanvasGameMng.PainelGameOver.GameOver();
    }
}
