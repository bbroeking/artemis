using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Demonologist Relic/VoidGuardian")]
public class VoidGuardianEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        player.spellbook.VoidGuardian.Summon(player);
    }

    public override string GetDescription()
    {
        return "Void Guardian Effect";
    }
}
