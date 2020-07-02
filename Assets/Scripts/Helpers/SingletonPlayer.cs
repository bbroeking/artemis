using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonPlayer : MonoBehaviour
{
    public Player player;
    public static SingletonPlayer Instance { get; private set; } // static singleton
    void Awake() {
         if (Instance == null) { Instance = this;  }
         else { Destroy(gameObject); }
         // Cache references to all desired variables
         player= FindObjectOfType<Player>();
    }
}
