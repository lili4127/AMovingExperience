﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowControls()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
