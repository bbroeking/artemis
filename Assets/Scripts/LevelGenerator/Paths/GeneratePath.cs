using System.Collections.Generic;

public abstract class GeneratePath
{
    public List<string> general;

    public virtual string GenerateRandomFloorPath(){
        var random = new System.Random();
        int index = random.Next(general.Count);
        return "Rooms/Maps/Floors/" + general[index];
    }

}
