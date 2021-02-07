using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//www.youtube.com/watch?v=o0j7PdU88a4 for timer

public class Countdown : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTime = 100f;
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
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
