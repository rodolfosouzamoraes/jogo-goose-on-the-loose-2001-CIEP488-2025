using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotaoNivel : MonoBehaviour
{
    [SerializeField] int idNivel;
    [SerializeField] GameObject cadeado;
    [SerializeField] Image imgOvoFinal;
    [SerializeField] Sprite[] sptsOvos;
    [SerializeField] TextMeshProUGUI txtNivel;
    private bool estaDesbloqueado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obter a info do botão bloqueado ou desbloqueado
        estaDesbloqueado = DBMng.ObterLevelDesbloqueado(idNivel);

        //verificar se está bloqueado
        cadeado.SetActive(!estaDesbloqueado);

        //Obter o ganso e o ovo final
        int iconeOvoFinal = DBMng.ObterOvoFinalLevel(idNivel);

        imgOvoFinal.color = iconeOvoFinal == 4 || iconeOvoFinal == 0 ? Color.black : Color.white;

        //Interromper o Start caso o level esteja bloqueado
        if (estaDesbloqueado == false) return;   

        //Colocar a imagem no sprite
        imgOvoFinal.sprite = sptsOvos[iconeOvoFinal];

        //Definir o texto do botão com o id do nivel
        txtNivel.text = $"{idNivel}";
    }
}
