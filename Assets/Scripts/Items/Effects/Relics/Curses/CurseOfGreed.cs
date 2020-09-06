using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Curse Relic/Greed")]
public class CurseOfGreed : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies){
            enemy.SpawnBonusLoot = true; // TODO make monsters with this flag spawn more loot
        }
    }

    public override string GetDescription()
    {
        return "Filled with greed, monsters in this room don't hide their items. On death they lose it all";
    }
}
