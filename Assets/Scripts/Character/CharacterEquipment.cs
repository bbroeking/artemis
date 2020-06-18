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
        head = null;
        chest = null;
        legs = null;
        ring1 = null;
        ring2 = null;
        trinket1 = null;
        trinket2 = null;
    }
}
