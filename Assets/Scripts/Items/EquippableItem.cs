using UnityEngine;

public enum EquipmentType { Head, Chest, Legs, Ring, Trinket, Mainhand, Offhand }
[CreateAssetMenu(menuName="Items/EquipmentItem")]
public class EquippableItem : Item
{
    public int strengthBonus;
    public int dexterityBonus;
    public int intellectBonus;
    public int vitalityBonus;
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
    public override string GetItemType(){
        return EquipmentType.ToString();
    }
    public override string GetDescription()
	{
		sb.Length = 0;
		AddStat(strengthBonus, "Strength");
		AddStat(dexterityBonus, "Agility");
		AddStat(intellectBonus, "Intelligence");
		AddStat(vitalityBonus, "Vitality");

		return sb.ToString();
	}
	private void AddStat(float value, string statName, bool isPercent = false)
	{
		if (value != 0)
		{
			if (sb.Length > 0)
				sb.AppendLine();

			if (value > 0)
				sb.Append("+");

			if (isPercent) {
				sb.Append(value * 100);
				sb.Append("% ");
			} else {
				sb.Append(value);
				sb.Append(" ");
			}
			sb.Append(statName);
		}
	}
}
