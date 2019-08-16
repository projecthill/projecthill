using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public float speed = 0;
   


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        //Movimiento hacia arriba del cañon
        if (Input.GetKey (KeyCode.W)) {
            speed = 0.2f;
            Quaternion temp = transform.rotation;
            temp.z += speed * Time.deltaTime;
            transform.rotation = temp;
            if (transform.rotation.z >= 45) {
                speed = 0;
            }
        }
        //Movimiento hacia abajo del cañon
        if (Input.GetKey (KeyCode.S)) {
            speed = -0.2f;
            Quaternion temp = transform.rotation;
            temp.z += speed * Time.deltaTime;
            transform.rotation = temp;
        }
    }
}
