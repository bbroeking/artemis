using UnityEngine;

public class ManagerSingleton : GenericSingleton
{
    public static ManagerSingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
    }
}
