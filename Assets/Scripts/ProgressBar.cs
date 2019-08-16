﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider TotalPeople;
    public float progress;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        TotalPeople.value = progress;
        TotalPeople.maxValue = 100f;
        TotalPeople.minValue = 0f;
    }
}
