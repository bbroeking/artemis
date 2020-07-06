using UnityEngine;

public class ManagerSingleton : MonoBehaviour
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
