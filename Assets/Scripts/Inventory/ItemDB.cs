using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB Instance {get; set;}
    public List<Loot> items;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public Loot GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Loot GetItem(string itemName)
    {
        return items.Find(item => item.lootName == itemName);
    }
}
