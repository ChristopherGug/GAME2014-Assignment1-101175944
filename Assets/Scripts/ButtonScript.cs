/**********************************************************************************************
 * Name: "Christopher Gugelmeier"                                                             *
 * Student ID: "101175944"                                                                    *
 * File name: "ButtonScript"                                                                  *
 * Date last modified: "2020-10-26"                                                           *
 * Script Description: "This script is responsible for the behaviour of each button"          *
 **********************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void ChangeScene()
    {
        if (this.gameObject.name == "TestButton")
            SceneManager.LoadScene("GameOver");
        else if (this.gameObject.name == "StartButton")
            SceneManager.LoadScene("GameScene");
        else if (this.gameObject.name == "InstructionsButton")
            SceneManager.LoadScene("InstructionsScene");
        else if (this.gameObject.name == "BackButton")
            SceneManager.LoadScene("MenuScreen");
        else if (this.gameObject.name == "PlayAgainButton")
            SceneManager.LoadScene("GameScene");
    }


}
