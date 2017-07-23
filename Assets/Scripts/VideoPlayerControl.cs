using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerControl : MonoBehaviour {

    private GameObject pauseSprite;
    private GameObject playSprite;

    public VideoPlayer Player;

    // Use this for initialization
    void Start () {
        foreach(RawImage raw in GetComponentsInChildren<RawImage>(true)) {
            if (raw.gameObject.name == "play_text")
            {
                playSprite = raw.gameObject;
            }
            else if (raw.gameObject.name == "pause_text")
            {
                pauseSprite = raw.gameObject;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.isPrepared && !Player.isPlaying)
        {
            if((ulong)Player.frame == Player.frameCount)
            {
                Player.Stop();
            }
            
            playSprite.SetActive(true);
            pauseSprite.SetActive(false);
        }
	}

    public void PlayOrPause()
    {
        if (Player.isPlaying)
        {
            Pause();
        } else
        {
            Play();
        }
    }

    public void Play()
    {
        Player.Play();
        playSprite.SetActive(!Player.isPlaying);
        pauseSprite.SetActive(Player.isPlaying);
    }

    public void Pause()
    {
        Player.Pause();
        playSprite.SetActive(true);
        pauseSprite.SetActive(false);
    }

    public void Stop()
    {
        Player.Stop();
        playSprite.SetActive(true);
        pauseSprite.SetActive(false);
    }


}
