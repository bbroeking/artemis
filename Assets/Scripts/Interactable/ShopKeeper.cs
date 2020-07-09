using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    [SerializeField] private List<Item> shopInventory;
    [SerializeField] private ShopPanel shopPanel;
    [SerializeField] private GameObject shopGameObject;

    public override void Interact(){
        OpenShop();
    }

    public override void StopInteract(){
        CloseShop();
    }

    private void OpenShop(){
        shopPanel.SetShop(shopInventory);
        shopGameObject.SetActive(!shopGameObject.activeSelf);
    }

    private void CloseShop(){
        shopGameObject.SetActive(!shopGameObject.activeSelf);
        shopPanel.Clear();
    }
}
