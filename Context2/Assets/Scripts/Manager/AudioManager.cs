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

        sfxSource.clip = sfx[(int)audio];
        sfxSource.Play();
    }

    public void PlayBackground(BackgroundFragments backgroundIndex)
    {
        backgroundSource.clip = backgroundSound[(int)backgroundIndex];
        backgroundSource.Play();

    }
}
