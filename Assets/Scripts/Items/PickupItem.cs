using UnityEngine;

public class PickupItem : Interactable
{
    [SerializeField] public Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.F;
    [SerializeField] SpriteRenderer spriteRenderer;

    public override void Interact(Inventory inventory)
    {
        isInRange = true;
        this.inventory = inventory;
    }

    public override void StopInteract()
    {
        isInRange = false;
        inventory = null;
    }

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
}
