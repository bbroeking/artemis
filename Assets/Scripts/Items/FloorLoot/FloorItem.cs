using UnityEngine;

public class FloorItem : Interactable
{
    [SerializeField] public Item item;
    [SerializeField] PlayerRelic relics;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.Space;
    [SerializeField] SpriteRenderer spriteRenderer;

    public override void Interact(Player player)
    {
        isInRange = true;
        this.relics = player.relics;
    }

    public override void StopInteract()
    {
        isInRange = false;
        relics = null;
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
            relics.AddRelic((UsableItem) Instantiate(item));
            Destroy(this.gameObject);
        }
    }
}
