﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Player player;
    void Awake(){
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        string mapPath = player.map;
        GameObject map = (GameObject) LoadPrefab.LoadPrefabFromFile(mapPath);
        Instantiate(map, Vector3.zero, Quaternion.identity);
    }
}
