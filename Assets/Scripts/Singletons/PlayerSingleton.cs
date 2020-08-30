using UnityEngine;

public class PlayerSingleton : GenericSingleton
{
    public Player player;
    public static PlayerSingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
        player = FindObjectOfType<Player>();
    }
}
