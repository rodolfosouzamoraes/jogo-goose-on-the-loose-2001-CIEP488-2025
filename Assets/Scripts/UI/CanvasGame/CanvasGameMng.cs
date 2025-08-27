using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PainelTopo PainelTopo;
    public static PainelFimDeJogo PainelFimDeJogo;
    //Singleton
    void Awake()
    {
        if (Instance == null)
        {
            PainelTopo = GetComponent<PainelTopo>();
            PainelFimDeJogo = GetComponent<PainelFimDeJogo>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private bool fimDeJogo;

    //Uma propriedade de acesso a variavel fim de jogo
    public bool FimDeJogo
    {
        get { return fimDeJogo; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DefinirFimDeJogo()
    {
        //Definir que o level foi completado
        fimDeJogo = true;

        //Exibir a tela de finalização
        PainelFimDeJogo.ExibirFimDeJogo();
    }
}
