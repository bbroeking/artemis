using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    head,
    chest,
    legs,
    ring,
    trinket
}
[CreateAssetMenu(fileName = "New Equipment Loot", menuName = "Equipment Loot")]
public class LootEquipment : Loot
{
    public EquipmentType equipmentType;

}
