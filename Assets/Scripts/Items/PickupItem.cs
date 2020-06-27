using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] public Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.F;
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isInRange;

    void Start(){
        if(item != null){
            spriteRenderer.sprite = item.Icon;
        }
    }
    void Update()
    {
        if(item != null){
            spriteRenderer.sprite = item.Icon;
        }
        if(isInRange && Input.GetKeyDown(itemPickupKeyCode)){
            inventory.AddItem(Instantiate(item));
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("player")){
            isInRange = false;
        }
    }
}
