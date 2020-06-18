using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Loot loot;
    private Image spriteImage;
    private UIItem selectedItem;
    private ToolTip tooltip;
    private Inventory inventory;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        tooltip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        inventory = GameObject.FindGameObjectWithTag("player").GetComponent<Inventory>();
        UpdateItem(null);
    }

    public void UpdateItem(Loot loot)
    {
        this.loot = loot;
        if(this.loot != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.loot.sprite;
        } else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        List<string> tags = eventData.pointerEnter.gameObject.GetComponent<Tags>()?.tags;
        if(tags == null){
            tags = new List<string>();
        }
        if(this.loot != null) // loot in the clicked spot
        {
            if(selectedItem.loot != null) // loot selected
            {
                if(this.loot.lootType == LootType.Equipment){
                    LootEquipment lq = (LootEquipment) selectedItem.loot;
                    if(tags.Contains("head")){
                        inventory.equipment.head = lq;
                    }
                    if(tags.Contains("chest")){
                        inventory.equipment.chest = lq;
                    }
                    if(tags.Contains("legs")){
                        inventory.equipment.legs = lq;
                    }
                    if(tags.Contains("mainhand")){
                        inventory.equipment.mainhand = lq;
                    }
                    if(tags.Contains("offhand")){
                        inventory.equipment.offhand = lq;
                    }
                    if(tags.Contains("ring1")){
                        inventory.equipment.ring1 = lq;
                    }
                    if(tags.Contains("ring2")){
                        inventory.equipment.ring2 = lq;
                    }
                    if(tags.Contains("trinket1")){
                        inventory.equipment.trinket1 = lq;
                    }
                    if(tags.Contains("trinket2")){
                        inventory.equipment.trinket2 = lq;
                    }
                    LootEquipment eqclone =  LootEquipment.CreateLootEquipment(lq);
                    selectedItem.UpdateItem(this.loot);
                    UpdateItem(eqclone);
                } else {
                    Loot clone = Loot.CreateLoot(selectedItem.loot);
                    selectedItem.UpdateItem(this.loot);
                    UpdateItem(clone);
                }
            } else
            {
                if(this.loot.lootType == LootType.Equipment){
                    LootEquipment lq = (LootEquipment) selectedItem.loot;
                    if(tags.Contains("head")){
                        inventory.equipment.head = null;
                    }
                    if(tags.Contains("chest")){
                        inventory.equipment.chest = null;
                    }
                    if(tags.Contains("legs")){
                        inventory.equipment.legs = null;
                    }
                    if(tags.Contains("mainhand")){
                        inventory.equipment.mainhand = null;
                    }
                    if(tags.Contains("offhand")){
                        inventory.equipment.offhand = null;
                    }
                    if(tags.Contains("ring1")){
                        inventory.equipment.ring1 = null;
                    }
                    if(tags.Contains("ring2")){
                        inventory.equipment.ring2 = null;
                    }
                    if(tags.Contains("trinket1")){
                        inventory.equipment.trinket1 = null;
                    }
                    if(tags.Contains("trinket2")){
                        inventory.equipment.trinket2 = null;
                    }
                }
                selectedItem.UpdateItem(this.loot);
                UpdateItem(null);
            }
        } 
        else if (selectedItem.loot != null)
        {
            if(selectedItem.loot.lootType == LootType.Equipment)
            {
                LootEquipment lq = (LootEquipment) selectedItem.loot;
                if (eventData.pointerEnter.tag == "Untagged")
                {
                    UpdateItem(selectedItem.loot);
                    selectedItem.UpdateItem(null);
                }
                else if (tags.Contains(lq.equipmentType.ToString()))
                {
                    if (tags.Contains("ring2")) 
                    {
                        LootEquipment wasEquipped = inventory.EquipItem(lq, 1);
                        selectedItem.UpdateItem(wasEquipped);
                        UpdateItem(lq);
                    }
                    else if (tags.Contains("trinket2"))
                    {
                        LootEquipment wasEquipped = inventory.EquipItem(lq, 1);
                        selectedItem.UpdateItem(wasEquipped);
                        UpdateItem(lq);
                    }
                    else 
                    {
                        LootEquipment wasEquipped = inventory.EquipItem(lq, 0);
                        selectedItem.UpdateItem(wasEquipped);
                        UpdateItem(lq);
                    }
                }
            } 
            else 
            {
                UpdateItem(selectedItem.loot);
                selectedItem.UpdateItem(null);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.loot != null)
        {
            tooltip.ShowTooltip();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }


}
