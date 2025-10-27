using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private GameObject cameraPlayer;
    
    public void ReposicionarCamera(float x, float z)
    {
        cameraPlayer.transform.position = new Vector3(x, cameraPlayer.transform.position.y, z);
    }
}
