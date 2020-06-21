using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : TogglePanel
{
    public List<UIItem> UIItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 40;
    [SerializeField]
    private Player player;
    [SerializeField]
    private Text goldText;
    [SerializeField]
    private Text soulText;
    [SerializeField]
    private Text weightText;

    public override void Awake()
    {
        base.Awake();
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            UIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }
    void Update(){
        if(active){
            goldText.text = player.GetGold().ToString();
            soulText.text = player.GetSoul().ToString();
            weightText.text = player.GetWeight().ToString();
        }
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
