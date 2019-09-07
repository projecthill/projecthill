using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtributes : MonoBehaviour{

    // Atributos por ser manipulados por progresión del juego
    public static int playerHealth = 20;
    public int money = 0;

    GameObject enemy;
    EnemyParent damage;


    // Start is called before the first frame update
    void Start()
    {
       
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) //Detecta colisión con enemigo
    {
        if (other.CompareTag("Enemy"))
        {
            DamagePlayer();
            Debug.Log("A la torre le queda " + playerHealth + " de vida");
        }
    }

    public void DamagePlayer()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        damage = enemy.GetComponent<EnemyParent>();
        playerHealth -= damage.enemyDamage;
    }
  

}
