using UnityEngine;

public class RotacionarCameraY : MonoBehaviour
{
    [SerializeField] float velocidadeRotacao;

    // Update is called once per frame
    void Update()
    {
        //Obter o input x do mouse
        float rotacaoY = Input.GetAxis("Mouse X") * velocidadeRotacao;

        //Rotacionar a camera
        transform.rotation *= Quaternion.Euler(0, rotacaoY, 0);

    }
}
