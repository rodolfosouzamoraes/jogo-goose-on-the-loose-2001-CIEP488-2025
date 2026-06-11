using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] MoverPlayer moverPlayer;
    [SerializeField] GameObject efeitoDano;
    [SerializeField] GameObject efeitoMorte;
    
    public void Dano()
    {
        //Verificar se o jogo acabou
        if (CanvasGameMng.Instance.FimDeJogo == true) return;

        //Diminuir a vida
        vida--;

        //Atualizar UI vida
        CanvasGameMng.PainelVidaPlayer.AtualizarVidaUI(vida);

        //verificar se a vida acabou
        if (vida == 0)
        {            
            MatarPlayer();
        }
        else
        {
            GameObject novoEfeito = Instantiate(efeitoDano);
            novoEfeito.transform.position = transform.position;
            GetComponentInChildren<AudioController>().PlayAudioGlobal(2);
        }
    }

    public void MatarPlayer()
    {
        GetComponentInChildren<AudioController>().PlayAudioGlobal(6);
        vida = 0;

        GameObject novoEfeito = Instantiate(efeitoMorte);
        novoEfeito.transform.position = transform.position;

        gameObject.SetActive(false);

        //Atualizar UI vida
        CanvasGameMng.PainelVidaPlayer.AtualizarVidaUI(vida);

        //Game Over
        CanvasGameMng.PainelGameOver.GameOver();
    }
}
