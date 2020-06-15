using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {

}
[CreateAssetMenu(fileName = "New Equipment Loot", menuName = "Equipment Loot")]
public class LootEquipment : Loot
{
    public EquipmentType equipmentType;

    public override LootEquipment(EquipmentType equipmentType)
    {
        this.id = id;
        this.lootName = lootName;
        this.description = description;
        this.stats = stats;
        this.weight = weight;
        this.lootType = lootType;
        this.equipmentType = equipmentType;
    }

    public LootEquipment(LootEquipment item) : base(Loot item)
    {
        id = item.id;
        lootName = item.lootName;
        description = item.description;
        stats = item.stats;
        weight = item.weight;
        lootType = item.lootType;
        equipmentType = item.equipmentType;
    }
}
