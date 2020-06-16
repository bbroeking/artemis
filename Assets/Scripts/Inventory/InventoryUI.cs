using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 25;
    public CanvasGroup cvg;
    public bool active;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            UIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
        cvg = gameObject.GetComponent<CanvasGroup>();
        HideInventory();
        active = false;
    }
    public void ToggleInventory(){
        if(active){
            HideInventory();
            active = false;
        } else {
            ShowInventory();
            active = true;
        }
    }
    public void ShowInventory(){
        cvg.alpha = 1;
        cvg.blocksRaycasts = true;
    }
    public void HideInventory(){
        cvg.alpha = 0;
        cvg.blocksRaycasts = false;
    }
    public void UpdateSlot(int slot, Loot loot)
    {
        UIItems[slot].UpdateItem(loot);
    }

    public void AddNewItem(Loot loot)
    {
        UpdateSlot(UIItems.FindIndex(i => i.loot == null), loot);
    }

    public void RemoveItem(Loot loot)
    {
        UpdateSlot(UIItems.FindIndex(i => i.loot == loot), null);
    }
}
