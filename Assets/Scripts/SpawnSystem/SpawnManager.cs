using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<SpawnableEntity> spawnableEntities; //lista de elementos que van a spawnear
    static public SpawnManager instance;
           
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SpawnableEntity Search (string id) //id es el número de elemento que toca spawnear
    {
        return spawnableEntities.Find(entity => entity.id == id);
    }


}
