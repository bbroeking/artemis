﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealItemEffect : UsableItemEffect
{
    public int healAmount;
    public override void ExecuteEffect(UsableItem parentItem, Player player){
        player.health += healAmount;
    }

    public override string GetDescription()
    {
		return "Heals for " + healAmount + " health.";
    }
}
