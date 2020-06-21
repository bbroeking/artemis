using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateShopUI : TogglePanel
{
    public List<Loot> shopInventory;
    [SerializeField]
    public GameObject slotPrefab;
    public Transform slotPanel;
    public GameObject shopPanel;
    private List<GameObject> slots = new List<GameObject>();

    public void GenerateShopForShopkeeper(List<Loot> shopkeeperInventory){
        shopInventory = shopkeeperInventory;
        for (int i = 0; i < shopInventory.Count; i++)
        {
            CreateLootButton(shopInventory[i], i);
        }
    }
    private void CreateLootButton(Loot loot, int position){
        GameObject instance = Instantiate(slotPrefab);
        instance.transform.SetParent(slotPanel);
        slots.Add(instance);

        instance.GetComponentInChildren<UIItem>().UpdateItem(loot);
        instance.GetComponentInChildren<TextMeshProUGUI>().SetText(loot.cost.ToString());
    }
    public void ClearShop() {
        foreach(GameObject slot in slots){
            Destroy(slot);
        }
    }
}
