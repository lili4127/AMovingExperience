using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //load main scene based on scene index
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //load control scene based on scene index
    public void ShowControls()
    {
        SceneManager.LoadScene(2);
    }

    //load main menu scene based on scene index
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
