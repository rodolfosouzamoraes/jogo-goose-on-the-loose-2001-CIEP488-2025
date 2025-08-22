using UnityEngine;

public class RotacionarConstantementeNoEixo : MonoBehaviour
{
    [SerializeField] Vector3 eixos;
    [SerializeField] float velocidade;

    // Update is called once per frame
    void Update()
    {
        //Incrementar velocidade no eixo
        if(eixos.y != 0) 
            eixos.y += velocidade * Time.deltaTime;
        if(eixos.x != 0)
            eixos.x += velocidade * Time.deltaTime;
        if(eixos.z != 0)
            eixos.z += velocidade * Time.deltaTime;

        //Rotacionar o objeto
        transform.rotation = Quaternion.Euler(eixos.x, eixos.y, eixos.z);
    }
}
