using UnityEngine;

public class AtirarProjetil : MonoBehaviour
{
    [SerializeField] GameObject projetil;
    [SerializeField] float tempoAtaque; //Tempo para surgir novos projeteis
    private float tempoEspera; //Tempo para esperar o novo projetil
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configurar o tempo espera
        tempoEspera = Time.timeSinceLevelLoad + tempoAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        AtirarNovoProjetil();
    }

    private void AtirarNovoProjetil()
    {
        //Verificar se está no tempo de atirar
        if (Time.timeSinceLevelLoad > tempoEspera) {
            //Atualizo o tempo
            tempoEspera = Time.timeSinceLevelLoad + tempoAtaque;
            //Instancio o projetil
            GameObject novoProjetil = Instantiate(projetil);
            //Coloco ele na mesma posição e rotação do inimigo
            novoProjetil.transform.position = transform.position;
            novoProjetil.transform.rotation = transform.rotation;
            //Jogo o projetil para frente do inimigo
            novoProjetil.transform.Translate(new Vector3(0, 0, 1.25f));
        }
    }
}
