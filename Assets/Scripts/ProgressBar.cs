using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider totalPeople;
    public float timeDelay;
    public float progress;

    // Start is called before the first frame update
    void Start() {
        progress = timeDelay;
    }

    // Update is called once per frame
    void Update() {

        progress -= Time.deltaTime;

        if(progress <= 0) {
            progress = timeDelay;
        }

        totalPeople.value = progress;
        totalPeople.maxValue = 100f;
        totalPeople.minValue = 0f;
    }
}
