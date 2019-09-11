using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public float speed = 0;

    public List<Sprite> CanonSprites;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown (KeyCode.Alpha1)) {
            gameObject.GetComponent<SpriteRenderer> ().sprite = CanonSprites[0];
        }else if (Input.GetKeyDown (KeyCode.Alpha2)) {
            gameObject.GetComponent<SpriteRenderer> ().sprite = CanonSprites[1];
        } else if (Input.GetKeyDown (KeyCode.Alpha3)) {
            gameObject.GetComponent<SpriteRenderer> ().sprite = CanonSprites[2];
        } else if (Input.GetKeyDown (KeyCode.Alpha4)) {
            gameObject.GetComponent<SpriteRenderer> ().sprite = CanonSprites[3];
        } else if (Input.GetKeyDown (KeyCode.Alpha5)) {
            gameObject.GetComponent<SpriteRenderer> ().sprite = CanonSprites[4];
        }

        //Debug.Log (transform.rotation.z);
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
