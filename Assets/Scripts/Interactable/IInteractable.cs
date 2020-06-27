using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    void Interact(Inventory inventory);
    void Interact(Player player);
    void StopInteract();
} 
