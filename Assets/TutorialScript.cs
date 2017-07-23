using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    public AudioClip startClip;
    public AudioClip instructionsClip;
    public GvrAudioSource audioSource;
    public float startDelay = 1.5f;

    void Start()
    {
        audioSource.clip = startClip;
        audioSource.PlayDelayed(startDelay);
    }

    public void Play()
    {
        if (isStartClipOn())
        {
            audioSource.clip = instructionsClip;
        }

        if (audioSource.clip.length == audioSource.time || audioSource.time < 1f)
            audioSource.Play();
        else
            audioSource.UnPause();
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void PlayOrPause()
    {

        if (audioSource.isPlaying)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }

    private bool isStartClipOn()
    {
        return audioSource.clip == startClip;
    }
}
