using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenerateShop : MonoBehaviour
{
    public List<Loot> shopInventory;
    [SerializeField]
    private Transform shopTemplate;
    [SerializeField]
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    void Awake(){
        for (int i = 0; i < shopInventory.Count; i++)
        {
            CreateLootButton(shopInventory[i], i);
        }
        //shopTemplate.gameObject.SetActive(false);
    } 

    private void CreateLootButton(Loot loot, int position){
        GameObject instance = Instantiate(slotPrefab);
        instance.transform.SetParent(slotPanel);
        UIItems.Add(instance.GetComponentInChildren<UIItem>());

        instance.GetComponentInChildren<UIItem>().UpdateItem(loot);
        instance.GetComponentInChildren<TextMeshProUGUI>().SetText(loot.cost.ToString());
    }
}
