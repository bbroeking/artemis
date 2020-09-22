using System.Collections.Generic;

public abstract class FloorSet
{
    public string floorSetPath;
    public List<string> floors;

    public virtual string GenerateRandomFloorPath(){
        var random = new System.Random();
        int index = random.Next(floors.Count);
        return floorSetPath + floors[index];
    }

}
