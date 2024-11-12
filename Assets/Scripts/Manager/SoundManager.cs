using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>
{
    private List<AudioClip> audioClips;
    private AudioSource audioSource;

    public void Init()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds/");
        Functions.SortObject(clips);

        audioClips = clips.ToList();
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(Defines.SOUNDTYPE type)
    {
        audioSource.PlayOneShot(audioClips[(int)type]);
    }

    public void PlayBGM(Defines.SOUNDTYPE type, float volumeScale)
    {
        audioSource.Stop();
        audioSource.volume = volumeScale;
        audioSource.loop = true;
        audioSource.clip = audioClips[(int)type];
        audioSource.Play();
    }
}

