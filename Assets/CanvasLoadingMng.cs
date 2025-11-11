using UnityEngine;
using UnityEngine.UI;

public class CanvasLoadingMng : MonoBehaviour
{
    public static CanvasLoadingMng Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    [SerializeField] GameObject pnlLoading;
    [SerializeField] Image imgFundo;
    [SerializeField] Sprite[] imgsFundo;

    public void ExibirTela()
    {
        //Sortear um fundo para a tela
        int fundoSorteado = new System.Random().Next(0, imgsFundo.Length);

        //Atribuir o fundo sorteado na tela
        imgFundo.sprite = imgsFundo[fundoSorteado];

        //Exibir o painel de carregamento
        pnlLoading.SetActive(true);
    }

    public void OcultarTela()
    {
        //Ocultar o painel de carregamento
        pnlLoading.SetActive(false);
    }
}
