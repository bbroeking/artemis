using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Demonologist Relic/Infernal")]
public class InfernalEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        player.spellbook.Infernal.Summon(player);
    }

    public override string GetDescription()
    {
        return "Summons an infernal";
    }
}
