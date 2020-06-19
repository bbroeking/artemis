using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment
{
    public LootEquipment mainhand;
    public LootEquipment offhand;
    public LootEquipment head;
    public LootEquipment chest;
    public LootEquipment legs;
    public LootEquipment ring1;
    public LootEquipment ring2;
    public LootEquipment trinket1;
    public LootEquipment trinket2;

    public CharacterEquipment(){
        mainhand = null;
        offhand = null;
        head = null;
        chest = null;
        legs = null;
        ring1 = null;
        ring2 = null;
        trinket1 = null;
        trinket2 = null;
    }

    public List<LootEquipment> GetEquipment(){
        List<LootEquipment> equipped = new List<LootEquipment>();
        if(head != null){
            equipped.Add(head);
        }
        if(chest != null){
            equipped.Add(chest);
        }
        if(legs != null){
            equipped.Add(legs);
        }
        if(ring1 != null){
            equipped.Add(ring1);
        }
        if(ring2 != null){
            equipped.Add(ring2);
        }
        if(trinket1 != null){
            equipped.Add(trinket1);
        }
        if(trinket2 != null){
            equipped.Add(trinket2);
        }
        if(mainhand != null){
            equipped.Add(mainhand);
        }
        if(offhand != null){
            equipped.Add(offhand);
        }
        return equipped;
    }
}
