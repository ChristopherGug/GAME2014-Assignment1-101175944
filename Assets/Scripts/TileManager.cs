/**********************************************************************************************
 * Name: "Christopher Gugelmeier"                                                             *
 * Student ID: "101175944"                                                                    *
 * File name: "TileManager"                                                                   *
 * Date last modified: "2020-10-26"                                                           *
 * Script Description: "This script is responsible for the list of tiles and dealing with     *
 *                      all tiles at once"                                                    *
 **********************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard };

    public GameController gameController;

    public Difficulty difficulty;
    public List<GameObject> tiles;
    int scoreMultiplier;
    float timeToChange;
    float timer = 0;
    int tilesBlack;


    // Start is called before the first frame update
    void Start()
    {
        //Set difficulty of the game and settings
        if (difficulty == Difficulty.Easy)
        {
            scoreMultiplier = 1;
            timeToChange = 0.8f;
        }
        else if (difficulty == Difficulty.Medium)
        {
            scoreMultiplier = 2;
            timeToChange = 0.5f;
        }
        else if (difficulty == Difficulty.Hard)
        {
            scoreMultiplier = 3;
            timeToChange = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Player loses if all tiles are black
        if (tilesBlack == 16)
            SceneManager.LoadScene("GameOver");

        //Count towards the next tile pick
        timer += Time.deltaTime;
        if (timer >= timeToChange)
        {
            timer = 0;
            PickTile();
        }

        //Check if the player tapped
        CheckIfTapped();
    }

    //Pick a tile every x seconds depending on difficulty and change it to black
    void PickTile()
    {
        //Pick a random tile number
        int rand = Random.Range(0, 16);
        //Make sure the picked tile isnt already black and pick a new one if it is
        while (tiles[rand].GetComponent<TileController>().tileRenderer.material.color == Color.black)
            rand = Random.Range(0, 16);

        //Set the chosen tile to black
        tiles[rand].GetComponent<TileController>().ChangeToBlack();
        tilesBlack++;
    }

    //Get Touch input and check if the tapped tile is correct or not, adjust variables accordingly
    void CheckIfTapped()
    {
        //Get Touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

                for (int i = 0; i < tiles.Count; i++)
                {
                    //Tile tapped is correctly tapped
                    if (tiles[i].GetComponent<TileController>().tileRenderer.material.color == Color.black && 
                        tiles[i].GetComponent<TileController>().CheckTapped(worldTouch))
                    {
                        tiles[i].GetComponent<TileController>().ChangeToWhite();
                        tilesBlack--;
                        gameController.score += 3 * scoreMultiplier;
                        gameController.timeLeft += 0.5f;
                    }
                    //Tile is white
                    else if (tiles[i].GetComponent<TileController>().tileRenderer.material.color == Color.white &&
                             tiles[i].GetComponent<TileController>().CheckTapped(worldTouch))
                    {
                        SceneManager.LoadScene("GameOver");
                    }
                }
            }
        }
    }
}
