/*
   Zaireeka3D
   author: Sam Chippas
   Copyright (c) 2019
   All Rights Reserved
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : MonoBehaviour
{
    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}
