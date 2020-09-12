using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Venom Relic/Beam")]
public class VenomBeamEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        player.combat.ExecuteRelicEffect(RelicType.Beam);
    }

    public override string GetDescription()
    {
        return "to be written";
    }
}
