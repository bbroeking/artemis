using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryUI inventoryUI;
    public CharacterUI characterUI;
    public CharacterEquipment equipment;
    public List<Loot> characterItems = new List<Loot>();
    private bool ring;
    private bool trinket;


    private void Start(){
        equipment = new CharacterEquipment();
        ring = true;
        trinket = true;
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
                if (this.equipment.chest == null){
                    this.equipment.chest = loot;
                    RemoveItem(loot.id);
                } else {
                    GiveItem(this.equipment.chest.id);
                    this.equipment.chest = loot;
                    RemoveItem(loot.id);
                }
                characterUI.chestslot.UpdateItem(this.equipment.chest);
                break;
            case EquipmentType.legs:
                if (this.equipment.legs == null){
                    this.equipment.legs = loot;
                    RemoveItem(loot.id);
                } else {
                    GiveItem(this.equipment.legs.id);
                    this.equipment.legs = loot;
                    RemoveItem(loot.id);
                }
                characterUI.legslot.UpdateItem(this.equipment.legs);
                break;
            case EquipmentType.ring:
                if (this.equipment.ring1 == null){
                    this.equipment.ring1 = loot;
                    RemoveItem(loot.id);
                    ring = false;
                } else if (this.equipment.ring2 == null){
                    this.equipment.ring2 = loot;
                    RemoveItem(loot.id);
                    ring = true;
                } 
                else {
                    if (ring){
                        GiveItem(this.equipment.ring1.id);
                        this.equipment.ring1 = loot;
                        RemoveItem(loot.id);
                        ring = false;
                    } else {
                        GiveItem(this.equipment.ring2.id);
                        this.equipment.ring2 = loot;
                        RemoveItem(loot.id);
                        ring = true;
                    }
                }
                if (ring){
                    characterUI.ringslot2.UpdateItem(this.equipment.ring2);
                } else {
                    characterUI.ringslot1.UpdateItem(this.equipment.ring1);
                }
                break;
            case EquipmentType.trinket:
                if (this.equipment.trinket1 == null){
                    this.equipment.trinket1 = loot;
                    RemoveItem(loot.id);
                    trinket = false;
                } else if (this.equipment.trinket2 == null){
                    this.equipment.trinket2 = loot;
                    RemoveItem(loot.id);
                    trinket = true;
                } 
                else {
                    if (ring){
                        GiveItem(this.equipment.trinket1.id);
                        this.equipment.trinket1 = loot;
                        RemoveItem(loot.id);
                        trinket = false;
                    } else {
                        GiveItem(this.equipment.trinket2.id);
                        this.equipment.trinket2 = loot;
                        RemoveItem(loot.id);
                        trinket = true;
                    }
                }
                if (ring){
                    characterUI.trinketslot2.UpdateItem(this.equipment.trinket2);
                } else {
                    characterUI.trinketslot1.UpdateItem(this.equipment.trinket1);
                }
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
