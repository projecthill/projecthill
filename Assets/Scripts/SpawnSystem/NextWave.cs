using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NextWave : MonoBehaviour
{
    public float timeStart = 60;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Next wave starts in: " + timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = "Next wave starts in: " + Mathf.Round(timeStart).ToString();
    }
}
