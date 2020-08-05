using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private Player player;
    [SerializeField] GameObject deathMenu;

    void Start(){
        player = FindObjectOfType<Player>();
    }
    public void Respawn(){
        deathMenu.SetActive(false);
        player.Respawn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowMenu(){
        deathMenu.SetActive(true);
    }

}
