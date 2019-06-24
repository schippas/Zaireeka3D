using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    public GameObject source;
    public GameObject timeSlider;

    private void Start()
    {
        if (timeSlider)
        {
            setLength();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (source.GetComponent<AudioSource>().clip)
        {
            timeSlider.GetComponent<Slider>().value = source.GetComponent<AudioSource>().time;
        }
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

    public void setLength()
    {
        if (source.GetComponent<AudioSource>().clip)
        {
            timeSlider.GetComponent<Slider>().maxValue = source.GetComponent<AudioSource>().clip.length;
        }
    }


}