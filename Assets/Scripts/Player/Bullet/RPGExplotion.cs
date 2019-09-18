using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGExplotion : MonoBehaviour{

    public GameObject ExplosionPrefab;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Floor") || other.CompareTag("Enemy")) {
            Explosion();
            Destroy(gameObject);
        }
    }

    void Explosion() {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }
}
