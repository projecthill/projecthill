using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealBullet : MonoBehaviour{
    public int speed = 2;
    public Vector3 direction = Vector3.right;

    public int damage = 10; //valor de daño de esta bala

    public Vector2 position;
    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start (){

    }

    // Update is called once per frame
    void Update (){ //Movimiento y deteccion de posicion de la bala
        transform.Translate (direction * speed * Time.deltaTime);
        position = transform.position;
    }

    void OnTriggerEnter2D (Collider2D other){//destruye a un enemigo al tener contacto con él
        EnemyParent enemy = other.gameObject.GetComponent<EnemyParent> ();
        if (enemy) {
            switch (gameObject.tag) {
                case "Untagged":
                    enemy.TakeDamage (2);
                    break;
                case "Grenade":
                    enemy.TakeDamage (10);
                    break;
            }
        }

        if (other.CompareTag ("Enemy") || other.CompareTag ("Floor")) {//Detecta colisiones y empieza la explosion
            if (gameObject.CompareTag ("Grenade")) {
                Explode ();
            }
            Destroy (gameObject);
        }
    }
    void Explode (){//Genera el area de explosion
        Debug.Log ("KABOOOM!!!!");
        GameObject explosion = Instantiate (ExplosionPrefab, position, Quaternion.identity);
    }
}
