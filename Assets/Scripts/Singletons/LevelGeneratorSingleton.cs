using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSingleton : MonoBehaviour
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
