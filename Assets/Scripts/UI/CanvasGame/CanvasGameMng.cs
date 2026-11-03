using UnityEngine;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;
    public static PainelTopo PainelTopo;
    public static PainelFimDeJogo PainelFimDeJogo;
    public static PainelTeleporte PainelTeleporte;
    public static PainelVidaPlayer PainelVidaPlayer;
    public static PainelGameOver PainelGameOver;
    public static GerenciadorMenusGameplay GerenciadorUI;
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
            GerenciadorUI = GetComponentInChildren<GerenciadorMenusGameplay>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private bool fimDeJogo;
    public DanoPlayer DanoPlayer;

    //Uma propriedade de acesso a variavel fim de jogo
    public bool FimDeJogo
    {
        get { return fimDeJogo; }
        set { fimDeJogo = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ocultar a tela de loading
        CanvasLoadingMng.Instance.OcultarTela();
        AudioMng.Instance.PlayAudioMusic(1);
        AtualizarVolumes();

        DanoPlayer = FindFirstObjectByType<DanoPlayer>();
    }

    public void DefinirFimDeJogo()
    {
        //Definir que o level foi completado
        fimDeJogo = true;

        //Exibir a tela de finalização
        PainelFimDeJogo.CalcularPontosLevel(
            PainelTopo.TotalMoedasLevel,
            PainelTopo.MoedasColetadas,
            PainelTopo.OvosColetados
        );

        GerenciadorUI.MostrarVitoria();
    }

    private void AtualizarVolumes()
    {
        //Obter os volumes da memoria e atualizar no audiomng
        Volume volume = DBMng.GetVolume();
        AudioMng.Instance.MudarVolume(volume);
    }
}
