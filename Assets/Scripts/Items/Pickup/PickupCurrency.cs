using UnityEngine;

public enum CurrencyType { Gold, Soul }
public class PickupCurrency : Interactable
{
    [SerializeField] int amount;
    [SerializeField] CurrencyType type;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Player player;
    [SerializeField] CurrencyPanel currencyPanel;
    
    [Header("Sprites")]
    [SerializeField] Sprite gold;
    [SerializeField] Sprite soul;

    public override void Interact(Player player){
        this.player = player;
        this.currencyPanel = player.currencyPanel;
        isInRange = true;
    }
    public override void StopInteract(){
        this.player = null;
        this.currencyPanel = null;
        isInRange = false;
    }
    void Start(){
        if(type == CurrencyType.Gold){
            spriteRenderer.sprite = gold;
        } else if (type == CurrencyType.Soul){
            spriteRenderer.sprite = soul;
        }
    }
    void Update()
    {
        if(isInRange && Input.GetKeyDown(interactKey)){
            if(type == CurrencyType.Gold){
                player.Gold = amount;
            } else if (type == CurrencyType.Soul){
                player.Souls = amount;
            }
            player.SetPlayerCurrency();
            Destroy(this.gameObject);
        }
    }
}
