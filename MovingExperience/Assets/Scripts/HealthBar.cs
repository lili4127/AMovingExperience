﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int maxH)
    {
        slider.maxValue = maxH;
        slider.value = maxH;

        fill.color = gradient.Evaluate(1f);
    }

    public void LoseHealth(int h)
    {
        slider.value -= h;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
