using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Directions { north, South, east, west }
public class LoadNewArea : MonoBehaviour
{
    [SerializeField] LevelGenerator levelGenerator;
    [SerializeField] string scene;
    private int xoff;
    private int yoff;

    void Awake() {
        levelGenerator = GameObject.FindObjectOfType<LevelGenerator>();
    }

    void Start(){
        switch(this.gameObject.tag){
            case "north":
                yoff = 1;
                xoff = 0;
                break;
            case "south":
                yoff = -1;
                xoff = 0;
                break;
            case "east":
                yoff = 0;
                xoff = 1;
                break;
            case "west":
                yoff = 0;
                xoff = -1;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "player"){
            scene = levelGenerator.GetNextRoom(xoff, yoff);
            SceneManager.LoadScene(scene);
        }
    }
}
