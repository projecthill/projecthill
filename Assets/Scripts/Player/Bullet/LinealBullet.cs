using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinealBullet : MonoBehaviour{

    public int speed = 2;
    public Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
