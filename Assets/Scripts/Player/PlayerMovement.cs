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
        Debug.Log (transform.rotation.z);
        //Movimiento hacia arriba del cañon
        if (Input.GetKey (KeyCode.W) && transform.rotation.z < 0.25) {
            speed = 0.2f;
            Quaternion temp = transform.rotation;
            temp.z += speed * Time.deltaTime;
            transform.rotation = temp;
        }
        //Movimiento hacia abajo del cañon
        if (Input.GetKey (KeyCode.S) && transform.rotation.z > -0.25) {
            speed = -0.2f;
            Quaternion temp = transform.rotation;
            temp.z += speed * Time.deltaTime;
            transform.rotation = temp;
        }
    }
}
