using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    public GameObject source;
    public GameObject timeSlider;
    public GameObject timeCount;
    public Text timeSet;
    public Dropdown files;
    public String audioPath;

    private string[] wavPaths;
    private string[] mp3Paths;
    private string[] oggPaths;

    private void Start()
    {
        if (timeSlider)
        {
            setLength();
            setFiles();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (source.GetComponent<AudioSource>().clip)
        {
            timeSlider.GetComponent<Slider>().value = source.GetComponent<AudioSource>().time;
            timeCount.GetComponent<Text>().text = source.GetComponent<AudioSource>().time.ToString();
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

    public void setTime()
    {
        source.GetComponent<AudioSource>().time = (float)Convert.ToDouble(timeSet.text);
    }

    public void setFiles()
    {
        getAudioFiles();
        files.options.Clear();
        foreach (string c in wavPaths)
        {
            files.options.Add(new Dropdown.OptionData() { text = System.IO.Path.GetFileName(c) });
        }
        foreach (string c in mp3Paths)
        {
            files.options.Add(new Dropdown.OptionData() { text = System.IO.Path.GetFileName(c) });
        }
        foreach (string c in oggPaths)
        {
            files.options.Add(new Dropdown.OptionData() { text = System.IO.Path.GetFileName(c) });
        }
    }

    private void getAudioFiles()
    {
        string path = Application.dataPath + audioPath;
        wavPaths = Directory.GetFiles(@path, "*.wav");
        mp3Paths = Directory.GetFiles(@path, "*.mp3");
        oggPaths = Directory.GetFiles(@path, "*.ogg");

    }

}