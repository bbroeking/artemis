using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/UsableItems")]
public class UsableItem : Item
{
    [Header("Usable Item")]
    public bool isConsumable;
    public int soulCost;
    public List<UsableItemEffect> Effects;
    public virtual void Use(Player p){
        foreach(UsableItemEffect effect in Effects){
            if(p.Souls >= soulCost){
                effect.ExecuteEffect(this, p);
                p.Souls = p.Souls - soulCost;
                p.SetPlayerCurrency();
            }
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
