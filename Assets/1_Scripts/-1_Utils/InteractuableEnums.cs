using System;
using UnityEngine;

public class InteractuableEnums
{
    public enum Colors
    {
        Red,
        Green,
        Blue
    }

    public static void GetObjectsOfColor(Colors color, out GameObject[] walls)
    {
        switch(color)
        {
            case Colors.Red:
                walls = GameObject.FindGameObjectsWithTag("Red");
                break;
            case Colors.Green:
                walls = GameObject.FindGameObjectsWithTag("Green");
                break;
            case Colors.Blue:
                walls = GameObject.FindGameObjectsWithTag("Blue");
                break;
            default:
                Debug.LogError("No se han encontrado paredes de el color: " + color);
                walls = null;
            break;
        }
    }
}
