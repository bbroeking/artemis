﻿using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemContainer : MonoBehaviour, IItemContainer
{
	public List<ItemSlot> ItemSlots;
	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;
	public event Action<BaseItemSlot> OnRightClickEvent;
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

	protected virtual void OnValidate()
	{
		GetComponentsInChildren(includeInactive: true, result: ItemSlots);
	}

	protected virtual void Awake()
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			ItemSlots[i].OnPointerEnterEvent += slot => EventHelper(slot, OnPointerEnterEvent);
			ItemSlots[i].OnPointerExitEvent += slot => EventHelper(slot, OnPointerExitEvent);
			ItemSlots[i].OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
			ItemSlots[i].OnBeginDragEvent += slot => EventHelper(slot, OnBeginDragEvent);
			ItemSlots[i].OnEndDragEvent += slot => EventHelper(slot, OnEndDragEvent);
			ItemSlots[i].OnDragEvent += slot => EventHelper(slot, OnDragEvent);
			ItemSlots[i].OnDropEvent += slot => EventHelper(slot, OnDropEvent);
		}
	}

	private void EventHelper(BaseItemSlot itemSlot, Action<BaseItemSlot> action)
	{
		if (action != null)
			action(itemSlot);
	}

	public virtual bool AddItem(Item item)
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if (ItemSlots[i].Item == null)
			{
				ItemSlots[i].Item = item;
				PlayerSingleton.Instance.player.SetPlayerCurrency();
				return true;
			}
		}
		return false;
	}

	public virtual bool RemoveItem(Item item)
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if (ItemSlots[i].Item == item)
			{
				ItemSlots[i].Item = null;
				PlayerSingleton.Instance.player.SetPlayerCurrency();
				return true;
			}
		}
		return false;
	}

	public virtual Item RemoveItem(string itemID)
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			Item item = ItemSlots[i].Item;
			if (item != null && item.ID == itemID)
			{
				return item;
			}
		}
		return null;
	}
	public void Clear()
	{
		for (int i = 0; i < ItemSlots.Count; i++)
		{
			if (ItemSlots[i].Item != null && Application.isPlaying) {
				ItemSlots[i].Item.Destroy();
			}
			ItemSlots[i].Item = null;
		}
	}

    public bool CanAddItem(Item item)
    {
        foreach (ItemSlot itemSlot in ItemSlots)
		{
			if (itemSlot.Item == null)
			{
				return true;
			}
		}
		return false;
    }
}