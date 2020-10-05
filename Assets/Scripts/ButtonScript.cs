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
