﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SetupLocalPlayer:NetworkBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<CameraMove>().enabled = true;
            GetComponentInChildren<Camera>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
