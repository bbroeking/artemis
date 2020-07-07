using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour
{
    private Player player;

    void Awake(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
        //player.transform.position = transform.position;
    }

    public void ReturnToDungeon(){
        if (player == null || player.scene == null) return;
        Debug.Log(player.lastDungeonLocation.ToString());
        player.transform.position = player.lastDungeonLocation;
        this.player.scene = null;
        player.transform.position = new Vector3(0,0,0);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if (scene.name == "Home") return;
        ReturnToDungeon();
    }
}
