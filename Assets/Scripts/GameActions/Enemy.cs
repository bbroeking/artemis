using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] LootTable lootTable;

    private void OnValidate(){
        lootTable = gameObject.GetComponentInParent<LootTable>();
    }
    public void Hit(int damage)
    {
        TakeDamage(damage);
        if (this.dead)
            SpawnLootAndDestroy();
    }

    private void SpawnLootAndDestroy()
    {
        lootTable.SpawnLoot();
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage){
        this.currentHealth -= damage;
        if(this.currentHealth <= 0){
            this.dead = true;
        }
    }
}
