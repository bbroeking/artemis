using UnityEngine;

public class VoidGuardianSingleton : GenericSingleton
{
    public VoidGuardian voidGuardian;
    public static VoidGuardianSingleton Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
        voidGuardian = FindObjectOfType<VoidGuardian>();
    }
}
