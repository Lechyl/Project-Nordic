using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnUnits
{
    public GameObject unit;


    [Range(1, 100)] public int spawnRate;
}
