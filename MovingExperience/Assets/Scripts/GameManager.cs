using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//www.youtube.com/watch?v=JivuXdrIHK0 for Pause Menu
public class GameManager : MonoBehaviour
{

    bool gameEnded;
    public float restartDelay;
    public HealthBar healthBar;

    public Text youLose;
    public Text youWin;

    public static bool gamePaused;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        restartDelay = 2f;
        healthBar.SetMaxHealth(100);
        youLose.gameObject.SetActive(false);
        youWin.gameObject.SetActive(false);
        pauseMenuUI.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void WinGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            youWin.gameObject.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    public void LoseGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            youLose.gameObject.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
