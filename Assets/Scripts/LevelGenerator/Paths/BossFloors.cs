using System.Collections.Generic;

class BossFloors : FloorSet {

    public BossFloors(){
        this.floors = new List<string>{
            slimeBoss
        };
    }

    // Boss Rooms
    public const string slimeBoss = "SlimeBoss";

    public override string GenerateRandomFloorPath(){
        var random = new System.Random();
        int index = random.Next(floors.Count);
        return "Rooms/Maps/Floors/BossFloors/" + floors[index];
    }
}