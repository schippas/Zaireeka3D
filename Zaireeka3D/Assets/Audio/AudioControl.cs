using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    private AudioSource[] allAudio;
    private int pauseAudio = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PauseAllAudio();
        }
        if (Input.GetKeyDown("r"))
        {
            StopAllAudio();
        }
    }

    //Pause all audio sources
    void PauseAllAudio()
    {
        allAudio = FindObjectsOfType(typeof(AudioSource)) 
            as AudioSource[];
        if (pauseAudio == 1)
        {
            foreach (AudioSource audio in allAudio)
            {
                audio.Play(0);
                pauseAudio = 0;
            }
        }
        else
        {
            foreach (AudioSource audio in allAudio)
            {
                audio.Pause();
                pauseAudio = 1;
            }
        }
    }

    //Stop all audio sources.
    void StopAllAudio()
    {
        allAudio = FindObjectsOfType(typeof(AudioSource))
            as AudioSource[];

        foreach (AudioSource audio in allAudio)
        {
                audio.Stop();
                pauseAudio = 1;
        }
    }
}
