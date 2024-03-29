﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealBullet : MonoBehaviour{
    public float speed = 2;
    public Vector3 direction = Vector3.right;

    public int damage = 10; //valor de daño de esta bala

    public Vector2 position;
    public GameObject ExplosionPrefab;
    public GameObject GrenadeExplosionPrefab;
    public GameObject MineTrap;


    // Start is called before the first frame update
    void Start (){

    }

    // Update is called once per frame
    void Update (){ //Movimiento y deteccion de posicion de la bala
        transform.Translate (direction * speed * Time.deltaTime, Space.World);
        position = transform.position;
        if(gameObject.tag == "Grenade") {
            Quaternion temp = transform.rotation;
            temp.z = speed * Time.deltaTime;
            transform.rotation = temp;
        }
    }


    void OnTriggerEnter2D (Collider2D other){//destruye a un enemigo al tener contacto con él
        EnemyParent enemy = other.gameObject.GetComponent<EnemyParent> ();
        if (enemy) {
            switch (gameObject.tag) {
                case "NormalBullet":
                    enemy.TakeDamage (2);
                    break;
                case "Grenade":
                    enemy.TakeDamage (1);
                    break;
                case "RPG":
                    enemy.TakeDamage (5);
                    break;
                case "TrapBullet":
                    enemy.TakeDamage(1);
                    break;
                case "Rayxor":
                    enemy.TakeDamage(2);
                    break;
            }
        }

        if (other.CompareTag ("Enemy") || other.CompareTag ("Floor")) {//Detecta colisiones y empieza la explosion
            if (gameObject.CompareTag ("Grenade")) {
                GrenadeExplosion ();
                Destroy(gameObject);
            } else if (gameObject.CompareTag ("RPG")) {
                Explode ();
                Destroy(gameObject);
            } else if (gameObject.CompareTag ("TrapBullet")) {
                Mine ();
                Destroy(gameObject);
            }else if (gameObject.CompareTag("NormalBullet")) {
                Destroy(gameObject);
            }
            
        }
    }
    void Explode (){//Genera el area de explosion
        Debug.Log ("KABOOOM!!!!");
        GameObject explosion = Instantiate (ExplosionPrefab, position, Quaternion.identity);
    }

    void GrenadeExplosion(){
        Instantiate(GrenadeExplosionPrefab, position, Quaternion.identity);
    }

    void Mine (){//Genera el area de explosion
        Debug.Log ("Pup");
        GameObject instalingMine = Instantiate (MineTrap, position, Quaternion.identity);
    }
}
