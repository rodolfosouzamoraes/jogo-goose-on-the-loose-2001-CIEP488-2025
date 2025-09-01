using UnityEngine;

public class TeclaBotao : MonoBehaviour
{
    private AcionarBotao acionarBotao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        acionarBotao = GetComponentInParent<AcionarBotao>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            acionarBotao.AtivarBotao();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            acionarBotao.DesativarBotao();
        }
    }
}
