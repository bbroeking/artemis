using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStartPoint : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = PlayerSingleton.Instance.player;
        player.transform.position = this.transform.position;
    }
}
