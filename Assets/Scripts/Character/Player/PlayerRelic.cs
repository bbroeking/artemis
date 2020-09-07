using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRelic : MonoBehaviour
{
	[SerializeField] public List<UsableItem> relics; //TODO private after testing
    [SerializeField] private RelicUI relicUI;
    private int maxRelics = 4;
    
    private void Start(){
        relicUI = FindObjectOfType<RelicUI>();
    }
    public UsableItem GetRelic(int index){
        if (index >= relics.Count) return null;
        return relics[index];
    }

    public void AddRelic(UsableItem item){
        if (relics.Count == maxRelics) return;
        relics.Add(item);
        relicUI.UpdateRelicsUI();
    }
}
