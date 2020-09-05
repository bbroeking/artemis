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
        if(player.lastDirection == comingFrom){
            player.transform.position = this.transform.position;
            if(ImpSingleton.Instance != null && ImpSingleton.Instance.imp != null) {
                ImpSingleton.Instance.imp.transform.position = this.transform.position;
            }
        }
    }
}
