using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPosition : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // void OnSceneLoaded(){
    //     player.ReturnToDungeon();
    // }
}
