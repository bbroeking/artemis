using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private IInteractable interactable;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Interactable"){
            interactable = collision.GetComponent<IInteractable>();
            interactable.Interact();
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Interactable"){
            interactable.StopInteract();
            interactable = null;
        }
    }
}
