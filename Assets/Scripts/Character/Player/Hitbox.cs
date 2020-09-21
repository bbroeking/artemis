using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private IInteractable interactable;
    [SerializeField] private Player player;

    private void Start(){
        player = PlayerSingleton.Instance.player;
    }

    private void Update(){
        this.transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision){}
    private void OnTriggerStay2D(Collider2D collision){}
    private void OnTriggerExit2D(Collider2D collision){}    
}
