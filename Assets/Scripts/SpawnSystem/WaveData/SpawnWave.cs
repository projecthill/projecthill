using System.Collections;
using System.Collections.Generic;

public class SpawnWave //clase SpawnWave
{
    public float startTime;
    public float timer;
    public float timeDelta;

    public string[] enemies; //array de enemigos

    public SpawnWave(float startTime, float timer, float timeDelta)
    {
        this.startTime = startTime;
        this.timer = timer;
        this.timeDelta = timeDelta;
    }

    public void AddEnemy (string enemy, int index)
    {
        enemies[index] = enemy;
    }

    public void Populate (string[] enemies) //método para poblar el array enemies con los enemigos del archivo XML
    {
        this.enemies = new string[enemies.Length];
        for (int i = 0; i < enemies.Length; i++ )
        {
            AddEnemy(enemies[i], i);
        }
    }


}


   
