using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAtributes : MonoBehaviour{

    // Atributos por ser manipulados por progresión del juego
    public static int playerHealth = 20;
    public int money = 0;

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
        if (moneyUI) moneyUI.text = "Dinero: " + money;
        if (TimeUI) TimeUI.text = "Tiempo: " + (int) currentBar.progress;

    }

    void OnTriggerEnter2D(Collider2D other) //Detecta colisión con enemigo
    {
        if (other.CompareTag("Enemy"))
        {
            DamagePlayer();
            Debug.Log("A la torre le queda " + playerHealth + " de vida");
        }
    }

    public void DamagePlayer() //se reduce la vida de la torre en la cantidad del daño del enemigo
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        damage = enemy.GetComponent<EnemyParent>();
        playerHealth -= damage.enemyDamage;
    }

    public void GainMoney() //incrementa el dinero del player en el valor de dinero del enemigo destruído
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyValue = enemy.GetComponent<EnemyParent>();
        money += enemyValue.enemyValue;
    }
  

}
