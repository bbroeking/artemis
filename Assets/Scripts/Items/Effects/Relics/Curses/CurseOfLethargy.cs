using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Curse Relic/Lethargy")]
public class CurseOfLethargy : UsableItemEffect
{
    private float slowPercentage = 0.5f;
    public override void ExecuteEffect(UsableItem parentItem, Player player)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies){
            enemy.SlowUnit(slowPercentage);
        }
    }

    public override string GetDescription()
    {
        return "Slow all enemies within room by " + slowPercentage.ToString() + " percent";
    }
}
