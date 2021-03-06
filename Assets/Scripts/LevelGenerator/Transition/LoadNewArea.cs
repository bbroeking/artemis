﻿using UnityEngine;
using UnityEngine.SceneManagement;

public enum DoorType { Basic, Boss }
public class LoadNewArea : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private Animator animator;
    private Player player;
    private Direction direction;
    private int xoff;
    private int yoff;
    private DoorType doorType;

    void Awake() {
        
    }

    void Start(){
        player = PlayerSingleton.Instance.player;
        levelGenerator = LevelGeneratorSingleton.Instance.levelGenerator;

        switch(this.gameObject.tag){
            case "north":
                yoff = 1;
                xoff = 0;
                direction = Direction.North;
                break;
            case "south":
                yoff = -1;
                xoff = 0;
                direction = Direction.South;
                break;
            case "east":
                yoff = 0;
                xoff = 1;
                direction = Direction.East;
                break;
            case "west":
                yoff = 0;
                xoff = -1;
                direction = Direction.West;
                break;
            default:
                break;
        }
        doorType = levelGenerator.GetDoorType(xoff, yoff);

        // Rotate sprite if North/South
        if(direction == Direction.North || direction == Direction.South){
            spriteRenderer.transform.Rotate(Vector3.forward, 90, Space.World);
        }
    }

    public void EnablePortals(){
        if (doorType == DoorType.Boss) {
            animator.SetTrigger("boss");
            // spriteRenderer.sprite = Resources.Load<Sprite>(PrefabPath.RedPortal);
        }
        else {
            Debug.Log("setting");
            animator.SetTrigger("Standard");
            // spriteRenderer.sprite = Resources.Load<Sprite>(PrefabPath.BluePortal);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(Tags.player) && player.remainingEnemies <= 0){
            player.lastRoomDirection = direction;
            player.map = levelGenerator.GetNextRoom(xoff, yoff);
            SceneManager.LoadScene("Dungeon");
        }
    }
}
