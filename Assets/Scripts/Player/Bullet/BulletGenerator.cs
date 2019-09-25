using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour{

    public GameObject BulletPrefab;
    public GameObject RayxorPrefab;
    public GameObject RPGPrefab;
    public float BulletSpace;
    public Vector2 position { get { return transform.position; } }

    public List<Sprite> bulletSprites;

    public bool withNormalWeapon = true;
    public bool withGrenadeLauncher;
    public bool withRPG;
    public bool withTrapLauncher;
    public bool withRayxor;

    public bool isRayxoring;
    public bool isShooting;

    public List<float> CDs;
    public List<bool> ActiveCDs;

    /*public float CDNormalWeapon = 0;
    public float CDGrenadeLauncher = 0;
    public float CDRPG = 0;
    public float CDTrapLauncher = 0;
    public float CDRayxor = 0;*/

    /*public bool ActiveCDNormalWeapon;
    public bool ActiveCDGrenadeLauncher;
    public bool ActiveRPG;
    public bool ActiveCDTrapLauncher;
    public bool ActiveCDRayxor;*/

    // Start is called before the first frame update
    void Start (){
        CDs[0] = 0;
        CDs[1] = 0;
        CDs[2] = 0;
        CDs[3] = 0;
        CDs[4] = 0;

        ActiveCDs[0] = false;
        ActiveCDs[1] = false;
        ActiveCDs[2] = false;
        ActiveCDs[3] = false;
        ActiveCDs[4] = false;
    }

    // Update is called once per frame
    void Update (){



        //permite cambiar de armas
        if (!isShooting){
            if (!isRayxoring){
                if (Input.GetKeyDown(KeyCode.Alpha1)){
                    
                        withNormalWeapon = true;
                        withGrenadeLauncher = false;
                        withRPG = false;
                        withTrapLauncher = false;
                        withRayxor = false;
                    
                }
                if (StoreWeapons.Unlock2 == true)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                    {

                        {
                            withNormalWeapon = false;
                            withGrenadeLauncher = true;
                            withRPG = false;
                            withTrapLauncher = false;
                            withRayxor = false;
                        }
                    }
                }

                if (StoreWeapons.Unlock3 == true)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                    {

                        withNormalWeapon = false;
                        withGrenadeLauncher = false;
                        withRPG = true;
                        withTrapLauncher = false;
                        withRayxor = false;
                    }
                }

                if (StoreWeapons.Unlock4 == true)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha4))
                    {

                        withNormalWeapon = false;
                        withGrenadeLauncher = false;
                        withRPG = false;
                        withTrapLauncher = true;
                        withRayxor = false;
                    }
                }
                if (StoreWeapons.Unlock5 == true)
                {
                    if (Input.GetKeyDown(KeyCode.Alpha5))
                    {
                        withNormalWeapon = false;
                        withGrenadeLauncher = false;
                        withRPG = false;
                        withTrapLauncher = false;
                        withRayxor = true;
                    }
                }
            }
        }

        /*if (isOnCooldown == false) {//Permite o impide disparar
            if (Input.GetKeyDown (KeyCode.Space)) {
                isOnCooldown = true;
                StartCoroutine (Burst ());
            }
        }*/
        if (Input.GetKeyDown(KeyCode.Space)){
            if(ActiveCDs[0] == false && withNormalWeapon == true) {
                ActiveCDs[0] = true;
                CDs[0] = 1;
                StartCoroutine(Burst());
            }
            if (ActiveCDs[1] == false && withGrenadeLauncher == true){
                ActiveCDs[1] = true;
                CDs[1] = 1.5f;
                StartCoroutine(Burst());
            }
            if (ActiveCDs[2] == false && withRPG == true){
                ActiveCDs[2] = true;
                CDs[2] = 2;
                StartCoroutine(Burst());
            }
            if (ActiveCDs[3] == false && withTrapLauncher == true){
                ActiveCDs[3] = true;
                CDs[3] = 2;
                StartCoroutine(Burst());
            }
            if (ActiveCDs[4] == false && withRayxor == true){
                ActiveCDs[4] = true;
                CDs[4] = 4;
                StartCoroutine(Burst());
            }

        }

        if (CDs[0] > 0) {
            CDs[0] -= Time.deltaTime;
        } else if (CDs[0] < 0) {
            CDs[0] = 0;
            if (CDs[0] == 0){
                ActiveCDs[0] = false;
            }
        }

        if (CDs[1] > 0){
            CDs[1] -= Time.deltaTime;
        }else if (CDs[1] < 0){
            CDs[1] = 0;
            if (CDs[1] == 0){
                ActiveCDs[1] = false;
            }
        }

        if (CDs[2] > 0){
            CDs[2] -= Time.deltaTime;
        }else if (CDs[2] < 0){
            CDs[2] = 0;
            if (CDs[2] == 0){
                ActiveCDs[2] = false;
            }
        }

        if (CDs[3] > 0){
            CDs[3] -= Time.deltaTime;
        }else if (CDs[3] < 0){
            CDs[3] = 0;
            if (CDs[3] == 0){
                ActiveCDs[3] = false;
            }
        }

        if (CDs[4] > 0){
            CDs[4] -= Time.deltaTime;
        }else if (CDs[4] < 0){
            CDs[4] = 0;
            if (CDs[4] == 0){
                ActiveCDs[4] = false;
            }
        }

    }


    void GenerateNormalBullet (){//Genera la bala y le da direccion
        Debug.Log ("PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        //bullet.GetComponent<SpriteRenderer> ().color = Color.blue;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 12.5f;
        bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[0];
        bullet.tag = "NormalBullet";
        isShooting = true;
        
    }
    void GenerateGrenadeBullet (){
        Debug.Log ("BIG PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        //bullet.GetComponent<SpriteRenderer> ().color = Color.green;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 10;
        bullet.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
        bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[1];
        bullet.tag = "Grenade";
        
    }
    void GenerateTrapBullet (){
        Debug.Log ("LaunchingTrap");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        //bullet.GetComponent<SpriteRenderer> ().color = Color.red;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 7;
        bullet.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
        bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[3];
        bullet.tag = "TrapBullet";
        
    }

    void GenerateRPGBullet (){
        Debug.Log ("KAAAABBBBBBOOOOOOMMMM");
        GameObject bullet = Instantiate (RPGPrefab, position, Quaternion.identity);
        //bullet.GetComponent<SpriteRenderer> ().color = Color.black;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 7.5f;
        bullet.GetComponent<Transform> ().up = transform.up;
        bullet.GetComponent<Transform> ().parent = transform;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[2];
        bullet.tag = "RPG";
        
        //return bullet.transform;
    }

    Transform GenerateLayzorBullet ()
    {//Genera la bala y le da direccion
        Debug.Log ("RAYUM!");
        GameObject bullet = Instantiate (RayxorPrefab, position, Quaternion.identity);
        //bullet.GetComponent<SpriteRenderer> ().color = Color.blue;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 0;
        bullet.GetComponent<Transform> ().up = transform.up;
        bullet.GetComponent<Transform> ().parent = transform;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[0];
        bullet.tag = "Rayxor";
        
        isRayxoring = true;
        return bullet.transform;
    }

    IEnumerator Burst(){//Rafaga de disparo
        if (withNormalWeapon == true){
            GenerateNormalBullet();
            yield return new WaitForSeconds(BulletSpace);
            GenerateNormalBullet();
            yield return new WaitForSeconds(BulletSpace);
            GenerateNormalBullet();
            isShooting = false;
        }
        if (withGrenadeLauncher == true){
            GenerateGrenadeBullet();
        }
        if (withRPG == true){
            GenerateRPGBullet();
        }
        if (withTrapLauncher == true){
            GenerateTrapBullet();
        }
        if (withRayxor == true){
            Transform rayxorBullet = GenerateLayzorBullet();
            float timer = 1;
            while (timer > 0){
                timer -= Time.deltaTime;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
                float scaleSize = 0.3f;
                if (hit){
                    Debug.Log("Quemando");
                    scaleSize = hit.distance / 55;
                }
                Vector3 scale = rayxorBullet.localScale;
                scale.y = scaleSize;
                rayxorBullet.localScale = scale;
                yield return null;
            }
            Destroy(rayxorBullet.gameObject);
            isRayxoring = false;
        }
        
    }

    /*IEnumerator CoolingDown (){//Cooldown del disparo
        if (CDs[0] > 0){
            CDs[0] -= Time.deltaTime;
        }else if (CDs[0] < 0){
            CDs[0] = 0;
            if (CDs[0] == 0){
                ActiveCDs[0] = false;
            }
        }
        yield return null;
    }*/
}
