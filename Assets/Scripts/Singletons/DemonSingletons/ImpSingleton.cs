using UnityEngine;

public class ImpSingleton : GenericSingleton
{
    public Imp imp;
    public static ImpSingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
        imp = FindObjectOfType<Imp>();
    }
}
