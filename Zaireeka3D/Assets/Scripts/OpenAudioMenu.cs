/*
   Zaireeka3D
   author: Sam Chippas
   Copyright (c) 2019
   All Rights Reserved
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenAudioMenu : MonoBehaviour
{

    public GameObject modalPanel;
    public GameObject player;
    //public GameObject source;
    bool active;

    //public GameObject volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        modalPanel.SetActive(active);
        //volumeSlider.GetComponent<Slider>().onValueChanged.Equals(source);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if (active)
            {
                active = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                player.GetComponent<RigidbodyFirstPersonController>().pause();

            }
            else
            {
                active = true;
                player.GetComponent<RigidbodyFirstPersonController>().pause();
            }

            modalPanel.SetActive(active);
        }
        if (active)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = active ? CursorLockMode.Locked : CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active)
            {
                player.GetComponent<RigidbodyFirstPersonController>().pause();
            }
            active = false;
            modalPanel.SetActive(active);
        }
    }
}
