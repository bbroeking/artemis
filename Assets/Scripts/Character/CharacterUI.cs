using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public UIItem headslot;
    public UIItem chestslot;
    public UIItem legslot;
    public UIItem ringslot1;
    public UIItem ringslot2;
    public UIItem trinketslot1;
    public UIItem trinketslot2;

    void Awake(){
        gameObject.SetActive(false);
    }
}
