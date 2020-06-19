using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public CharacterUI characterUI;
    public CharacterEquipment equipment = new CharacterEquipment();
    public List<Loot> characterItems = new List<Loot>();
    private void Awake(){
        GiveItem(0);
        GiveItem(0);
        GiveItem(1);
        GiveItem(2);
        GiveItem(2);
        GiveItem(3);
        GiveItem(4);
        GiveItem(5);
        GiveItem(6);
        //GiveItem(7); break for some reason
    }

    public void GiveItem(int id)
    {
        Loot genericItem = ItemDB.Instance.GetItem(id);
        Loot generatedItem;
        if(genericItem.lootType == LootType.Equipment){
            Debug.Log("herer");
            generatedItem = ((LootEquipment) genericItem).GenerateItem();
        } else {
            generatedItem = genericItem.GenerateItem();
        }
        inventoryUI.AddNewItem(generatedItem);
        characterItems.Add(generatedItem);
    }
    public void GiveItem(string itemName)
    {
        Loot itemToAdd = ItemDB.Instance.GetItem(itemName);
        inventoryUI.AddNewItem(itemToAdd);
        characterItems.Add(itemToAdd);
    }
    public LootEquipment EquipItem(LootEquipment loot, int slot){
         switch(loot.equipmentType){
            case EquipmentType.head:
                if (this.equipment.head == null){
                    this.equipment.head = loot;
                    return null;
                } else {
                    LootEquipment wasEquipped = this.equipment.head;
                    this.equipment.head = loot;
                    return wasEquipped;
                }
            case EquipmentType.chest:
                if (this.equipment.chest == null){
                    this.equipment.chest = loot;
                    return null;
                } else {
                    LootEquipment wasEquipped = this.equipment.chest;
                    this.equipment.chest = loot;
                    return wasEquipped;
                }
            case EquipmentType.legs:
                if (this.equipment.legs == null){
                    this.equipment.legs = loot;
                    return null;
                } else {
                    LootEquipment wasEquipped = this.equipment.legs;
                    this.equipment.legs = loot;
                    return wasEquipped;
                }
            case EquipmentType.mainhand:
                if (this.equipment.mainhand == null){
                    this.equipment.mainhand = loot;
                    return null;
                } else {
                    LootEquipment wasEquipped = this.equipment.mainhand;
                    this.equipment.mainhand = loot;
                    return wasEquipped;
                }
            case EquipmentType.offhand:
                if (this.equipment.offhand == null){
                    this.equipment.offhand = loot;
                    return null;
                } else {
                    LootEquipment wasEquipped = this.equipment.offhand;
                    this.equipment.offhand = loot;
                    return wasEquipped;
                }
            case EquipmentType.ring:
                if (slot == 0) 
                {
                    if (this.equipment.ring1 == null)
                    {
                        this.equipment.ring1 = loot;
                        return null;
                    } 
                    else 
                    {
                        LootEquipment wasEquipped = this.equipment.ring1;
                        this.equipment.ring1 = loot;
                        return wasEquipped;
                    }
                } 
                else 
                {
                    if (this.equipment.ring2 == null)
                    {
                        this.equipment.ring2 = loot;
                        return null;
                    } 
                    else 
                    {
                        LootEquipment wasEquipped = this.equipment.ring2;
                        this.equipment.ring2 = loot;
                        return wasEquipped;
                    }
                }
            case EquipmentType.trinket:
                if (slot == 0) 
                {
                    if (this.equipment.trinket1 == null)
                    {
                        this.equipment.trinket1 = loot;
                        return null;
                    } 
                    else 
                    {
                        LootEquipment wasEquipped = this.equipment.trinket1;
                        this.equipment.trinket1 = loot;
                        return wasEquipped;
                    }
                } 
                else 
                {
                    if (this.equipment.trinket2 == null)
                    {
                        this.equipment.trinket2 = loot;
                        return null;
                    } 
                    else 
                    {
                        LootEquipment wasEquipped = this.equipment.trinket2;
                        this.equipment.trinket2 = loot;
                        return wasEquipped;
                    }
                }
            default:
                return null;
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
