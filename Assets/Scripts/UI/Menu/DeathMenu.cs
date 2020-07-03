using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] GameObject deathMenuObject;
    public void Respawn(){
        deathMenuObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowMenu(){
        deathMenuObject.SetActive(true);
    }

}
