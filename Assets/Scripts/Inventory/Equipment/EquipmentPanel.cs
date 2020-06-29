using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentPanel : ItemContainer
{
    [SerializeField] Transform equipmentSlotsParent;
    public EquipmentSlot[] equipmentSlots;

    protected override void OnValidate(){
        base.OnValidate();
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem){
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].EquipmentType == item.EquipmentType){
                previousItem = (EquippableItem) equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item){
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].Item == item){
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
}
