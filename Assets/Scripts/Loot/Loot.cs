using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LootType{
    Default,
    Equipment
}
[CreateAssetMenu(fileName = "New Loot", menuName = "Loot")]
public class Loot : ScriptableObject
{
    public int id; 
    public string lootName;
    public string description;
    public Sprite sprite;
    public Dictionary<string, int> stats;
    public int weight;
    public LootType lootType;

    public Loot(int id, string lootName, string description, Dictionary<string, int> stats, int weight, LootType lootType)
    {
        this.id = id;
        this.lootName = lootName;
        this.description = description;
        this.stats = stats;
        this.weight = weight;
        this.lootType = lootType;
    }

    public Loot(Loot item)
    {
        id = item.id;
        lootName = item.lootName;
        description = item.description;
        stats = item.stats;
        weight = item.weight;
        lootType = item.lootType;
    }
}
