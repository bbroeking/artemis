using System.Collections.Generic;
class LeftRightPath : GeneratePath{

    public LeftRightPath(){
        this.path = "Map/LR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseL, baseL1E, baseL2E, pitL, pitL1E, pitL2E
        };
    }
    public const string baseL = "LR Base";
    public const string baseL1E = "LR Base +1";
    public const string baseL2E = "LR Base +2";
    public const string pitL = "LR Pit";
    public const string pitL1E = "LR Pit +1";
    public const string pitL2E = "LR Pit +2";
}