﻿using System.Collections;
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
    [SerializeField] private bool dropItem;
    [SerializeField] private bool dropCurrency;
    [SerializeField] private int minCurrencyDrop;
    [SerializeField] private int maxCurrencyDrop;


    [Header("Drop Prefabs")]
    [SerializeField] GameObject droppedItem;
    [SerializeField] GameObject droppedCurrency;
    [SerializeField] GameObject soul;
    public static System.Random random = new System.Random();  

    private void OnValidate(){
        droppedItem = (GameObject) LoadPrefab.LoadPrefabFromFile("FloorLoot/FloorItem");
        droppedCurrency = (GameObject) LoadPrefab.LoadPrefabFromFile("FloorLoot/DroppedCurrency");
        soul = (GameObject) LoadPrefab.LoadPrefabFromFile("FloorLoot/Soul");
    }

    public void SpawnLoot(){
        if(dropItem){
            Item drop = GenerateDrop();
            if (drop == null) return;
            GameObject loot = Instantiate(droppedItem, transform.position, Quaternion.identity);
            SetLoot(drop, loot);
        }
        else if (dropCurrency) {
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
        FloorItem pickupItem = loot.GetComponent<FloorItem>();
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
