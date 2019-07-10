/*
   Zaireeka3D
   author: Sam Chippas
   Copyright (c) 2019
   All Rights Reserved
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{

    public GameObject helpPanel;
    private bool active;

    private void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            active = !active;
            helpPanel.SetActive(active);
        }
    }
}
