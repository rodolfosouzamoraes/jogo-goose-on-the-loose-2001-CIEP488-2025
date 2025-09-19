using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PainelTopo PainelTopo;
    public static PainelFimDeJogo PainelFimDeJogo;
    public static PainelTeleporte PainelTeleporte;
    public static PainelVidaPlayer PainelVidaPlayer;
    public static PainelGameOver PainelGameOver;
    //Singleton
    void Awake()
    {
        if (Instance == null)
        {
            PainelTopo = GetComponent<PainelTopo>();
            PainelFimDeJogo = GetComponent<PainelFimDeJogo>();
            PainelTeleporte = GetComponent<PainelTeleporte>();
            PainelVidaPlayer = GetComponent<PainelVidaPlayer>();
            PainelGameOver = GetComponent<PainelGameOver>();    
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
        set { fimDeJogo = value; }
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
