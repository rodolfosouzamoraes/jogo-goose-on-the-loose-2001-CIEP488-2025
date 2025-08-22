using TMPro;
using UnityEngine;

public class PainelTopo : MonoBehaviour
{
    [SerializeField] GameObject pnlTopo;
    [SerializeField] TextMeshProUGUI txtMoeda;
    private int moedasColetadas;

    [SerializeField] GameObject[] ovos;
    private int ovosColetados;
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
}
