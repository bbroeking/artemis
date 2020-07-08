using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArrival : MonoBehaviour
{
    private GameObject player;
    private Player script;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        script = player.GetComponent<Player>();
        if (script.scene != null){
            player.transform.position = this.transform.position;
        }
    }
}
