public interface IItemContainer
{
	bool CanAddItem(Item item);
	bool AddItem(Item item);
	Item RemoveItem(string itemID);
	bool RemoveItem(Item item);
	void Clear();
}
