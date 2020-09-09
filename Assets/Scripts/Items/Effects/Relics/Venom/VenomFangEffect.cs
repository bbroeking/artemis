using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Venom Relic/Fang")]
public class VenomFangEffect : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        player.combat.ExecuteRelicEffect(RelicType.Fang);
    }

    public override string GetDescription()
    {
        throw new System.NotImplementedException();
    }

}
