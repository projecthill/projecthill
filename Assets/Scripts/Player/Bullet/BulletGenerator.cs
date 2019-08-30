using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour{

    public GameObject BulletPrefab;
    public float BulletSpace;
    public float CoolDown;
    public bool isOnCooldown;
    public Vector2 position { get { return transform.position; } }

    public bool withNormalWeapon = true;
    /*public bool withGrenadeLauncher;
    public bool withRPG;
    public bool withTrapLauncher;*/

    // Start is called before the first frame update
    void Start (){

    }

    // Update is called once per frame
    void Update (){
        if (Input.GetKeyDown (KeyCode.Alpha1)) {
            withNormalWeapon = true;
        } else if (Input.GetKeyDown (KeyCode.Alpha2)) {
            withNormalWeapon = false;
        }
        /*if (Input.GetKeyDown (KeyCode.Alpha2)) {
            withNormalWeapon = false;
            withGrenadeLauncher = true;
            withRPG = false;
            withTrapLauncher = false;
        }
        if (Input.GetKeyDown (KeyCode.Alpha3)) {
            withNormalWeapon = false;
            withGrenadeLauncher = false;
            withRPG = true;
            withTrapLauncher = false;
        }
        if (Input.GetKeyDown (KeyCode.Alpha4)) {
            withNormalWeapon = false;
            withGrenadeLauncher = false;
            withRPG = false;
            withTrapLauncher = true;
        }*/

        if (isOnCooldown == false) {//Permite o impide disparar
            if (Input.GetKeyDown (KeyCode.Space)) {
                isOnCooldown = true;
                StartCoroutine (Burst ());
            }
        }
    }


    void GenerateLinealBullet (){//Genera la bala y le da direccion
        Debug.Log ("PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
    }
    void GenerateFallingBullet ()
    {
        Debug.Log ("BIG PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 10;
        bullet.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
        bullet.tag = "Grenade";
    }
    /*void GenerateFallingBullet ()
    {//Genera la bala y le da direccion
        Debug.Log ("PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<FallingBullet> ().direction = transform.up;
    }*/

    IEnumerator Burst (){//Rafaga de disparo
        if (withNormalWeapon == true) {
            GenerateLinealBullet ();
            yield return new WaitForSeconds (BulletSpace);
            GenerateLinealBullet ();
            yield return new WaitForSeconds (BulletSpace);
            GenerateLinealBullet ();
        } else {
            GenerateFallingBullet ();
        }
        /*if (withGrenadeLauncher == true) {
            GenerateFallingBullet ();
        }*/
        StartCoroutine (CoolingDown ());
    }

    

    IEnumerator CoolingDown (){//Cooldown del disparo
        yield return new WaitForSeconds (CoolDown);
        isOnCooldown = false;
    }
}
