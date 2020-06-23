using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    [SerializeField]
    private List<Loot> shopInventory;
    [SerializeField]
    private GenerateShopUI generateShop;
    [SerializeField]
    //private UIItem selectedItem;

    public override void Interact(){
        generateShop.GenerateShopForShopkeeper(shopInventory);
        generateShop.Toggle();
    }

    public override void StopInteract(){
        generateShop.Toggle();
        generateShop.ClearShop();
        //selectedItem.UpdateItem(null);
    }
}
