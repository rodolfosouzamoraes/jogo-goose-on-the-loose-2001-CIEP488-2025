using System.Collections;
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

            //Chamar o teleporte
            StartCoroutine(Teleporte(other.gameObject));
        }
    }

    public void AtivarPortal()
    {
        portalAtivo = true;
    }

    public void DesativarPortal()
    {
        portalAtivo = false;
    }

    IEnumerator Teleporte(GameObject player)
    {
        yield return new WaitForSeconds(1.5f);
        TeleportarPlayer(player);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<MoverPlayer>().PermitirMovimentacao();
        portalParaTeletransportar.GetComponent <PortalTeleporte>().DesativarPortal();
        portalAtivo = false;
    }

    public void TeleportarPlayer(GameObject player)
    {
        //Enviar o jogador para a posição do outro portal
        player.transform.position = new Vector3(
            portalParaTeletransportar.transform.position.x,
            portalParaTeletransportar.transform.position.y + 1.44f,
            portalParaTeletransportar.transform.position.z
        );

        //Enviar a camera do jogador para o outro portal
        player.GetComponent<CameraPlayer>().ReposicionarCamera(
            portalParaTeletransportar.transform.position.x,
            portalParaTeletransportar.transform.position.z
        );
    }
}
