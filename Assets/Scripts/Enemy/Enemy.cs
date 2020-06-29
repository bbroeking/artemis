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
