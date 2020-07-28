using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private IInteractable interactable;
    [SerializeField] private Player player;

    private void OnValidate(){
        player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag(Constants.droppedItem)){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player);
        }
        else if (collision.gameObject.CompareTag(Constants.droppedCurrency)){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player);
        }
        else if(collision.gameObject.CompareTag(Constants.NPC)){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player);
        }
        else if(collision.gameObject.CompareTag(Constants.shop)){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(interactable != null){
            interactable.StopInteract();
            interactable = null;
        }
    }
}
