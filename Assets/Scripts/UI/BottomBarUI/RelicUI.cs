using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicUI : ItemContainer
{
    private Player player;
    private PlayerRelic playerRelic;
    private List<UsableItem> relics;
    [SerializeField] private ItemTooltip itemTooltip;
    [SerializeField] private UISingleton uISingleton;

    protected override void Awake(){
        base.Awake();
    }
    void Start()
    {
        player = PlayerSingleton.Instance.player;
        playerRelic = player.relics;
        relics = playerRelic.relics;
        SetStartingItems();

        uISingleton = UISingleton.Instance;
        itemTooltip = uISingleton.GetComponentInChildren<ItemTooltip>();

        this.OnPointerEnterEvent += ShowTooltip;
        this.OnPointerExitEvent += HideTooltip;
    }

    public void UpdateRelicsUI(){
        Clear();
        relics = playerRelic.relics;
        AddRelics();
    }
    private void SetStartingItems()
	{
		Clear();
        AddRelics();
	}

    private void AddRelics(){
        foreach (Item item in relics)
		{
			AddItem(item.GetCopy());
		}
    }
 
	private void ShowTooltip(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
			itemTooltip.ShowTooltip(itemSlot.Item);
	}
	private void HideTooltip(BaseItemSlot itemSlot)
	{
		if (itemTooltip.gameObject.activeSelf)
		{
			itemTooltip.HideTooltip();
		}
	}
}
