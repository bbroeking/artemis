using UnityEngine;

public class InfernalSingleton : GenericSingleton
{
    public Infernal infernal;
    public static InfernalSingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
        infernal = FindObjectOfType<Infernal>();
    }
}
