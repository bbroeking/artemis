using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    Head,
    Chest,
    Legs,
    Ring,
    Trinket,
    Mainhand,
    Offhand
}
[CreateAssetMenu]
public class EquippableItem : Item
{
    public int strengthBonus;
    public int dexterityBonus;
    public int intellectBonus;
    public int vitalityBonus;
    [Space]
    public EquipmentType EquipmentType;

    public void Equip(Character c){
        if (strengthBonus != 0)
            c.strength.AddModifier(new StatModifier(strengthBonus, StatModType.Flat, this));
        if (dexterityBonus != 0)
            c.dexterity.AddModifier(new StatModifier(dexterityBonus, StatModType.Flat, this));
        if (intellectBonus != 0)
            c.intellect.AddModifier(new StatModifier(intellectBonus, StatModType.Flat, this));
        if (vitalityBonus != 0)
            c.vitality.AddModifier(new StatModifier(vitalityBonus, StatModType.Flat, this));
    }

    public void Unequip(Character c){
        c.strength.RemoveAllModifiersFromSource(this);
        c.dexterity.RemoveAllModifiersFromSource(this);
        c.intellect.RemoveAllModifiersFromSource(this);
        c.vitality.RemoveAllModifiersFromSource(this);
    }
}
