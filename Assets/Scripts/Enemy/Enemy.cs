using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] LootTable lootTable;
    [SerializeField] Sprite sprite;

    private void OnValidate(){
        lootTable = gameObject.GetComponentInParent<LootTable>();
        gameObject.GetComponentInParent<SpriteRenderer>().sprite = sprite;
    }
    public override void Hit(int damage)
    {
        base.Hit(damage);
        if (this.dead)
            SpawnLootAndDestroy();
    }

    private void SpawnLootAndDestroy()
    {
        lootTable.SpawnLoot();
        Destroy(this.gameObject);
    }
}
