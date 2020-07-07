using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArrival : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        player.transform.position = this.transform.position;
    }
}
