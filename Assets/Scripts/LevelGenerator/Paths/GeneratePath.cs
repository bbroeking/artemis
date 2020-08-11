using System.Collections.Generic;

public abstract class GeneratePath
{
    public string path;
    public string boss;
    public List<string> general;

    public virtual string GenerateBossRoomPath(){
        return path + boss;
    }

    public virtual string GenerateRandomRoomPath(){
        var random = new System.Random();
        int index = random.Next(general.Count);
        return path + general[index];
    }


}
