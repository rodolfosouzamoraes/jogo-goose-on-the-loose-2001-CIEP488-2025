using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotaoNivel1 : MonoBehaviour
{
    [SerializeField] int idNivel;
    [SerializeField] Image imgOvoFinal;
    [SerializeField] Sprite[] sptsOvos;
    [SerializeField] GameObject iconMoeda;
    [SerializeField] TextMeshProUGUI txtMoedas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int iconeOvoFinal = DBMng.ObterOvoFinalLevel(idNivel);

        imgOvoFinal.color = iconeOvoFinal == 4 || iconeOvoFinal == 0 ? Color.black : Color.white;
        txtMoedas.text = $"${DBMng.ObterMoedasLevel(idNivel)}";

        imgOvoFinal.sprite = sptsOvos[iconeOvoFinal];
    }
}
