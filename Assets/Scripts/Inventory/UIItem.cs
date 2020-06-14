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

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        tooltip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
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
            if(selectedItem.loot != null)
            {
                Loot clone = new Loot(selectedItem.loot);
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
        Debug.Log("enter");
        if(this.loot != null)
        {
            tooltip.GenerateTooltip(this.loot);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }


}
