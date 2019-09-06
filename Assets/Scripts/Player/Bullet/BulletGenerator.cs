using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour{

    public GameObject BulletPrefab;
    public GameObject RayxorPrefab;
    public float BulletSpace;
    public float CoolDown;
    public bool isOnCooldown;
    public Vector2 position { get { return transform.position; } }

    public List<Sprite> bulletSprites;

    public bool withNormalWeapon = true;
    public bool withGrenadeLauncher;
    public bool withRPG;
    public bool withTrapLauncher;
    public bool withRayxor;

    public bool isRayxoring;

    // Start is called before the first frame update
    void Start (){

    }

    // Update is called once per frame
    void Update (){
        //permite cambiar de armas
        if (!isRayxoring) {
            if (Input.GetKeyDown (KeyCode.Alpha1)) {
                withNormalWeapon = true;
                withGrenadeLauncher = false;
                withRPG = false;
                withTrapLauncher = false;
                withRayxor = false;
            } else if (Input.GetKeyDown (KeyCode.Alpha2)) {
                withNormalWeapon = false;
                withGrenadeLauncher = true;
                withRPG = false;
                withTrapLauncher = false;
                withRayxor = false;
            } else if (Input.GetKeyDown (KeyCode.Alpha3)) {
                withNormalWeapon = false;
                withGrenadeLauncher = false;
                withRPG = true;
                withTrapLauncher = false;
                withRayxor = false;
            } else if (Input.GetKeyDown (KeyCode.Alpha4)) {
                withNormalWeapon = false;
                withGrenadeLauncher = false;
                withRPG = false;
                withTrapLauncher = true;
                withRayxor = false;
            } else if (Input.GetKeyDown (KeyCode.Alpha5)) {
                withNormalWeapon = false;
                withGrenadeLauncher = false;
                withRPG = false;
                withTrapLauncher = false;
                withRayxor = true;
            }
        }

        if (isOnCooldown == false) {//Permite o impide disparar
            if (Input.GetKeyDown (KeyCode.Space)) {
                isOnCooldown = true;
                StartCoroutine (Burst ());
            }
        }
    }


    void GenerateNormalBullet (){//Genera la bala y le da direccion
        Debug.Log ("PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer> ().color = Color.blue;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 12.5f;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[0];
        bullet.tag = "NormalBullet";
        CoolDown = 0.5f;
    }
    void GenerateGrenadeBullet (){
        Debug.Log ("BIG PUM!");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer> ().color = Color.green;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 10;
        bullet.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[1];
        bullet.tag = "Grenade";
        CoolDown = 1;
    }
    void GenerateTrapBullet (){
        Debug.Log ("LaunchingTrap");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer> ().color = Color.red;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 7;
        bullet.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[3];
        bullet.tag = "TrapBullet";
        CoolDown = 2;
    }

    void GenerateRPGBullet (){
        Debug.Log ("KAAAABBBBBBOOOOOOMMMM");
        GameObject bullet = Instantiate (BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer> ().color = Color.black;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 7.5f;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[2];
        bullet.tag = "RPG";
        CoolDown = 2.5f;
    }

    Transform GenerateLayzorBullet ()
    {//Genera la bala y le da direccion
        Debug.Log ("RAYUM!");
        GameObject bullet = Instantiate (RayxorPrefab, position, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer> ().color = Color.blue;
        bullet.GetComponent<SpriteRenderer> ().sortingOrder = 100;
        bullet.GetComponent<LinealBullet> ().direction = transform.up;
        bullet.GetComponent<LinealBullet> ().speed = 0;
        bullet.GetComponent<Transform> ().up = transform.up;
        bullet.GetComponent<Transform> ().parent = transform;
        //bullet.GetComponent<SpriteRenderer> ().sprite = bulletSprites[0];
        bullet.tag = "NormalBullet";
        CoolDown = 0.5f;
        isRayxoring = true;
        return bullet.transform;
    }
    IEnumerator Burst (){//Rafaga de disparo
        if (withNormalWeapon == true) {
            GenerateNormalBullet ();
            yield return new WaitForSeconds (BulletSpace);
            GenerateNormalBullet ();
            yield return new WaitForSeconds (BulletSpace);
            GenerateNormalBullet ();
        } else if (withGrenadeLauncher == true){
            GenerateGrenadeBullet ();

        }else if(withRPG == true) {
            GenerateRPGBullet ();
        }else if (withTrapLauncher == true) {
            GenerateTrapBullet ();
        } else if (withRayxor == true) {
            Transform rayxorBullet = GenerateLayzorBullet ();
            float timer = 1;
            while (timer > 0) {
                timer -= Time.deltaTime;
                RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up);
                float scaleSize = 10;
                if (hit) {
                    scaleSize = hit.distance / 15;
                }
                Vector3 scale = rayxorBullet.localScale;
                scale.y = scaleSize;
                rayxorBullet.localScale = scale;
                yield return null;
            }
            Destroy (rayxorBullet.gameObject);
            isRayxoring = false;
        }
        StartCoroutine (CoolingDown ());
    }

    

    IEnumerator CoolingDown (){//Cooldown del disparo
        yield return new WaitForSeconds (CoolDown);
        isOnCooldown = false;
        CoolDown = 0;
    }
}
