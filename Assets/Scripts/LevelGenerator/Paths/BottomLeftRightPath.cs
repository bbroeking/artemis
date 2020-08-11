using System.Collections.Generic;
class BottomLeftRightPath : GeneratePath {
    public BottomLeftRightPath(){
        this.path = "Map/BLR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseBLR, baseBLR1E, baseBLR2E, pitBLR, pitBLR1E, pitBLR2E
        };
    }
    public const string baseBLR = "BLR Base";
    public const string baseBLR1E = "BLR Base +1";
    public const string baseBLR2E = "BLR Base +2";
    public const string pitBLR = "BLR Pit";
    public const string pitBLR1E = "BLR Pit +1";
    public const string pitBLR2E = "BLR Pit +2";

}