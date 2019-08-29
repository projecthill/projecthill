using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : EnemyParent
{
    int currentPathIndex = 0; //orden de puntos de movimiento
    public Vector3[] pathPoints; //array de puntos por los que se mueve el enemigo

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pathPoints[currentPathIndex], enemySpeed * Time.deltaTime); //movimiento de enemigo de punto a punto
        if (transform.position == pathPoints[currentPathIndex])
        {
            currentPathIndex += enemyDirection;
            if (currentPathIndex >= pathPoints.Length || currentPathIndex < 0)
            {
                enemyDirection *= -1;
                currentPathIndex += enemyDirection;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        for (int i = 0; i < pathPoints.Length; i++)
        {
            Gizmos.DrawSphere(pathPoints[i], 0.2f);
        }
    }

}
