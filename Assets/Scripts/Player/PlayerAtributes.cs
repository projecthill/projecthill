using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAtributes : MonoBehaviour{

    // Atributos por ser manipulados por progresión del juego
    public static int playerHealth = 20;
    public static int money = 0;

    GameObject enemy;
    EnemyParent damage;
    EnemyParent enemyValue;

    public Text healthUI;
    public Text moneyUI;
    public Text TimeUI;

    public ProgressBar currentBar;

    // Start is called before the first frame update
    void Start()
    {
       
     

    }

    // Update is called once per frame
    void Update()
    {
        if (healthUI) healthUI.text = "Vida: " + playerHealth;
        if (moneyUI) moneyUI.text = "Dinero: $" + money;
        if (TimeUI) TimeUI.text = "Tiempo: " + (int) currentBar.progress;

    }

   

   

     

}
