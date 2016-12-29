using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager _Instance;

    [SerializeField] private AudioSource MusicAudioSource;
    [SerializeField] private AudioSource VoiceAudioSource;
    [SerializeField] private AudioSource UIAudioSource;

    void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        else if (_Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        LoadSoundOption();
    }

    public void LoadSoundOption()
    {
        MusicAudioSource.volume = OptionsManager._Instance.soundOption.MusicVolume;
        VoiceAudioSource.volume = OptionsManager._Instance.soundOption.VoiceVolume;
        UIAudioSource.volume = OptionsManager._Instance.soundOption.UIVolume;
    }

    public void PlaySoundUI(AudioClip clip)
    {
        UIAudioSource.Stop();
        UIAudioSource.clip = clip;
        UIAudioSource.Play();
    }

    public void PlaySoundMusic(AudioClip clip)
    {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void PlaySoundVoice(AudioClip clip)
    {
        VoiceAudioSource.Stop();
        VoiceAudioSource.clip = clip;
        VoiceAudioSource.Play();
    }
}
