using UnityEngine;

public class AudioMng : MonoBehaviour
{
    public static AudioMng Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioSFX;

    [SerializeField] AudioClip[] musicas;

    public void PlayAudioSFX(AudioClip clip)
    {
        audioSFX.PlayOneShot(clip);
    }

    public void PlayAudioMusic(int music)
    {
        if(audioMusic.clip != musicas[music])
        {
            audioMusic.Stop();
            audioMusic.clip = musicas[music];
            audioMusic.Play();
        }
    }

}
