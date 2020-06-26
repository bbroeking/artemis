using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopPanel : ItemContainer
{
	[SerializeField] protected List<Item> shopItems;
	[SerializeField] protected Transform itemsParent;
	protected override void OnValidate()
	{
		if (itemsParent != null)
			itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);
	}
	protected override void Awake()
	{
		base.Awake();
	}
	public void SetShop(List<Item> items)
	{
		shopItems = items;
		Clear();
		foreach (Item item in shopItems)
		{
			AddItem(item.GetCopy());
		}
	}

}