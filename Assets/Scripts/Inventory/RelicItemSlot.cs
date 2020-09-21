using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RelicItemSlot : ItemSlot
{
    [SerializeField] protected Image minionHP;
    [SerializeField] private Player player;

    void Start() {
        player = PlayerSingleton.Instance.player;
    }

    void Update(){
        if (((UsableItem) _item).demonType == DemonType.Imp) CheckImp();
    }
    private void CheckImp(){
        
    }
    public void SetHPActive(){
        Debug.Log("active");
        minionHP.enabled = true;
    }

    public void SetHPInactive(){
        minionHP.enabled = false;
    }

    public void UpdateHP(float percentage){
        minionHP.transform.localScale = new Vector3(percentage, 1, 1);
    }
}
