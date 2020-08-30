using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISingleton : GenericSingleton
{
    public static UISingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
    }
}
