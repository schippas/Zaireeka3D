using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio;
using NAudio.Wave;

public class AudioSrc : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

    void Start()
    {
      //  var inputReader = new AudioFileReader("./Source 1/Audio Test");
       // var mono = new StereoToMonoProvider16(inputReader);
        //mono.LeftVolume = 0.0f; // discard the left channel
        //mono.RightVolume = 1.0f; // keep the right channel

        //WaveFileWriter.CreateWaveFile("./Source 1/Audio Test R.wav", mono);

        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.panStereo = -1; 
       // AudioClip music = (AudioClip)Resources.Load("./Source 1/Audio Test R");
        //m_MyAudioSource.clip = music;
        //Ensure the toggle is set to true for the music to play at start-up
        m_Play = true;
    }

    void Update()
    {
        //Check to see if you just set the toggle to positive
        if (m_Play == true && m_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource component
            m_MyAudioSource.Play();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio
            m_MyAudioSource.Stop();
            //Ensure audio doesn’t play more than once
            m_ToggleChange = false;
        }
    }

    void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;
        }
    }
}