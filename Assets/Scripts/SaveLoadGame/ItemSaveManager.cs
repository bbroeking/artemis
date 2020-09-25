using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
	[SerializeField] ItemDatabase itemDatabase;

	private const string InventoryFileName = "Inventory";
	private const string EquipmentFileName = "Equipment";
	private const string CurrencyFileName = "Currency";

	// public void LoadInventory(Player player)
	// {
	// 	ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName);
	// 	if (savedSlots == null) return;
	// 	player.Inventory.Clear();

	// 	for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
	// 	{
	// 		ItemSlot itemSlot = player.Inventory.ItemSlots[i];
	// 		ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

	// 		if (savedSlot == null)
	// 		{
	// 			itemSlot.Item = null;
	// 		}
	// 		else
	// 		{
	// 			itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
	// 		}
	// 	}
	// }

	// public void LoadEquipment(Player player)
	// {
	// 	ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EquipmentFileName);
	// 	if (savedSlots == null) return;

	// 	foreach (ItemSlotSaveData savedSlot in savedSlots.SavedSlots)
	// 	{
	// 		if (savedSlot == null) {
	// 			continue;
	// 		}
	// 		Item item = itemDatabase.GetItemCopy(savedSlot.ItemID);
	// 		player.Inventory.AddItem(item);
	// 		player.Equip((EquippableItem)item);
	// 	}
	// }

	public void LoadCurrency(Player player){
		CurrencySaveData save = ItemSaveIO.LoadCurrency(CurrencyFileName);
		if (save == null) return;
		player.Souls = save.souls;
	}

	// public void SaveInventory(Player player)
	// {
	// 	SaveItems(player.Inventory.ItemSlots, InventoryFileName);
	// }

	// public void SaveEquipment(Player player)
	// {
	// 	SaveItems(player.EquipmentPanel.equipmentSlots, EquipmentFileName);
	// }
	private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
	{
		var saveData = new ItemContainerSaveData(itemSlots.Count);

		for (int i = 0; i < saveData.SavedSlots.Length; i++)
		{
			ItemSlot itemSlot = itemSlots[i];

			if (itemSlot.Item == null) {
				saveData.SavedSlots[i] = null;
			} else {
				saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID);
			}
		}

		ItemSaveIO.SaveItems(saveData, fileName);
	}

	private void SaveCurrencies(int gold, int souls, string filename){
		var saveData = new CurrencySaveData(gold, souls);
		ItemSaveIO.SaveCurrencies(saveData, filename);
	}
}