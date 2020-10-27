/**********************************************************************************************
 * Name: "Christopher Gugelmeier"                                                             *
 * Student ID: "101175944"                                                                    *
 * File name: "GameController"                                                                *
 * Date last modified: "2020-10-26"                                                           *
 * Script Description: "This script is responsible for keeping track of time left and score"  *
 **********************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int score;
    public GameObject scoreUI;

    public float timeLeft = 30;
    public TextMeshProUGUI timeLeftUI;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        timeLeft = 30;
    }

    // Update is called once per frame
    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "GameOver")
        {
            scoreUI = GameObject.Find("/Canvas/FinalScore");
            scoreUI.GetComponent<TextMeshProUGUI>().text = "Final Score: " + score;
        }
        else if (currentScene == "GameScene")
        {
            scoreUI = GameObject.Find("/Canvas/Score");
            timeLeft -= Time.deltaTime;

            scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
            timeLeftUI.text = "Time Left: " + Mathf.RoundToInt(timeLeft);
        }
    }
}
