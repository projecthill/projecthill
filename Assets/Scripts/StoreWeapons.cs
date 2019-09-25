using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StoreWeapons : MonoBehaviour
{
    int Upgrade1 = 20;
    int Upgrade2 = 20;
    int Upgrade3 = 25;
    int Upgrade4 = 30;
    int Upgrade5 = 30;

    public static bool Unlock1;
    public static bool Unlock2;
    public static bool Unlock3;
    public static bool Unlock4;
    public static bool Unlock5;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {

    }

    public void Purchase1()
    {
        if (PlayerAtributes.money >= 20)
        {
            PlayerAtributes.money -= Upgrade1;
            
        }

    }

    public void Purchase2()
    {
        if (PlayerAtributes.money >= 20)
        {
            PlayerAtributes.money -= Upgrade2;
            Unlock2 = true;
        }

    }

    public void Purchase3()
    {
        if (PlayerAtributes.money >= 25)
        {
            PlayerAtributes.money -= Upgrade3;
            Unlock3 = true;
        }

    }
    public void Purchase4()
    {
        if (PlayerAtributes.money >= 30)
        {
            PlayerAtributes.money -= Upgrade4;
            Unlock4 = true;
        }

    }
    public void Purchase5()
    {
        if (PlayerAtributes.money >= 30)
        {
            PlayerAtributes.money -= Upgrade5;
            Unlock5 = true;
        }

    }
}    
