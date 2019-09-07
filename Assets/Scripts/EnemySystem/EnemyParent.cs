﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public int health = 10; //variable de puntos de vida de cada enemigo
    public int enemyDirection = 1; //dirección en la que se mueven los enemigos
    public float enemySpeed = 10f; //variable de ratio de movimiento de cada enemigo
    public int enemyDamage; //cantidad de daño de cada enemigo le hará a la torre

    public GameObject explosion;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D other) //enemigos se destruyen al colisionar con la torre
    {
        if (other.CompareTag("Turret"))
        {
            Debug.Log("La torre recibió daño");
            Explode();
        }
    }


    public void TakeDamage (int bulletDamage) //función daño recibido por enemigos, se resta el daño hecho por las balas de los puntos de vida del enemigo. Si los puntos de vida llegan a 0 el enemigo es destruído
    {
        health -= bulletDamage;
        
        if (health <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
