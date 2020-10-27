/********************************************************************************************************
 * Name: "Christopher Gugelmeier"                                                                       *
 * Student ID: "101175944"                                                                              *
 * File name: "TileController"                                                                          *
 * Date last modified: "2020-10-26"                                                                     *
 * Script Description: "This script is responsible for the behaviour of tiles, mainly changing color"   *
 ********************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public SpriteRenderer tileRenderer;
    public static AudioClip tapSound;
    static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeToBlack()
    {
        tileRenderer.material.color = Color.black;
    }

    public void ChangeToWhite()
    {
        tileRenderer.material.color = Color.white;
    }

    public bool CheckTapped(Vector3 touchLocation)
    {
        if (touchLocation.x > transform.position.x - (tileRenderer.bounds.size.x / 2) &&
            touchLocation.x < transform.position.x + (tileRenderer.bounds.size.x / 2) &&
            touchLocation.y > transform.position.y - (tileRenderer.bounds.size.y / 2) &&
            touchLocation.y < transform.position.y + (tileRenderer.bounds.size.y / 2))
        {
            if (tileRenderer.material.color == Color.black)
                audioSource.Play();
            return true;
        }

        return false;
    }
}
