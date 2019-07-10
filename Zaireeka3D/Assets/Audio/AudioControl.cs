/*
   Zaireeka3D
   author: Sam Chippas
   Copyright (c) 2019
   All Rights Reserved
 */

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
        } else if (Input.GetKeyDown("r"))
        {
            StopAllAudio();
        } else if (Input.GetKeyDown("q"))
        {
            syncAudio();
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
                audio.time = 0; 
                pauseAudio = 1;
        }
    }

    //Sync up audio tracks
    void syncAudio()
    {
        allAudio = FindObjectsOfType(typeof(AudioSource))
            as AudioSource[];

        float sync = 0;

        foreach (AudioSource audio in allAudio)
        {
            audio.Pause();
            if(sync == 0)
            {
                sync = audio.time;
            }
            else
            {
                audio.time = sync;
            }
        }
        foreach (AudioSource audio in allAudio)
        {
            audio.Play(0);
            pauseAudio = 0;
        }
    }
}
