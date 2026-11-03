using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] GameObject[] Telas;
    [SerializeField] Slider sldVFX;
    [SerializeField] Slider sldMusic;
    private Volume volume;

    private void Start()
    {
        //Ocultar a tela de loading
        CanvasLoadingMng.Instance.OcultarTela();
        AudioMng.Instance.PlayAudioMusic(0);
        //Configurar painel audio
        ConfigurarPainelAudio();
    }

    public void CarregarLevel(int id)
    {
        //Verificar se o level pode ser carregado, se ele foi desbloqueado
        bool foiDesbloqueado = DBMng.ObterLevelDesbloqueado(id);

        if(foiDesbloqueado == true)
        {
            //Exibir a tela de loading
            CanvasLoadingMng.Instance.ExibirTela();

            //Carregar cena do level id
            SceneManager.LoadScene(id);
        }        
    }

    public void CarregarPrimeiroLevel()
    {
        //Exibir a tela de loading
        CanvasLoadingMng.Instance.ExibirTela();

        //Carregar cena do level id
        SceneManager.LoadScene(1);
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    private void ConfigurarPainelAudio()
    {
        //Obter os volumes salvos na memória
        volume = DBMng.GetVolume();

        //Atualizar os values dos slides dos volumes
        sldVFX.value = volume.vfx;
        sldMusic.value = volume.musica;

        //Atualizar os volumes no AudioMng
        AudioMng.Instance.MudarVolume(volume);
    }

    private void AtualizarVolumes()
    {
        //Obter o volume salvo
        volume = DBMng.GetVolume();

        //Atualizar no AudioMng
        AudioMng.Instance.MudarVolume(volume);
    }

    /// <summary>
    /// Método utilizado no slider do volume vfx
    /// </summary>
    public void MudarVolumeVFX()
    {
        //Salvar o novo volume
        DBMng.SetVolume(sldVFX.value, volume.musica);

        //Atualizar os volumes no audio mng
        AtualizarVolumes();
    }

    public void MudarVolumeMusica()
    {
        //Salvar o novo volume
        DBMng.SetVolume(volume.vfx, sldMusic.value);

        //Atualizar os volumes no audio mng
        AtualizarVolumes();
    }
}
