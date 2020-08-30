using UnityEngine;

public class ManagerSingleton : GenericSingleton
{
    private static bool exists;
    void Awake(){
        if(!exists){
            exists = true;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
