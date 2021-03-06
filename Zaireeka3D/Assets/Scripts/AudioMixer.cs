﻿/*
   Zaireeka3D
   author: Sam Chippas
   Copyright (c) 2019
   All Rights Reserved
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    public GameObject source;
    public GameObject timeSlider;
    public GameObject timeCount;
    public Text timeSet;
    public Dropdown files;
    public String audioPath;

    List<String> paths;
    private string[] wavPaths;
    private string[] mp3Paths;
    private string[] oggPaths;

    private void Start()
    {
        if (timeSlider)
        {
            setLength();
            paths = new List<String>();
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

        foreach (string c in paths)
        {
            files.options.Add(new Dropdown.OptionData() { text = System.IO.Path.GetFileName(c) });
        }
    }

    private void getAudioFiles()
    {
        string path = Application.dataPath + "/Resources/" + audioPath;
        wavPaths = Directory.GetFiles(@path, "*.wav");
        //mp3Paths = Directory.GetFiles(@path, "*.mp3");
        oggPaths = Directory.GetFiles(@path, "*.ogg");

        paths.Add("");

        foreach (string c in wavPaths)
        {
            paths.Add(c);
        }
        //foreach (string c in mp3Paths)
       // {
        //    paths.Add(c);
        //}
        foreach (string c in oggPaths)
        {
            paths.Add(c);
        }

    }

    public void changeFile()
    {

        StartCoroutine(GetAudioClip());
        IEnumerator GetAudioClip()
        {
            //note: doesn't work with file extension.
            string selection = System.IO.Path.GetFileName(paths[files.value]);
            selection = Application.dataPath + "/Resources/" + audioPath + selection;

            UnityWebRequest web = UnityWebRequestMultimedia.GetAudioClip(selection, AudioType.UNKNOWN);
            yield return web.SendWebRequest();
            AudioClip temp = DownloadHandlerAudioClip.GetContent(web);

            source.GetComponent<AudioSource>().clip = temp;
            setLength();
            //source.GetComponent<AudioSource>().clip.LoadAudioData();
        }
    }
}