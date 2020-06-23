using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    [SerializeField] ItemTooltip tooltip;
    private Item _item;
    public event Action<Item> OnRightClickEvent;

    public Item Item {
        get { return _item; }
        set {
            _item = value;
            if(_item == null) {
                image.enabled = false;
            } else {
                image.sprite = _item.sprite;
                image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if(Item != null && OnRightClickEvent != null)
                OnRightClickEvent(Item);
        }
    }

    protected virtual void OnValidate() {
        if (image == null) {
            image = GetComponent<Image>();
        }
        if(tooltip == null){
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Item is EquippableItem){
            tooltip.ShowTooltip((EquippableItem)Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

    Vector2 originalPos;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPos = image.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.transform.position = originalPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        image.transform.position = Input.mousePosition;
    }
}
