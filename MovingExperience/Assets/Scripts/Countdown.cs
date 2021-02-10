using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//www.youtube.com/watch?v=o0j7PdU88a4 for timer

public class Countdown : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTime = 120f;
    [SerializeField] Text countdownText;

    //set starting time to 120 seconds
    void Start()
    {
        currentTime = startingTime;
    }

    //update current time relative to deltaTime by 1 second. Stop time from going negative.
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            FindObjectOfType<GameManager>().LoseGame();
        }
    }
}
