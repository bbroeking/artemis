using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSingleton : GenericSingleton
{    
    public static CameraSingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
    }
}
