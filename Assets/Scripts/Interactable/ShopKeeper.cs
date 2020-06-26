using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    [SerializeField] private List<Item> shopInventory;
    [SerializeField] private ShopPanel shopPanel;
    [SerializeField] GameObject shopGameObject;

    public override void Interact(){
        shopPanel.SetShop(shopInventory);
        shopGameObject.SetActive(!shopGameObject.activeSelf);
    }

    public override void StopInteract(){
        shopGameObject.SetActive(!shopGameObject.activeSelf);
        shopPanel.Clear();
    }
}
