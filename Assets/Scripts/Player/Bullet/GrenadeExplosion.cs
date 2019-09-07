using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour{


    // Start is called before the first frame update
    void Start(){
        Destroy (gameObject.GetComponent<CircleCollider2D>(), 0.2f);
        Destroy (gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update(){
        
    }

}
