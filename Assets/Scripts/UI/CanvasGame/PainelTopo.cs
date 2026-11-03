using TMPro;
using UnityEngine;

public class PainelTopo : MonoBehaviour
{
    [SerializeField] GameObject pnlTopo;
    [SerializeField] TextMeshProUGUI txtMoeda;
    [SerializeField] TextMeshProUGUI txtTempo;
    [SerializeField] float tempoLevel = 90;
    private int moedasColetadas;
    private int totalMoedasLevel;

    public int MoedasColetadas
    {
        get { return moedasColetadas; }
    }
    public int TotalMoedasLevel
    {
        get { return totalMoedasLevel; }
    }

    [SerializeField] GameObject[] ovos;
    private int ovosColetados;
    public int OvosColetados
    {
        get { return ovosColetados; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moedasColetadas = 0;
        txtMoeda.text = $"x{moedasColetadas}";

        //Zerar os ovos
        ovosColetados = 0;
        //Ocultar os ovos da UI
        foreach(GameObject ovo in ovos)
        {
            ovo.SetActive(false);
        }

        //Encontra todas as moedas do level
        totalMoedasLevel = FindObjectsByType<ColetarMoeda>(FindObjectsSortMode.None).Length;
    }

    public void IncrementarMoeda()
    {
        moedasColetadas++;
        txtMoeda.text = $"x{moedasColetadas}";
    }

    public void IncrementarOvo()
    {
        ovosColetados++;
        //Exibir na UI os ovos coletados
        for(int i = 1; i <= ovosColetados; i++)
        {
            ovos[i-1].SetActive(true);
        }
    }

    private void Update()
    {
        if (CanvasGameMng.Instance.FimDeJogo == true) return;
        tempoLevel -= Time.deltaTime;
        if (tempoLevel <= 0)
        {
            tempoLevel = 0;
            CanvasGameMng.Instance.DanoPlayer.MatarPlayer();
        }
        txtTempo.text = $"{Mathf.RoundToInt(tempoLevel)}";
    }
}
