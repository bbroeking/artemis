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
       if(this.loot != null)
        {
            if(this.loot.lootType == LootType.Equipment){
                inventory.EquipItem((LootEquipment)this.loot);
            }
            else if(selectedItem.loot != null)
            {
                Loot clone = Loot.CreateLoot(selectedItem.loot);
                selectedItem.UpdateItem(this.loot);
                UpdateItem(clone);
            } else
            {
                selectedItem.UpdateItem(this.loot);
                UpdateItem(null);
            }
        } else if (selectedItem.loot != null)
        {
            UpdateItem(selectedItem.loot);
            selectedItem.UpdateItem(null);
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
