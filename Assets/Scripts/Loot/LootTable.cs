using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public List<Loot> lootIds;
    public List<int> dropWeights;
    private int randomNumber;
    private int total;
    private int count;

    public Item GenerateDrop(){
        total = 0;
        count = 0;

        for (int i = 0; i < dropWeights.Count; i++){
            total += dropWeights[i];
        }
        randomNumber = Random.Range(0, total);
        for (int i = 0; i < dropWeights.Count; i++){
            count += dropWeights[i];
            if (randomNumber <= count){
                Debug.Log(lootIds[i].id);
                return ItemDB.Instance.GetItem(lootIds[i].id);
            }
        }
        return null;
    }
}
