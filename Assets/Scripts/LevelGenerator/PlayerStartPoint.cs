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
}
