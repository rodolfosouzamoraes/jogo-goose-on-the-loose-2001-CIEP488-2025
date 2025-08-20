using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float velocidade;

    // Update is called once per frame
    void Update()
    {
        //mover o objeto até o player
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.transform.position,
            velocidade * Time.deltaTime
        );
    }
}
