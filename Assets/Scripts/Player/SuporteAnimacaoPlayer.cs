using UnityEngine;

public class SuporteAnimacaoPlayer : MonoBehaviour
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
        animator.SetBool("Andando", false);
        animator.SetBool("Pulando", false);
    }

    public void PlayCorrendo()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", true);
        animator.SetBool("Andando", false);
        animator.SetBool("Pulando", false);
    }

    public void PlayAndando()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("Andando", true);
        animator.SetBool("Pulando", false);
    }

    public void PlayPulando()
    {
        animator.SetBool("Parado", false);
        animator.SetBool("Correndo", false);
        animator.SetBool("Andando", false);
        animator.SetBool("Pulando", true);
    }
}
