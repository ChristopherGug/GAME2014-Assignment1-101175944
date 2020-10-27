/**********************************************************************************************
 * Name: "Christopher Gugelmeier"                                                             *
 * Student ID: "101175944"                                                                    *
 * File name: "KeepMusic"                                                                     *
 * Date last modified: "2020-10-21"                                                           *
 * Script Description: "This script is responsible for keeping the music through scenes"      *
 **********************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusic : MonoBehaviour
{
    private static KeepMusic audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (audioSource == null)
            audioSource = this;
        else
            Object.Destroy(gameObject);
    }
}
