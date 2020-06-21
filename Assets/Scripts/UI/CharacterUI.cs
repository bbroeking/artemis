using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : TogglePanel
{
    public UIItem mainhand;
    public UIItem offhand;
    public UIItem headslot;
    public UIItem chestslot;
    public UIItem legslot;
    public UIItem ringslot1;
    public UIItem ringslot2;
    public UIItem trinketslot1;
    public UIItem trinketslot2;
    public Inventory inventory;

    public override void Awake(){
        base.Awake();
        inventory = GameObject.FindGameObjectWithTag("player").GetComponent<Inventory>();
    }
    public void ToggleCharacter(){
        if(active){
            HideCharacter();
            active = false;
        } else {
            ShowCharacter();
            active = true;
        }
    }
    public void ShowCharacter(){
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public void HideCharacter(){
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
