using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour{


    // Start is called before the first frame update
    void Start(){
        Destroy(gameObject.GetComponent<CircleCollider2D>(), 0.3f);
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update(){

    }

    void OnTriggerStay2D(Collider2D other){
        if (gameObject.CompareTag("GrenadeExplosion") && other.CompareTag("Enemy")){
            other.gameObject.GetComponent<EnemyParent>().TakeDamage(1);
        }else if (gameObject.CompareTag("RPGExplosion") && other.CompareTag("Enemy")){
            other.gameObject.GetComponent<EnemyParent>().TakeDamage(2);
        }
    }
}
