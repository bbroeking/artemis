using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicUI : ItemContainer
{
    private Player player;
    private PlayerRelic playerRelic;
    private Item[] relics;
    protected override void Awake(){

    }
    void Start()
    {
        player = PlayerSingleton.Instance.player;
        playerRelic = player.relics;
        relics = playerRelic.relics;
        SetStartingItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetStartingItems()
	{
		Clear();
		foreach (Item item in relics)
		{
			AddItem(item.GetCopy());
		}
	}
}
