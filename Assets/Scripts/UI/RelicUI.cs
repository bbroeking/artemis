using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicUI : ItemContainer
{
    private Player player;
    private PlayerRelic playerRelic;
    private List<UsableItem> relics;
    protected override void Awake(){

    }
    void Start()
    {
        player = PlayerSingleton.Instance.player;
        playerRelic = player.relics;
        relics = playerRelic.relics;
        SetStartingItems();
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
}
