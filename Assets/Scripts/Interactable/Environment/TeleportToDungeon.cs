using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToDungeon : MonoBehaviour
{
    private Player player;

    void Start(){
        player = PlayerSingleton.Instance.player;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "player"){
            player.backToDungeon = true;
            SceneManager.LoadScene(player.scene);
        }
    }
}
