using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction {North, East, South, West};
public class PlayerStartPoint : MonoBehaviour
{
    [SerializeField] private Direction comingFrom;
    private Player player;

    void Start()
    {
        player = PlayerSingleton.Instance.player;
        if(player.lastRoomDirection == comingFrom){
            player.transform.position = this.transform.position;
            player.SetDemonLocations();
        }
    }
}
