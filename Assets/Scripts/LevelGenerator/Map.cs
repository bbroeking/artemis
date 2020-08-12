using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Player player;
    void Awake(){
        player = SingletonPlayer.Instance.player;
    }
    void Start()
    {
        string mapPath = player.map;
        Debug.Log(mapPath);
        GameObject map = (GameObject) LoadPrefab.LoadPrefabFromFile(mapPath);
        Instantiate(map, Vector3.zero, Quaternion.identity);
    }
}
