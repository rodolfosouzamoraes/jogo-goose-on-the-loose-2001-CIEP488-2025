using UnityEngine;

public class PortalTeleporte : MonoBehaviour
{
    [SerializeField] GameObject portalParaTeletransportar;
    private bool portalAtivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        portalAtivo = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Verificar se o portal está ativo
        if (portalAtivo == true) return;

        if (other.gameObject.tag.Equals("Player"))
        {
            //Bloquear a movimentação do player
            other.gameObject.GetComponent<MoverPlayer>().BloquearMovimentacao();

            //Definir o portal como ativo
            portalAtivo=true;

            //Ativar o painel do teleporte
            CanvasGameMng.PainelTeleporte.AtivarPainelTeleporte();

            //Ativar o portal a ser teletransportado
            portalParaTeletransportar.GetComponent<PortalTeleporte>().AtivarPortal();
        }
    }

    public void AtivarPortal()
    {
        portalAtivo = true;
    }
}
