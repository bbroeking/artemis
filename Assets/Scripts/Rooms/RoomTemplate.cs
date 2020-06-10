using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject fRightRoom;
    public GameObject fLeftRoom;
    public GameObject fTopRoom;
    public GameObject fBottomRoom;
    public GameObject fRightTopRoom;
    public GameObject fRightBottomRoom;
    public GameObject fLeftTopRoom;
    public GameObject fLeftBottomRoom;
    public GameObject fLeftRightBottomRoom;
    public GameObject fLeftRightTopRoom;

    public GameObject closedRoom;

    // Rooms thats have been populated
    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;


    private void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
