using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// bar assets and code www.youtube.com/watch?v=BLfNP4Sc_iA&t=1056s

public class HealthBar : MonoBehaviour
{
    //health bar variables
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //set max health to an int
    public void SetMaxHealth(int maxH)
    {
        slider.maxValue = maxH;
        slider.value = maxH;

        fill.color = gradient.Evaluate(1f);
    }

    //subtract h health from current health, flash screen red, and call LoseGame is health is 0
    public void LoseHealth(int h)
    {
        slider.value -= h;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        FindObjectOfType<GameManager>().Hurt();

        if (slider.value <= 0)
        {
            FindObjectOfType<GameManager>().LoseGame();
        }
    }
}
