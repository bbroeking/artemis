using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    head,
    chest,
    legs,
    ring,
    trinket,
    mainhand,
    offhand
}
[CreateAssetMenu(fileName = "New Equipment Loot", menuName = "Equipment Loot")]
public class LootEquipment : Loot
{
    public EquipmentType equipmentType;

    private void InitEquip(Loot item){
        this.id = item.id;
        this.lootName = item.lootName;
        this.lootWeight = item.lootWeight;
        this.description = item.description;
        this.sprite = item.sprite;
        this.stats = item.stats;
        this.weight = item.weight;
        this.lootType = item.lootType;
    }
    public static LootEquipment CreateLootEquipment(LootEquipment item){
        LootEquipment loot = ScriptableObject.CreateInstance<LootEquipment>();

        loot.InitEquip(item);

        return loot;
    }

}
