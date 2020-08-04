using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

public class LootTable : MonoBehaviour
{
    // Loot Generator
    private int randomNumber;
    private int total;
    private int count;

    [SerializeField] Enemy enemy;

    [Header("Loot Table")]
    public List<Item> loot;

    [Header("Drop Prefabs")]
    [SerializeField] GameObject droppedItem;
    [SerializeField] GameObject droppedCurrency;    

    private void OnValidate(){
        enemy = gameObject.GetComponentInParent<Enemy>();
        droppedItem = (GameObject) LoadPrefab.LoadPrefabFromFile("Dropped/DroppedItem");
        droppedCurrency = (GameObject) LoadPrefab.LoadPrefabFromFile("Dropped/DroppedCurrency");
    }
    public void SpawnLoot(){
        Item drop = GenerateDrop();
        GameObject loot = Instantiate(droppedItem, transform.position, Quaternion.identity);
        SetLoot(drop, loot);
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
