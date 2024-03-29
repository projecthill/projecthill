﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public GameObject Panel;

    public float speed = 0;

    public List<Sprite> CanonSprites;

    public BulletGenerator Generator;
    public bool RayxorSlow { get { return Generator.isRayxoring; } }

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

        if (Input.GetKeyDown(KeyCode.T)){
            if (Panel != null){
                bool isActive = Panel.activeSelf;

                Panel.SetActive(!isActive);

                Time.timeScale = (!isActive) ? 0 : 1;
            }
        }

        //Debug.Log (transform.rotation.z);
        //Movimiento hacia arriba del cañon
        if (Input.GetKey (KeyCode.W) && transform.rotation.z < 0.25) {
            if (RayxorSlow == true) {
                speed = 0.05f;
            } else {
                speed = 0.2f;
            }

            Quaternion temp = transform.rotation;
            temp.z += speed * Time.deltaTime;
            transform.rotation = temp;
        }
        //Movimiento hacia abajo del cañon
        if (Input.GetKey (KeyCode.S) && transform.rotation.z > -0.25) {
            if (RayxorSlow == true) {
                speed = -0.05f;
            } else {
                speed = -0.2f;
            }
            Quaternion temp = transform.rotation;
            temp.z += speed * Time.deltaTime;
            transform.rotation = temp;
        }
        //if(Generator.isRayxoring = true)
    }
}
