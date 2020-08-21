using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRelic : MonoBehaviour
{
	[SerializeField] public UsableItem[] relics;
    
    public UsableItem GetRelic(int index){
        if (index >= relics.Length) return null;
        return relics[index];
    }
}
