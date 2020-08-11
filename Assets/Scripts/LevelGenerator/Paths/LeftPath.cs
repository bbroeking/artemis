using System.Collections.Generic;
class LeftPath : GeneratePath{
    public LeftPath(){
        this.path = "Map/L/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseL, baseL1E, baseL2E, pitL, pitL1E, pitL2E
        };
    }
    // L
    public const string baseL = "L Base";
    public const string baseL1E = "L Base +1";
    public const string baseL2E = "L Base +2";
    public const string pitL = "L Pit";
    public const string pitL1E = "L Pit +1";
    public const string pitL2E = "L Pit +2";

}