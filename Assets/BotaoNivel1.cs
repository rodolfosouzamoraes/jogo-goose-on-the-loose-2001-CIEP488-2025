using UnityEngine;
using UnityEngine.UI;

public class BotaoNivel1 : MonoBehaviour
{
    [SerializeField] int idNivel;
    [SerializeField] Image imgOvoFinal;
    [SerializeField] Sprite[] sptsOvos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int iconeOvoFinal = DBMng.ObterOvoFinalLevel(idNivel);

        imgOvoFinal.color = iconeOvoFinal == 4 || iconeOvoFinal == 0 ? Color.black : Color.white;

        imgOvoFinal.sprite = sptsOvos[iconeOvoFinal];
    }
}
