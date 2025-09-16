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

        //verificar se a vida acabou
        if(vida == 0)
        {
            //GameOver
            gameObject.SetActive(false);
        }
    }

    public void MatarPlayer()
    {
        vida = 0;
        gameObject.SetActive(false);
        //Game Over
    }
}
