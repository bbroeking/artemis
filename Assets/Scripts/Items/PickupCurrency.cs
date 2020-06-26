using UnityEngine;

public enum CurrencyType { Gold, Soul }
public class PickupCurrency : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] CurrencyType type;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.F;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Player player;
    [SerializeField] Sprite gold;
    [SerializeField] Sprite soul;
    [SerializeField] CurrencyPanel currencyPanel;
    private bool isInRange;

    void Start(){
        if(type == CurrencyType.Gold){
            spriteRenderer.sprite = gold;
        } else if (type == CurrencyType.Soul){
            spriteRenderer.sprite = soul;
        }
    }
    void Update()
    {
        if(isInRange && Input.GetKeyDown(itemPickupKeyCode)){
            if(type == CurrencyType.Gold){
                player.Gold = amount;
            } else if (type == CurrencyType.Soul){
                player.Souls = amount;
            }
            player.SetPlayerCurrency();
            currencyPanel.UpdateCurrencyValues();
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
