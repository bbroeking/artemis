using System.Collections.Generic;

class BossFloors : FloorSet {

    public BossFloors(){
        this.floorSetPath = "Rooms/Maps/Floors/BossFloors/";
        this.floors = new List<string>{
            slimeBoss
        };
    }
    public const string slimeBoss = "SlimeBoss";
}