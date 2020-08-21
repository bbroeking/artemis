using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Venom Relic/Nova")]
public class VenomNovaEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        player.combat.ExecuteRelicEffect(RelicType.Nova);
    }

    public override string GetDescription()
    {
        return "";
    }
}
