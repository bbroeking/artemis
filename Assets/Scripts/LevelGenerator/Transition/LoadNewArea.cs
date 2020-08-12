using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    private LevelGenerator levelGenerator;
    private Player player;
    private Direction direction;
    private int xoff;
    private int yoff;

    void Awake() {
        player = SingletonPlayer.Instance.player;
        levelGenerator = GameObject.FindObjectOfType<LevelGenerator>();
    }

    void Start(){
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
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag(Tags.player)){
            player.lastDirection = direction;
            player.map = levelGenerator.GetNextRoom(xoff, yoff);
            SceneManager.LoadScene("Dungeon");
        }
    }
}
