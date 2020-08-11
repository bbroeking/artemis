using System.Collections.Generic;
public class BottomPath : GeneratePath
{
    public BottomPath(){
        this.path = "Map/B/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseB, baseB1E, baseB2E, pitB, pitB1E, pitB2E
        };
    }
    public const string baseB = "B Base";
    public const string baseB1E = "B Base +1";
    public const string baseB2E = "B Base +2";
    public const string pitB = "B Pit";
    public const string pitB1E = "B Pit +1";
    public const string pitB2E = "B Pit +2";
}
