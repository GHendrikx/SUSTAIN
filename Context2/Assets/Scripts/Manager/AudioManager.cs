using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sfx;
    [SerializeField]
    private AudioClip[] backgroundSound;
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioSource backgroundSource;

    public void PlaySFX(SFXFragments audio)
    {
        if (audio == SFXFragments.none)
            return;

        sfxSource.clip = sfx[(int)audio-1];
        sfxSource.Play();
    }

    public void PlayBackground(BackgroundFragments backgroundIndex)
    {
        if (backgroundIndex == BackgroundFragments.none)
            return;

        backgroundSource.clip = backgroundSound[(int)backgroundIndex-1];
        backgroundSource.Play();

    }
}
