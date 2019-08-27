using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEntity : MonoBehaviour
{
    public string id;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
    }

    public void Create(Vector3 position, Quaternion rotation) //crear instancias de los enemigos
    {
        Instantiate(gameObject, position, rotation);
    }
}
