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

    // public abstract Loot(Loot item);
    private void Init(int id, string lootName, string description, Sprite sprite, Dictionary<string, int> stats, int weight, LootType lootType){
        this.id = id;
        this.lootName = lootName;
        this.description = description;
        this.sprite = sprite;
        this.stats = stats;
        this.weight = weight;
        this.lootType = lootType;
    }

    private void Init(Loot item){
        this.id = item.id;
        this.lootName = item.lootName;
        this.description = item.description;
        this.sprite = item.sprite;
        this.stats = item.stats;
        this.weight = item.weight;
        this.lootType = item.lootType;
    }
    public static Loot CreateLoot(int id, string lootName, string description, Sprite sprite, Dictionary<string, int> stats, int weight, LootType lootType){
        Loot loot = ScriptableObject.CreateInstance<Loot>();

        loot.Init(id, lootName, description, sprite, stats, weight, lootType);

        return loot;
    }

    public static Loot CreateLoot(Loot item){
        Loot loot = ScriptableObject.CreateInstance<Loot>();

        loot.Init(item);

        return loot;
    }
}
