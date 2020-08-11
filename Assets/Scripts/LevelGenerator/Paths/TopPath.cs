using System.Collections.Generic;
public class TopPath : GeneratePath
{
    public TopPath(){
        this.path = "Map/T/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseT, baseT1E, baseT2E, pitT, pitT1E, pitT2E
        };
    }
    public const string baseT = "T Base";
    public const string baseT1E = "T Base +1";
    public const string baseT2E = "T Base +2";
    public const string pitT = "T Pit";
    public const string pitT1E = "T Pit +1";
    public const string pitT2E = "T Pit +2";
}
