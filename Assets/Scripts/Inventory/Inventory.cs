using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Loot> characterItems = new List<Loot>();
    public InventoryUI inventoryUI;
    public CharacterUI characterUI;
    public CharacterEquipment equipment;

    private void Start(){}

    public void GiveItem(int id)
    {
        Loot itemToAdd = ItemDB.Instance.GetItem(id);
        inventoryUI.AddNewItem(itemToAdd);
        characterItems.Add(itemToAdd);
    }

    public void GiveItem(string itemName)
    {
        Loot itemToAdd = ItemDB.Instance.GetItem(itemName);
        inventoryUI.AddNewItem(itemToAdd);
        characterItems.Add(itemToAdd);
    }

    public Loot CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Loot itemToRemove = CheckForItem(id);
        if(itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);

        }
    }
}
