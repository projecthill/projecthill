using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBullet : MonoBehaviour{

    public bool Installed = false;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine (Installing ());
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.CompareTag ("Floor")) {
            
        }
    }

    IEnumerator Installing (){
        yield return new WaitForSeconds (0.2f);
        Installed = true;
    }
}
