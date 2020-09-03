using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType {Strength, Dexterity, Intelligence, Vitality}
[CreateAssetMenu(menuName = "Item Effects/Stat Buff")]
public class StatBuffItemEffect : UsableItemEffect
{
    public StatType statType;
    public int BuffAmount;
    public float Duration;
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        switch (statType)
        {
            case StatType.Strength:
                StatModifier statModifier = new StatModifier(BuffAmount, StatModType.Flat, this);
                player.strength.AddModifier(statModifier);
                player.StartCoroutine(RemoveBuff(player, statModifier, Duration));
                break;
            case StatType.Dexterity:
                break;
            case StatType.Intelligence:
                break;
            case StatType.Vitality:
                break;
            default:
                break;
        }
    }

    public override string GetDescription()
    {
        return "";
    }

    private IEnumerator RemoveBuff(Player player, StatModifier statModifier, float duration){
        yield return new WaitForSeconds(duration);
        player.strength.RemoveModifier(statModifier);
    }
}
