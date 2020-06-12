using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject item;
    public void Hit()
    {

        Item drop = GetComponent<LootTable>().GenerateDrop();
        GameObject d = Instantiate(item, transform.position, Quaternion.identity);
        SpriteRenderer sr = d.GetComponent<SpriteRenderer>();
        sr.color = Color.cyan;
        sr.sprite = drop.icon;
        LootInfo li = d.GetComponent<LootInfo>();
        li.item = drop;

        Destroy(this.gameObject);
    }
}
