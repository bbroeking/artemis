using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    protected bool isInRange;
    [SerializeField] protected KeyCode interactKey = KeyCode.F;

    public virtual void Interact(Player player)
    {
        isInRange = true;
    }

    public virtual void StopInteract()
    {
        isInRange = false;
    }
}
