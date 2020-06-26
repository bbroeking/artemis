using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    protected bool isInRange;
    [SerializeField] protected KeyCode npcInteractKey = KeyCode.F;

    public virtual void Interact(){
        Debug.Log("Start Interact");
    }

    public virtual void StopInteract(){
        Debug.Log("Stop Interact");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            isInRange = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            isInRange = false;
        }
    }
}
