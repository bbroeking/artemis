using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private IInteractable interactable;
    [SerializeField] private Player player;

    private void OnValidate(){
        player = GetComponentInParent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "DroppedItem"){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player.Inventory);
        }
        else if (collision.gameObject.tag == "DroppedCurrency"){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player);
        }
        else if(collision.gameObject.tag == "NPC"){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact(player.Inventory);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "DroppedItem" && collision.gameObject.tag == "DroppedCurrency" && collision.gameObject.tag == "NPC"){
            interactable.StopInteract();
            interactable = null;
        }
    }
}
