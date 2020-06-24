using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/UsableItems")]
public class UsableItem : Item
{
    public bool isConsumable;
    public List<UsableItemEffect> Effects;
    public virtual void Use(Player p){
        foreach(UsableItemEffect effect in Effects){
            effect.ExecuteEffect(this, p);
        }
    }

    public override string GetItemType(){
        return isConsumable ? "Consumable" : "Usable";
    }

    public override string GetDescription(){
        sb.Length = 0;
		foreach (UsableItemEffect effect in Effects)
		{
			sb.AppendLine(effect.GetDescription());
		}
		return sb.ToString();
    }
}
