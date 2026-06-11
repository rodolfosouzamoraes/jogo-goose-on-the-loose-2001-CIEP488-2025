using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    private AudioSource[] audioSources;// 0 - Local, 1 - Global
    [SerializeField] Transform transformPaiObjeto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void PlayAudioLocal(int clip) { audioSources[0].clip = clips[clip]; audioSources[0].Play();}

    public void PlayAudioGlobal(int clip) {
        AudioMng.Instance.PlayAudioSFX(clips[clip]);
    }
}
