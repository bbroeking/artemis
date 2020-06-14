using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Loot", menuName = "Loot")]
public class Loot : ScriptableObject
{
    public int id; 
    public string lootName;
    public string description;
    public Sprite sprite;
    public Dictionary<string, int> stats;
    public int weight;

    public Loot(int id, string lootName, string description, Dictionary<string, int> stats, int weight)
    {
        this.id = id;
        this.lootName = lootName;
        this.description = description;
        this.stats = stats;
        this.weight = weight;
    }

    public Loot(Loot item)
    {
        id = item.id;
        lootName = item.lootName;
        description = item.description;
        stats = item.stats;
        weight = item.weight;
    }
}
