using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction {North, East, South, West};
public class PlayerStartPoint : MonoBehaviour
{
    [SerializeField] private Direction comingFrom;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        if(player.lastDirection == comingFrom){
            player.transform.position = this.transform.position;
        }
    }

    public void ReturnToDungeon(){
        if (player == null || player.scene == null) return;
        if(player.backToDungeon){
            player.transform.position = new Vector3(5,5,5);
            this.player.scene = null;
            player.transform.position = new Vector3(0,0,0);
            player.backToDungeon = false;
        }
    }
}
