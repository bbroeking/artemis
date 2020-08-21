using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    // Loot Generator
    private int randomNumber;
    private int total;
    private int count;

    [Header("Loot Table")]
    public List<Item> loot;

    [Header("Drop Prefabs")]
    [SerializeField] GameObject droppedItem;
    [SerializeField] GameObject droppedCurrency;
    [SerializeField] GameObject soul;
    public static System.Random random = new System.Random();  

    private void OnValidate(){
        droppedItem = (GameObject) LoadPrefab.LoadPrefabFromFile("FloorLoot/DroppedItem");
        droppedCurrency = (GameObject) LoadPrefab.LoadPrefabFromFile("FloorLoot/DroppedCurrency");
        soul = (GameObject) LoadPrefab.LoadPrefabFromFile("FloorLoot/Soul");
    }

    public void SpawnLoot(){
        if(random.Next(0,2) == 3){
            Item drop = GenerateDrop();
            GameObject loot = Instantiate(droppedItem, transform.position, Quaternion.identity);
            SetLoot(drop, loot);
        }
        else {
            int souls = random.Next(1,11);
            for (int i = 0; i < souls; i++){
                Instantiate(soul, 
                            transform.position + ProjectileHelpers.GenerateRandomOffset(),
                            Quaternion.identity);
            }
        }

    }
    private void SetLoot(Item drop, GameObject loot){
        SpriteRenderer spriteRenderer = loot.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = drop.Icon;
        PickupItem pickupItem = loot.GetComponent<PickupItem>();
        pickupItem.item = drop;
    }

    public Item GenerateDrop(){
        total = 0;
        count = 0;

        for (int i = 0; i < loot.Count; i++){
            total += loot[i].dropChance;
        }
        randomNumber = Random.Range(0, total);
        for (int i = 0; i < loot.Count; i++){
            count += loot[i].dropChance;
            if (randomNumber <= count){
                return loot[i];
            }
        }
        return null;
    }
}
