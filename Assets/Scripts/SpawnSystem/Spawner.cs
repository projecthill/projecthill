using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq; //necesario para leer archivo XML
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public TextAsset spawnData; //para acceder al archivo XML spawnData
    Queue<SpawnWave> spawnWaves; //lista de oleadas que se encuentran en cola para ser creadas

    Queue<string> spawnQueue; //lista de enemigos que se encuentran en cola para ser instanciados
    int activeEntityLimit;
    public float spawnDelay;
    float currentTimer;
    float currentDelta;
    float variantTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnQueue = new Queue<string>();
        spawnWaves = new Queue<SpawnWave>(); 

        if (spawnData)
        {
            ParseData(spawnData.text);
        }

        FillQueue();

    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime; //currentTimer aumenta en Time.deltaTime
        ResetTimer(SpawnEntity);
    }

    void ResetTimer(Action action) //resetea el currentTimer para el próximo wave
    {
        if (currentTimer >= spawnDelay){
            action.Invoke();
            currentTimer = 0;
        }
    }

    void FillQueue () //rellena la lista de enemigos que corresponden a la oleada
    {
        SpawnWave wave = spawnWaves.Dequeue();
        foreach (string enemy in wave.enemies)
        {
            spawnQueue.Enqueue(enemy);
        }
        spawnDelay = wave.startTime;
        currentDelta = wave.timeDelta;
        variantTimer = wave.timer;
    }

    void ParseData (string textData)
    {
        XDocument xmlData = XDocument.Parse(textData); //permite leer el archivo XML WaveData

        foreach (XElement element in xmlData.Root.Elements())
        {
            float startTime = float.Parse(element.Attribute("startTime").Value); //obtine el atributo start time del elemento WaveData en el archivo XML
            float timer = float.Parse(element.Attribute("timer").Value);
            float timeDelta = float.Parse(element.Attribute("timeDelta").Value);
            SpawnWave wave = new SpawnWave(startTime, timer, timeDelta); //se crea oleada con los valores obtenidos

            List<string> enemies = new List<string>();
            foreach (XElement enemy in element.Element ("enemies").Elements ()) //obtine los enemigos que están incluidos en cada oleada
            {
                enemies.Add(enemy.Value);
            }

            wave.Populate(enemies.ToArray());

            spawnWaves.Enqueue(wave);
        }
    }

    void SpawnEntity()
    {
        if (spawnQueue.Count > 0) //si la cola de enemigos es mayor a 0 spawnear el siguiente enemigo
        {
            SpawnableEntity next = SpawnManager.instance.Search(spawnQueue.Dequeue());
            next.Create(transform.position, Quaternion.identity);
            variantTimer += currentDelta;
            spawnDelay = variantTimer;

            if (spawnQueue.Count <= 0 && spawnWaves.Count > 0) //si la cola de enemigos es menor o igual a cero y la lista de olas es mayor a cero, rellenar la lista de enemigos
            {
                FillQueue();
            }
        }
        else
        {
            Debug.LogWarning("No mas oleadas");
        }
    }

}
