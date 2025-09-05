using UnityEngine;

public class MoverParaFrente : MonoBehaviour
{
    [SerializeField] float velocidade;

    // Update is called once per frame
    void Update()
    {
        //Mover constantemente para frente
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }
}
