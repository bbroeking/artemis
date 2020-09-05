using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Demonologist Relic/Imp")]
public class ImpEmbersEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        player.spellbook.Imp.Summon();
    }

    public override string GetDescription()
    {
        return "Summons an imp";
    }
}
