using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public InventoryUI inventoryUI;

    private void Start()
    {
        GiveItem(0);
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = ItemDB.Instance.GetItem(id);
        inventoryUI.AddNewItem(itemToAdd);
        characterItems.Add(itemToAdd);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = ItemDB.Instance.GetItem(itemName);
        inventoryUI.AddNewItem(itemToAdd);
        characterItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if(itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);

        }
    }
}
