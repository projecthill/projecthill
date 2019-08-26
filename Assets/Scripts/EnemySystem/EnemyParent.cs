using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public int health = 10; //variable de puntos de vida de cada enemigo
    public Vector3 direction = Vector3.left; //dirección en la que se mueven los enemigos
    public float movementSpeed = 10f; //variable de ratio de movimiento de cada enemigo
    public float damageAmount = 10f; //variable de ratio de daño de cada enemigo le hará a la torre

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) //función daño recibido por enemigos, se resta el daño hecho por las balas de los puntos de vida del enemigo. Si los puntos de vida llegan a 0 el enemigo es destruído
    {
        health -= damage;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
