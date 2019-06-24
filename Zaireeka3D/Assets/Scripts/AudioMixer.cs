using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMixer : MonoBehaviour
{
    public GameObject source;

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePlay()
    {
        if (source.GetComponent<AudioSource>().isPlaying)
        {
            source.GetComponent<AudioSource>().Pause();
        }
        else
        {
            source.GetComponent<AudioSource>().Play();
        }

    }


}