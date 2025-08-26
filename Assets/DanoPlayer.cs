using UnityEngine;

public class DanoPlayer : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] MoverPlayer moverPlayer;
    
    public void DanoArmadilhas()
    {
        //Diminuir a vida
        vida--;

        //verificar se a vida acabou
        if(vida == 0)
        {
            //GameOver
            gameObject.SetActive(false);
        }
    }
}
