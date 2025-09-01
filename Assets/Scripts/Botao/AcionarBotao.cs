using UnityEngine;
using UnityEngine.Events;

public class AcionarBotao : MonoBehaviour
{
    [SerializeField] Material materialOn; //Material para simbolizar que o botão foi ativado
    [SerializeField] Material materialOff; //Material para simbolizar que o botão foi desativado
    [SerializeField] GameObject tecla; //Tecla do botão
    [SerializeField] MeshRenderer meshTecla; //Pegar a referencia da "Pele" da tecla

    public UnityEvent ativarEventos; //Vai ativar todos os eventos programados
    public UnityEvent desativarEventos; //Vai desativar todos os eventos programados

    public void AtivarBotao()
    {
        //Executar os eventos
        ativarEventos.Invoke();
    }

    public void DesativarBotao()
    {
        //Executar os eventos
        desativarEventos.Invoke();
    }

    public void AtivarTecla()
    {
        //Mudar o material da tecla para ativada
        meshTecla.material = new Material(materialOn);
    }

    public void DesativarTecla()
    {
        //Mudar o material da tecla para desativada
        meshTecla.material = new Material(materialOff);
    }
}
