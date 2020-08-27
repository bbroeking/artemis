using System.Collections.Generic;

public abstract class GeneratePath
{
    public List<string> floors;

    public virtual string GenerateRandomFloorPath(){
        var random = new System.Random();
        int index = random.Next(floors.Count);
        return "Rooms/Maps/Floors/" + floors[index];
    }

}
