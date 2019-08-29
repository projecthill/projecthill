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
    public bool withGrenadeLauncher;
    public bool withRPG;
    public bool withTrapLauncher;

    // Start is called before the first frame update
    void Start (){

    }

    // Update is called once per frame
    void Update (){
        if (Input.GetKeyDown(KeyCode.Alpha1))

        if (isOnCooldown == false) {//Permite o impide disparar
            if (Input.GetKeyDown (KeyCode.Space)) {
                isOnCooldown = true;
                StartCoroutine (Burst ());
            }
        }
    }


    void GenerateBullet (){//Genera la bala y le da direccion
        Debug.Log ("PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
    }

    IEnumerator Burst (){//Rafaga de disparo
        GenerateBullet ();
        yield return new WaitForSeconds (BulletSpace);
        GenerateBullet ();
        yield return new WaitForSeconds (BulletSpace);
        GenerateBullet ();
        
        StartCoroutine (CoolingDown ());
    }



    IEnumerator CoolingDown (){//Cooldown del disparo
        yield return new WaitForSeconds (CoolDown);
        isOnCooldown = false;
    }
}
