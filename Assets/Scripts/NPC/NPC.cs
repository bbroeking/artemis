using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public virtual void Interact(){
        Debug.Log("Start Interact");
    }

    public virtual void StopInteract(){
        Debug.Log("Stop Interact");
    }
}
