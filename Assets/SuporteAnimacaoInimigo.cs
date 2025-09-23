using UnityEngine;

public class SuporteAnimacaoInimigo : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayParado()
    {
        animator.SetBool("Parado", true);
        animator.SetBool("Correndo", false);
    }

    public void PlayCorrendo()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
