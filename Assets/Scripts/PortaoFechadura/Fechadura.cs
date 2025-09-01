using UnityEngine;

public class Fechadura : MonoBehaviour
{
    [SerializeField] AbrirFecharPassagem portao;
    [SerializeField] GameObject fechadura;
    private bool temChave = false;
    
    //Quando coletar a chave vai mudar para true
    public void ColetouChave()
    {
        temChave = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //Verificar se tem a chave para coletar
            if(temChave == true)
            {
                //Abrir o portao
                portao.AbrirPortao();
                //desativar a fechadura
                fechadura.SetActive(false);
            }     
        }
    }


}
