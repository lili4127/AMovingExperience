using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//www.youtube.com/watch?v=JivuXdrIHK0 for Pause Menu
public class GameManager : MonoBehaviour
{
    //game variables
    bool gameEnded;
    public float restartDelay;
    public HealthBar healthBar;

    public Text youLose;
    public Text youWin;

    public static bool gamePaused;
    public GameObject pauseMenuUI;
    public GameObject hurtUI;

    //set player health at the start of the game and remove unnecessary UI
    void Start()
    {
        gameEnded = false;
        restartDelay = 2f;
        healthBar.SetMaxHealth(100);
        youLose.gameObject.SetActive(false);
        youWin.gameObject.SetActive(false);
        pauseMenuUI.SetActive(false);
        hurtUI.SetActive(false);
        gamePaused = false;
        Time.timeScale = 1;
    }

    //activated when player's current platform is platform 8. Display win message and restart the game
    public void WinGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            youWin.gameObject.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    //activated when player's health is 0 or time has run out. Display lose message and restart the game
    public void LoseGame()
    {
        if (gameEnded == false)
        {
            gameEnded = true;
            youLose.gameObject.SetActive(true);
            Invoke("Restart", restartDelay);
        }
    }

    //flash blood on screen
    public void Hurt()
    {
        StartCoroutine(DisplayBlood(hurtUI, 0.1f));
    }

    //coroutine for displaying blood when player loses health
    public IEnumerator DisplayBlood(GameObject blood, float delay)
    {
        blood.SetActive(true);
        yield return new WaitForSeconds(delay);
        blood.SetActive(false);
    }

    //activated when restart button is pressed from pause menu
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    //activated when main menu button is pressed from pause menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //stop time and activate pause menu canvas
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    //resume time and deactivate pause menu canvas
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
