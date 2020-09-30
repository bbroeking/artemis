using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Player player;
    void Awake(){
        player = PlayerSingleton.Instance.player;
    }
    void Start()
    {
        Room room = player.map;
        string wallPath = room.GetWallPath();
        string floorPath = room.GetFloorPath();
        // Set Camera
        if(room.roomType == RoomType.LargeStandard) player.cam.m_Follow = player.transform;
        else {
            player.cam.m_Follow = null;
            player.cam.transform.position = new Vector3(0, -1, -10);
        }
        // Load Room From Prefab
        GameObject wall = (GameObject) LoadPrefab.LoadPrefabFromFile(wallPath);
        Instantiate(wall, Vector3.zero, Quaternion.identity);
        GameObject floor = (GameObject) LoadPrefab.LoadPrefabFromFile(floorPath);
        Instantiate(floor, Vector3.zero, Quaternion.identity);
        
        player.remainingEnemies = floor.GetComponentsInChildren<Spawner>().Length;
        List<GameObject> portals = new List<GameObject>();
        portals.Add(GameObject.FindGameObjectWithTag("west"));
        portals.Add(GameObject.FindGameObjectWithTag("east"));
        portals.Add(GameObject.FindGameObjectWithTag("north"));
        portals.Add(GameObject.FindGameObjectWithTag("south"));
        player.portals = portals;
    }
}
