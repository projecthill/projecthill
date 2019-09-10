using System.Collections;
using System.Collections.Generic;

public class SpawnWave //clase SpawnWave
{
    public float startTime; //cuantos segundos se demora en salir el primer enemigo de la ola
    public float timer; //cuantos segundos se demora en salir el siguiente enemigo de la ola
    public float timeDelta; //cuantos segundos varia timer luego de que sale un enemigo en la misma oleada

    public string[] enemies; //array de enemigos

    public SpawnWave(float startTime, float timer, float timeDelta) //obtiene los valores de startTime, timer y timeDelta
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


   
