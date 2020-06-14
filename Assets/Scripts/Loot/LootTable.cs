using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<Loot> loot;
    private int randomNumber;
    private int total;
    private int count;

    public Loot GenerateDrop(){
        total = 0;
        count = 0;

        for (int i = 0; i < loot.Count; i++){
            total += loot[i].weight;
        }
        randomNumber = Random.Range(0, total);
        for (int i = 0; i < loot.Count; i++){
            count += loot[i].weight;
            if (randomNumber <= count){
                return loot[i];
            }
        }
        return null;
    }
}
