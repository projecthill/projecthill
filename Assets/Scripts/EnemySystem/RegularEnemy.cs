﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemy : EnemyParent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime); //movimiento del enemigo de derecha a izquierda
    }
}
