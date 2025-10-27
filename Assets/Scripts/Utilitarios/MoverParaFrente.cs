using UnityEngine;

public class MoverParaFrente : MonoBehaviour
{
    [SerializeField] float velocidade;
    private bool movimentacaoHabilitada = true;
    // Update is called once per frame
    void Update()
    {
        //verificando se pode se mover
        if (movimentacaoHabilitada == false) return;
        //Mover constantemente para frente
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }

    public void InverterVelocidade()
    {
        velocidade *= -1f;
        movimentacaoHabilitada = true;
    }

    public void PararMovimentacao()
    {
        movimentacaoHabilitada = false;
    }
}
