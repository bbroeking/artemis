using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericSingleton : MonoBehaviour
{
    protected void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    protected void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // here you can use scene.buildIndex or scene.name to check which scene was loaded
        if (scene.name == Scenes.MainMenu){
            // Destroy the gameobject this script is attached to
            Destroy(gameObject);
        }
    }
}
