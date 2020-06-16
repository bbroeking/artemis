using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public CharacterUI characterUI;
    public CharacterEquipment equipment;
    public List<Loot> characterItems = new List<Loot>();


    private void Start(){
        equipment = new CharacterEquipment();
    }

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

    public void EquipItem(LootEquipment loot){
        switch(loot.equipmentType){
            case EquipmentType.head:
                if (this.equipment.head == null){
                    this.equipment.head = loot;
                    RemoveItem(loot.id);
                } else {
                    GiveItem(this.equipment.head.id);
                    this.equipment.head = loot;
                    RemoveItem(loot.id);
                }
                characterUI.headslot.UpdateItem(this.equipment.head);
                break;
            case EquipmentType.chest:
                break;
            case EquipmentType.legs:
                break;
            case EquipmentType.ring:
                break;
            case EquipmentType.trinket:
                break;
            default:
                break;
        }
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
