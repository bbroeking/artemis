using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNewDungeon : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    private Player player;

    void Awake() {
        levelGenerator = GameObject.FindObjectOfType<LevelGenerator>();
        player = PlayerSingleton.Instance.player;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(Tags.player)){
            player.lastRoomDirection = Direction.North;

            levelGenerator.SetLevelSettings(10, 10, 5);
            levelGenerator.GenerateLevel();
            levelGenerator.currentLevel += 1;
            levelGenerator.UpdateUI();
            
            player.map = levelGenerator.GetFirstRoom();
            if (levelGenerator.currentLevel < 5){
                SceneManager.LoadScene("Dungeon");
            } else {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
