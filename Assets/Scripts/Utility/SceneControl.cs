﻿using GameUtilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
    
    // Load Scene: Cambia el juego de escena

    public void LoadScene(int index) {
        if (index < SceneManager.sceneCount && index >= 0) {
            SceneManager.LoadScene(index);
        }
    }
}