using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    float uiTimer;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUIValues()
    {

        if (uiTimer <= 0)
        {
            uiTimer = 0;
            textBox.text = "Waiting for current wave...";
        }
        else
        {
            uiTimer -= Time.deltaTime;
            textBox.text = "Next wave starts in: " + Mathf.Round(uiTimer).ToString();
        }
    }

}
