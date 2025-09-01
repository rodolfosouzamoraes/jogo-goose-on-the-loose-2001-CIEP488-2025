using UnityEngine;

public class AbrirFecharPassagem : MonoBehaviour
{
    [SerializeField] GameObject objetoAMover;
    [SerializeField] Vector3 posicaoFechado;
    [SerializeField] Vector3 posicaoAberto;
    [SerializeField] float velocidade;
    [SerializeField] bool estaAberto = false;

    void Start()
    {
        //verificar a condição da variavel estaAberto para definir se o portão começa fechado ou aberto
        if (estaAberto == true) { 
            objetoAMover.transform.localPosition = posicaoAberto;
        }
        else
        {
            objetoAMover.transform.localPosition = posicaoFechado;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Verificar se vai abrir ou fechar o portão
        if(estaAberto == true)
        {
            //Abrir o portao
            objetoAMover.transform.localPosition = Vector3.MoveTowards(
                objetoAMover.transform.localPosition,
                posicaoAberto,
                velocidade * Time.deltaTime
            );
        }
        else
        {
            //Fechar portão
            objetoAMover.transform.localPosition = Vector3.MoveTowards(
                objetoAMover.transform.localPosition,
                posicaoFechado,
                velocidade * Time.deltaTime
            );
        }
    }

    public void AbrirPortao()
    {
        estaAberto = true;
    }

    public void FecharPortao()
    {
        estaAberto = false;
    }
}
