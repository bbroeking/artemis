using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecapUI : MonoBehaviour
{
    private Player player;
    [SerializeField] private GameObject recapUI;

    void Start(){
        player = PlayerSingleton.Instance.player;
    }
    public void Release(){
        recapUI.SetActive(false);
        SceneManager.LoadScene(Scenes.MainMenu);
    }
    public void ShowMenu(){
        recapUI.SetActive(true);
    }

}
