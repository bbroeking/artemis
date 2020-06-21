using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    [SerializeField]
    private List<Loot> shopInventory;
    [SerializeField]
    private GenerateShop generateShop;

    public override void Interact(){
        generateShop.GenerateShopForShopkeeper(shopInventory);
    }
}
