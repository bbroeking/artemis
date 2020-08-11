using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(Player player);
    void StopInteract();
    IEnumerator Cooldown();
} 
