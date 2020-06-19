using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

    public GameObject item;
    public void Hit()
    {

        Loot drop = GetComponent<LootTable>().GenerateDrop();
        GameObject d = Instantiate(item, transform.position, Quaternion.identity);
        SpriteRenderer sr = d.GetComponent<SpriteRenderer>();
        sr.sprite = drop.sprite;
        LootInfo li = d.GetComponent<LootInfo>();
        li.loot = drop;

        Destroy(this.gameObject);
    }
}
