using UnityEngine;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] private GameObject corpoPatrulheiro;
    [SerializeField] private float velocidadeMovimento = 5f;
    [SerializeField] private float velocidadeRotacao = 2f;
    [SerializeField] private MoverParaFrente moverObjeto;

    private bool estaMovendo = true;
    private bool estaRotacionando = false;
    private float anguloAtual; // ângulo real em graus

    void Start()
    {
        // Inicializa com o ângulo Y real do objeto (em graus)
        anguloAtual = corpoPatrulheiro.transform.eulerAngles.y;
    }

    void Update()
    {
        Rotacionar();
    }

    private void Rotacionar()
    {
        if (!estaRotacionando) return;

        // Calcula a rotação alvo em graus
        Quaternion rotacaoAlvo = Quaternion.Euler(0, anguloAtual, 0);

        // Faz interpolação suave até o ângulo alvo
        corpoPatrulheiro.transform.rotation = Quaternion.RotateTowards(
            corpoPatrulheiro.transform.rotation,
            rotacaoAlvo,
            velocidadeRotacao * Time.deltaTime
        );

        // Verifica se chegou próximo o suficiente do alvo
        float diferenca = Quaternion.Angle(corpoPatrulheiro.transform.rotation, rotacaoAlvo);
        if (diferenca <= 0.1f)
        {
            estaRotacionando = false;
            moverObjeto.InverterVelocidade();
        }
    }

    public void PermitirRotacionar()
    {
        // Incrementa a rotação em 180 graus
        anguloAtual += 180f;

        // Mantém o valor entre 0 e 360
        anguloAtual %= 360f;

        // Ativa a rotação e pausa o movimento
        estaRotacionando = true;
        moverObjeto.PararMovimentacao();
    }
}