using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public GameObject item;

    [SerializeField]
    private int enemyHealth;
    void Start(){
        this.health = enemyHealth;
        this.currentHealth = enemyHealth;
    }
    public void Hit(int damage)
    {
        TakeDamage(damage);
        if (this.dead)
        {
            SpawnLootAndDestroy();
        }
    }

    private void SpawnLootAndDestroy()
    {
        Item drop = GetComponent<LootTable>().GenerateDrop();
        GameObject d = Instantiate(item, transform.position, Quaternion.identity);
        SpriteRenderer sr = d.GetComponent<SpriteRenderer>();
        sr.sprite = drop.Icon;
        PickupItem li = d.GetComponent<PickupItem>();
        li.item = drop;
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage){
        this.currentHealth -= damage;
        if(this.currentHealth <= 0){
            this.dead = true;
        }
    }
}
