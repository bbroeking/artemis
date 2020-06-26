using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<Item> loot;
    private int randomNumber;
    private int total;
    private int count;

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
