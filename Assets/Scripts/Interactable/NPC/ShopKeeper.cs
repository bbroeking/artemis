using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    [SerializeField] private List<Item> shopInventory;
    [SerializeField] private ShopPanel shopPanel;
    [SerializeField] private GameObject shopGameObject;
    private bool shopIsActive;
    private CanvasGroup shopCanvasGroup;

    void Start(){
        shopIsActive = false;
        shopCanvasGroup = shopGameObject.GetComponent<CanvasGroup>();
    }
    public override void Interact(Player player){
        OpenShop();
    }

    public override void StopInteract(){
        CloseShop();
    }

    private void OpenShop(){
        shopPanel.SetShop(shopInventory);
        shopIsActive = !shopIsActive;
        shopCanvasGroup.alpha = shopIsActive ? 1 : 0;
        shopCanvasGroup.blocksRaycasts = shopIsActive;
    }

    private void CloseShop(){
        shopIsActive = false;
        shopCanvasGroup.alpha = 0;
        shopCanvasGroup.blocksRaycasts = false;
        shopPanel.Clear();
    }
}
