using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
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
    private CanvasGroup cvg;
    private bool active;


    void Awake(){
        inventory = GameObject.FindGameObjectWithTag("player").GetComponent<Inventory>();
        cvg = gameObject.GetComponent<CanvasGroup>();
        HideCharacter();
        active = false;
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
        cvg.alpha = 1;
        cvg.blocksRaycasts = true;
    }
    public void HideCharacter(){
        cvg.alpha = 0;
        cvg.blocksRaycasts = false;
    }
}
