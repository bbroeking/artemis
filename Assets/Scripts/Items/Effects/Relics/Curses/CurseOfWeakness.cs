using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Curse Relic/Weakness")]
public class CurseOfWeakness : UsableItemEffect
{
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies){
            enemy.MakeBrittle();
        }
    }

    public override string GetDescription()
    {
        return "Reduces the health of all monsters in the room to 1";
    }
}
