using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Music")]
    [SerializeField][Range(0f, 1f)] private float musicVolume = 0.3f;
    [SerializeField][Min(0f)] private float musicFadeDuration;
    private AudioSource musicAudioSource;

    [Header("SFX")]
    [SerializeField][Range(0f, 1f)] private float sfxVolume = 0.5f;
    private List<AudioSource> sfxAudioSources;

    bool isFirst = true;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        DontDestroyOnLoad(this);

        List<AudioSource> allAudioSources = new();
        GetComponentsInChildren<AudioSource>(true, allAudioSources);

        musicAudioSource = allAudioSources[0];

        sfxAudioSources = new();
        sfxAudioSources = allAudioSources;
        sfxAudioSources.RemoveAt(0);

        musicAudioSource.volume = musicVolume;
        foreach (var source in sfxAudioSources)
        {
            source.volume = sfxVolume;
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        int i = 0;
        while (sfxAudioSources[i].isPlaying)
        {
            i++;
        }
        sfxAudioSources[i].PlayOneShot(sfx);
    }

    public void PlayMusic(AudioClip music)
    {
        StartCoroutine(FadeOutMusic(music));
    }

    IEnumerator FadeOutMusic(AudioClip music)
    {

        if (!isFirst) 
        { 
            float timer = musicFadeDuration;
            while (timer > 0)
            {
                timer -= Time.fixedDeltaTime;
                musicAudioSource.volume = Mathf.Clamp(Mathf.Lerp(musicVolume, 0f, timer / musicFadeDuration), 0f, 1f);
                yield return Time.fixedDeltaTime;
            }
            musicAudioSource.Stop();
            // yield return new WaitForSeconds(0.25f);
        }
        isFirst = false;
        musicAudioSource.clip = music;
        musicAudioSource.Play();
    }
}
