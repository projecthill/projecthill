﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;

    void Start ()
    {
        GameIsOver = false;
    }

    void Update ()
    {
        if (GameIsOver)
            return;

        if (PlayerAtributes.playerHealth <= 0) {
            EndGame ();
            
        }
    }

    void EndGame ()
    {
        GameIsOver = true;
        gameOverUI.SetActive (true);
    }

    public void WinLevel ()
    {
        GameIsOver = true;
        completeLevelUI.SetActive (true);
    }

    void Restart()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
