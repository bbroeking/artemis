using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSingleton : MonoBehaviour
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
