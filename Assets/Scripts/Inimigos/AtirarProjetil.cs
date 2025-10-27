using UnityEngine;

public class AtirarProjetil : MonoBehaviour
{
    [SerializeField] GameObject projetil;

    public void AtirarNovoProjetil()
    {
        //Instancio o projetil
        GameObject novoProjetil = Instantiate(projetil);
        //Coloco ele na mesma posição e rotação do inimigo
        novoProjetil.transform.position = transform.position;
        novoProjetil.transform.rotation = transform.rotation;
        //Jogo o projetil para frente do inimigo
        novoProjetil.transform.Translate(new Vector3(0, 0, 1.25f));
    }
}
