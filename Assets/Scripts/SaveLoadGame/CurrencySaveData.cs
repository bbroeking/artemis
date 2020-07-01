using System;

[Serializable]
public class CurrencySaveData
{
	public int gold;
    public int souls;

	public CurrencySaveData(int gold, int souls)
	{
		this.gold = gold;
        this.souls = souls;
	}
}