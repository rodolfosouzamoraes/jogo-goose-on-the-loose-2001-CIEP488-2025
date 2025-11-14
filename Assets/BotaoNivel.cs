using UnityEngine;
using UnityEngine.UI;

public class BotaoNivel : MonoBehaviour
{
    [SerializeField] int idNivel;
    [SerializeField] GameObject cadeado;
    [SerializeField] Image imgOvoFinal;
    [SerializeField] Image imgGansoFinal;
    [SerializeField] Sprite[] sptsOvos;
    [SerializeField] Sprite[] sptsGanso;
    private bool estaDesbloqueado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obter a info do botão bloqueado ou desbloqueado
        estaDesbloqueado = DBMng.ObterLevelDesbloqueado(idNivel);

        //verificar se está bloqueado
        cadeado.SetActive(!estaDesbloqueado);
        imgOvoFinal.gameObject.SetActive(estaDesbloqueado);
        imgGansoFinal.gameObject.SetActive(estaDesbloqueado);

        //Interromper o Start caso o level esteja bloqueado
        if (estaDesbloqueado == false) return;

        //Obter o ganso e o ovo final
        int iconeGansoFinal = DBMng.ObterGansoFinalLevel(idNivel);
        int iconeOvoFinal = DBMng.ObterOvoFinalLevel(idNivel);

        //Colocar a imagem no sprite
        imgGansoFinal.sprite = sptsGanso[iconeGansoFinal];
        imgOvoFinal.sprite = sptsOvos[iconeOvoFinal];
    }
}
