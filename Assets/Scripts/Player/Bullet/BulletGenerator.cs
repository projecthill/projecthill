using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour{

    public GameObject BulletPrefab;
    public float BulletSpace;
    public float CoolDown;
    public bool isOnCooldown;
    public Vector2 position { get { return transform.position; } }



    // Start is called before the first frame update
    void Start (){

    }

    // Update is called once per frame
    void Update (){
        if (isOnCooldown == false) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                isOnCooldown = true;
                StartCoroutine (Burst ());
            }
        }
        /*if (isOnCooldown == true) {
            StartCoroutine (CoolingDown ());
            
        }*/
    }


    void GenerateBullet (){
        Debug.Log ("PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
    }

    IEnumerator Burst (){
        GenerateBullet ();
        yield return new WaitForSeconds (BulletSpace);
        GenerateBullet ();
        yield return new WaitForSeconds (BulletSpace);
        GenerateBullet ();
        
        StartCoroutine (CoolingDown ());
    }
    IEnumerator CoolingDown (){
        yield return new WaitForSeconds (CoolDown);
        isOnCooldown = false;
    }
}
