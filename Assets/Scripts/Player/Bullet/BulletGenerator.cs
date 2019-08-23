using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour {

    public GameObject BulletPrefab;
    public float fireRate = 2;
    public float cooldownTimer = 0;
    public bool isOnCooldown = false;
    public Vector2 position { get { return transform.position; }}

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            GenerateBullet();

        }
    }

    void GenerateBullet() {
        Debug.Log("PUM!");
        GameObject bullet = Instantiate(BulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<LinealBullet>().direction = transform.up;
    }
}
