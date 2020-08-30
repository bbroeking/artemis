using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSingleton : GenericSingleton
{
    public LevelGenerator levelGenerator;
    public static LevelGeneratorSingleton Instance { get; private set; } // static singleton
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject);}
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }
}
