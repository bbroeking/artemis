﻿using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    protected bool isInRange;
    protected float interactCooldown = 1f;
    protected static bool isInteractable = true;
    [SerializeField] protected KeyCode interactKey = KeyCode.Space;

    public virtual IEnumerator Cooldown(){
        if(isInteractable){
            isInteractable = false;
            yield return new WaitForSeconds(interactCooldown);
            isInteractable = true;
        }
    }

    public virtual void Interact(Player player)
    {
        isInRange = true;
    }

    public virtual void StopInteract()
    {
        isInRange = false;
    }
}
