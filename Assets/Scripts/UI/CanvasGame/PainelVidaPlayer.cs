using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PainelVidaPlayer : MonoBehaviour
{
    [SerializeField] GameObject pnlVidaPlayer;
    [SerializeField] GameObject[] vidas;
    [SerializeField] Slider sldStamina;
    bool estaRestaurandoStamina = false;
    Coroutine coroutine;
    private void Start()
    {
        sldStamina.maxValue = 100;
        sldStamina.value = 100;
    }

    public void AtualizarVidaUI(int totalVidaPlayer)
    {
        //Ocultar todas as vidas para ativar apenas a quantidade de vidas correta
        for(int i = 0; i < vidas.Length; i++)
        {
            vidas[i].GetComponent<RawImage>().color = Color.black;
        }

        if (totalVidaPlayer !=0) {
            //Exibir a quantidade de vidas disponiveis
            for (int i = 0; i < totalVidaPlayer; i++)
            {
                vidas[i].GetComponent<RawImage>().color = Color.white;
            }
        }
    }

    public bool TemStamina()
    {
        estaRestaurandoStamina = false;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RestaurarStamina());

        if (sldStamina.value <= 0)
        {
            sldStamina.value = 0;
            return false;
        }
        else
        {
            sldStamina.value -= Time.deltaTime * 15;
            return true;
        }
    }

    private void Update()
    {
        if(estaRestaurandoStamina == true)
        {
            sldStamina.value += Time.deltaTime * 25;
            if (sldStamina.value >= sldStamina.maxValue)
            {
                sldStamina.value = sldStamina.maxValue;
                estaRestaurandoStamina = false;
            }
        }
    }

    IEnumerator RestaurarStamina()
    {
        yield return new WaitForSeconds(3f);
        estaRestaurandoStamina = true;
    }
}
