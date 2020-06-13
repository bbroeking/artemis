using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats;

    public Item(int id, string title, string description, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        icon = Resources.Load<Sprite>("Sprites/items/" + title);
        this.stats = stats;
    }

    public Item(Item item)
    {
        id = item.id;
        title = item.title;
        description = item.description;
        icon = Resources.Load<Sprite>("Sprites/items/" + item.title);
        stats = item.stats;
    }
}
