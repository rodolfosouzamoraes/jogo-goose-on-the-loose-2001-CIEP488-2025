using UnityEngine;
using UnityEngine.UIElements;

public class Patrulhar : MonoBehaviour
{
    [SerializeField] GameObject corpoPatrulheiro;
    [SerializeField] float velocidadeMovimento;
    [SerializeField] float velocidadeRotacao;
    [SerializeField] MoverParaFrente moverObjeto;
    private bool estaMovendo = true;
    private bool estaRotacionando = false;
    private float angulo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angulo = corpoPatrulheiro.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        Rotacionar();
    }

    private void Rotacionar()
    {
        if (estaRotacionando == false) return;
        Vector3 direcaoObjeto = corpoPatrulheiro.transform.forward;
        Vector3 rotacaoAlvo = Quaternion.Euler(0, angulo, 0) * Vector3.forward;
        Vector3 novaRotacao = Vector3.RotateTowards(
            direcaoObjeto,
            rotacaoAlvo,
            velocidadeRotacao * Time.deltaTime,
            0f
        );

        corpoPatrulheiro.transform.rotation = Quaternion.LookRotation(novaRotacao);

        float diferencaAngulo = Vector3.Angle(corpoPatrulheiro.transform.forward, rotacaoAlvo) * Mathf.Deg2Rad;

        if (diferencaAngulo <= 0.01f)
        {
            estaRotacionando = false;
            moverObjeto.InverterVelocidade();
        }
    }

    public void PermitirRotacionar()
    {
        angulo += 180;
        estaRotacionando = true;
        moverObjeto.PararMovimentacao();
    }
}
