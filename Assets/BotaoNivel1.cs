using UnityEngine;
using UnityEngine.UI;

public class BotaoNivel1 : MonoBehaviour
{
    [SerializeField] int idNivel;
    [SerializeField] Image imgOvoFinal;
    [SerializeField] Image imgGansoFinal;
    [SerializeField] Sprite[] sptsOvos;
    [SerializeField] Sprite[] sptsGanso;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obter o ganso e o ovo final
        int iconeGansoFinal = DBMng.ObterGansoFinalLevel(idNivel);
        int iconeOvoFinal = DBMng.ObterOvoFinalLevel(idNivel);

        imgOvoFinal.gameObject.SetActive(!(iconeOvoFinal == 4 || iconeOvoFinal == 0));
        imgGansoFinal.gameObject.SetActive(!(iconeGansoFinal == 4 || iconeGansoFinal == 0));

        //Colocar a imagem no sprite
        imgGansoFinal.sprite = sptsGanso[iconeGansoFinal];
        imgOvoFinal.sprite = sptsOvos[iconeOvoFinal];
    }
}
