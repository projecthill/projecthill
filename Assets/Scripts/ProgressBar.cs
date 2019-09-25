using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider totalPeople;
    public float timeDelay;
    public float progress;
    public GameObject WIN;

    // Start is called before the first frame update
    void Start() {
        progress = timeDelay;
        
    }

    // Update is called once per frame
    void Update() {
        progress -= Time.deltaTime;

        totalPeople.value = progress;
        totalPeople.maxValue = 100f;
        totalPeople.minValue = 0f;

        OpenWIN();
    }

    public void OpenWIN(){

        if (progress <= 0){
            WIN.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
