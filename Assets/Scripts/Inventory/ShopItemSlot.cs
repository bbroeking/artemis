using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ShopItemSlot : ItemSlot
{
    [SerializeField] public TextMeshProUGUI amountText;

    public override bool CanReceiveItem(Item item)
	{
		return Item == null;
	}

    public override Item Item {
		get { return _item; }
		set {
			_item = value;

			if (_item == null) {
				image.sprite = null;
				image.color = disabledColor;
                amountText.alpha = 0;
			} else {
				image.sprite = _item.Icon;
				image.color = normalColor;
                amountText.alpha = 1;
                amountText.text = _item.goldValue.ToString();
			}

			if (isPointerOver)
			{
				OnPointerExit(null);
				OnPointerEnter(null);
			}
		}
	}
}
