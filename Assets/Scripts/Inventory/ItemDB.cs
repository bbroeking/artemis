using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB Instance {get; set;}
    public List<Item> items;

    private void Awake()
    {
        if(Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        BuildMockDB();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildMockDB()
    {
        items = new List<Item>()
        {
            new Item(0, 
                    "bomb_ui_item", "It blows things",
                    new Dictionary<string, int>
                    {
                        {"damage", 10}
                    }),
            new Item(1,
                    "Item__69", "It blows things",
                    new Dictionary<string, int>
                    {
                        {"damage", 10}
                    })
        };
    }
}
