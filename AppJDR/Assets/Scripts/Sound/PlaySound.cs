using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    public static PlaySound _Instance;
    [SerializeField] private List<AudioClip> listAudio;
    [SerializeField] private bool playMusicAwake;
    [SerializeField] private int idAwakeMusic;

    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        if (playMusicAwake)
            PlaySoundMusic(idAwakeMusic);
    }

    public void PlaySoundVoice(int id)
    {
        SoundManager._Instance.PlaySoundVoice(listAudio[id]);
    }

    public void PlaySoundUI(int id)
    {
        SoundManager._Instance.PlaySoundUI(listAudio[id]);

    }

    public void PlaySoundMusic(int id)
    {
        SoundManager._Instance.PlaySoundMusic(listAudio[id]);

    }

    public void PlaySoundVoice(AudioClip clip)
    {
        SoundManager._Instance.PlaySoundVoice(clip);
    }

    public void PlaySoundUI(AudioClip clip)
    {
        SoundManager._Instance.PlaySoundUI(clip);

    }

    public void PlaySoundMusic(AudioClip clip)
    {
        SoundManager._Instance.PlaySoundMusic(clip);
    }
}
