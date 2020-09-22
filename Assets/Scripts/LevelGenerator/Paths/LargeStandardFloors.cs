using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeStandardFloors : FloorSet
{
    public LargeStandardFloors(){
        this.floorSetPath = "Rooms/Maps/Floors/LargeStandard/";
        this.floors = new List<string>{
            base1E,
            base2E
        };
    }
    public const string base1E = "Base +1";
    public const string base2E = "Base +2";
}
