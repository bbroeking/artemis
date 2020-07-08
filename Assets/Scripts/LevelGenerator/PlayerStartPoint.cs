using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        ReturnToDungeon();
    }

    public void ReturnToDungeon(){
        if (player == null || player.scene == null) {
            return;
        }
        if(player.backToDungeon){
            Debug.Log("startpoint");
            player.transform.position = new Vector3(5,5,5);
            Debug.Log("should be palced");
            this.player.scene = null;
            player.transform.position = new Vector3(0,0,0);
            player.backToDungeon = false;
        }
    }
}
