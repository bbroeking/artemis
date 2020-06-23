using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private Image image;
    [SerializeField] ItemTooltip tooltip;
    private Item _item;
    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnPointerEnterEvent;
    public event Action<ItemSlot> OnPointerExitEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;
    public event Action<ItemSlot> OnEndDragEvent;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);

    public Item Item {
        get { return _item; }
        set {
            _item = value;
            if(_item == null) {
                image.color = disabledColor;
            } else {
                image.sprite = _item.sprite;
                image.color = normalColor;
            }
        }
    }
    public virtual bool CanReceiveItem(Item item)
	{
		return true;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if(OnRightClickEvent != null)
                OnRightClickEvent(this);
        }
    }

    protected virtual void OnValidate() {
        if (image == null) {
            image = GetComponent<Image>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(OnPointerEnterEvent != null){
            OnPointerEnterEvent(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(OnPointerExitEvent != null){
            OnPointerExitEvent(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(OnBeginDragEvent != null){
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(OnEndDragEvent != null){
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(OnDragEvent != null){
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(OnDropEvent != null){
            OnDropEvent(this);
        }
    }
}
