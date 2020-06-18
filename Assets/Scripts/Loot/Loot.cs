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
    public int lootWeight;
    public string description;
    public Sprite sprite;
    public Dictionary<string, int> stats;
    public int weight;
    public LootType lootType;

    // public abstract Loot(Loot item);
    private void Init(int id, string lootName, int lootWeight, string description, Sprite sprite, Dictionary<string, int> stats, int weight, LootType lootType){
        this.id = id;
        this.lootName = lootName;
        this.lootWeight = lootWeight;
        this.description = description;
        this.sprite = sprite;
        this.stats = stats;
        this.weight = weight;
        this.lootType = lootType;
    }

    private void Init(Loot item){
        this.id = item.id;
        this.lootName = item.lootName;
        this.lootWeight = item.lootWeight;
        this.description = item.description;
        this.sprite = item.sprite;
        this.stats = item.stats;
        this.weight = item.weight;
        this.lootType = item.lootType;
    }
    public static Loot CreateLoot(int id, string lootName, int lootWeight, string description, Sprite sprite, Dictionary<string, int> stats, int weight, LootType lootType){
        Loot loot = ScriptableObject.CreateInstance<Loot>();

        loot.Init(id, lootName, lootWeight, description, sprite, stats, weight, lootType);

        return loot;
    }

    public static Loot CreateLoot(Loot item){
        Loot loot = ScriptableObject.CreateInstance<Loot>();

        loot.Init(item);

        return loot;
    }
}
