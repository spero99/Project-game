using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetWorldBounds : MonoBehaviour
{
    private void Awake()
    {
        //gets the bounds of the foreground object and adds it to a global parameter
        var bounds = GetComponent<TilemapRenderer>().bounds;
        Globals.WorldBounds = bounds;
    }
}
