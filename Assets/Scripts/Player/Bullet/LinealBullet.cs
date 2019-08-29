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
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(direction * speed * Time.deltaTime);
        position = transform.position;
    }

    void OnTriggerEnter2D (Collider2D other) {//destruye a un enemigo al tener contacto con él
    
        if (other.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(gameObject.CompareTag("Grenade") && (other.CompareTag("Enemy") || other.CompareTag("Floor"))){
            Explode();
            Destroy(gameObject);
        }

    }
    void Explode(){
        Debug.Log("KABOOOM!!!!");
        GameObject explosion = Instantiate(ExplosionPrefab, position, Quaternion.identity);
        
    }

}
