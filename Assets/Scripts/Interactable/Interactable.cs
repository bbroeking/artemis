using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    protected bool isInRange;
    [SerializeField] protected KeyCode interactKey = KeyCode.F;

    public virtual void Interact()
    {
        isInRange = true;
    }

    public virtual void StopInteract()
    {
        isInRange = false;
    }

    public virtual void Interact(Inventory inventory)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Interact(Player player)
    {
        throw new System.NotImplementedException();
    }
}
