using UnityEngine;

public class RotacionarCameraX : MonoBehaviour
{
    [SerializeField] float velocidadeRotacao; //Velocidade de rotação
    [SerializeField] float limiteNegativoX;//Limite angular negativo em X
    [SerializeField] float limitePositivoX;//Limite angular positivo em X
    private float cameraAnguloX; //Armazenar o valor do angulo X da Camera

    // Update is called once per frame
    void Update()
    {
        //Obter o input Y do mouse
        cameraAnguloX += -Input.GetAxis("Mouse Y") * velocidadeRotacao;

        //Limitar a rotação em X
        cameraAnguloX = Mathf.Clamp(cameraAnguloX, limiteNegativoX, limitePositivoX);

        //Rotacionar a camera
        transform.localRotation = Quaternion.Euler(cameraAnguloX, 0, 0);
    }
}
