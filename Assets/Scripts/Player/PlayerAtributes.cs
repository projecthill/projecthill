using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtributes : MonoBehaviour{

    // Atributos por ser manipulados por progresión del juego
    int attribHP = 10;
    int attribATK;
    int attribDEF;

    void OnTriggerEnter2D (Collider2D other) //enemigos desaparecerán al colisionar con la torre
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
