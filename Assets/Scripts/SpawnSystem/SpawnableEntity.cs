using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEntity : MonoBehaviour
{
    public string id;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Create(Vector2 position, Quaternion rotation) //crear instancias de el enemigo que tiene este script
    {
        Instantiate(gameObject, position, rotation);
    }
}
