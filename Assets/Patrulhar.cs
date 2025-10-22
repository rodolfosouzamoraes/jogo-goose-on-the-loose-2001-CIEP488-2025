using UnityEngine;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] private GameObject corpoPatrulheiro;
    [SerializeField] private float velocidadeMovimento = 5f;
    [SerializeField] private float velocidadeRotacao = 2f;
    [SerializeField] private MoverParaFrente moverObjeto;

    private bool estaMovendo = true;
    private bool estaRotacionando = false;
    private float anguloAtual; // �ngulo real em graus

    void Start()
    {
        // Inicializa com o �ngulo Y real do objeto (em graus)
        anguloAtual = corpoPatrulheiro.transform.eulerAngles.y;
    }

    void Update()
    {
        Rotacionar();
    }

    private void Rotacionar()
    {
        if (!estaRotacionando) return;

        // Calcula a rota��o alvo em graus
        Quaternion rotacaoAlvo = Quaternion.Euler(0, anguloAtual, 0);

        // Faz interpola��o suave at� o �ngulo alvo
        corpoPatrulheiro.transform.rotation = Quaternion.RotateTowards(
            corpoPatrulheiro.transform.rotation,
            rotacaoAlvo,
            velocidadeRotacao * Time.deltaTime
        );

        // Verifica se chegou pr�ximo o suficiente do alvo
        float diferenca = Quaternion.Angle(corpoPatrulheiro.transform.rotation, rotacaoAlvo);
        if (diferenca <= 0.1f)
        {
            estaRotacionando = false;
            moverObjeto.InverterVelocidade();
        }
    }

    public void PermitirRotacionar()
    {
        // Incrementa a rota��o em 180 graus
        anguloAtual += 180f;

        // Mant�m o valor entre 0 e 360
        anguloAtual %= 360f;

        // Ativa a rota��o e pausa o movimento
        estaRotacionando = true;
        moverObjeto.PararMovimentacao();
    }
}