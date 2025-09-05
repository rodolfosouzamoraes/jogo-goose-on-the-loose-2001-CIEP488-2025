using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Temporizador : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtTemporizador;
    [SerializeField] float tempo; //Tempo para contar no botão
    public UnityEvent acionarNoTempo; //Aciona as funções quando iniciar a contagem
    public UnityEvent desacionarNoTempo; //Desaciona as funções quando terminar a contagem
    private float tempoInicial; //Armazena a info do tempo inicial para poder resetar depois
    private float tempoAtual; //Armazena a info do tempo atual
    private bool tempoAtivo; //Informa se a contagem do tempo está ativa
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtTemporizador.text = $"{tempo}";
        tempoInicial = tempo;
    }

    // Update is called once per frame
    void Update()
    {
        //verificar se pode contar o tempo
        if(tempoAtivo == true)
        {
            //contar o tempo
            tempo = tempoAtual - Time.timeSinceLevelLoad; //310 - 310 = 0

            //Atualizar o texto
            txtTemporizador.text = $"{(int)tempo}";

            //verificar se o tempo acabou
            if(tempo <= 0)
            {
                //Desacionar as funcoes
                Desacionar();
            }
        }
    }

    public void Acionar()
    {
        //Acionar apenas se o tempo estiver desativado
        if (tempoAtivo == true) return;

        //Atualizar o tempo para poder contar
        tempoAtual = Time.timeSinceLevelLoad + tempoInicial; // 300 + 10 = 310

        //Ativar o tempo
        tempoAtivo = true;

        //Executar os eventos
        acionarNoTempo.Invoke();
    }

    public void Desacionar()
    {
        //Desativar a contagem do tempo
        tempoAtivo = false;
        //Atualizar o tempo para contar novamente
        txtTemporizador.text = $"{tempoInicial}";

        //Executar os eventos
        desacionarNoTempo.Invoke();
    }
}
