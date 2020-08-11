using System.Collections.Generic;
class TopBottomRightPath : GeneratePath {
    public TopBottomRightPath(){
        this.path = "Map/TBR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseTBR, baseTBR1E, baseTBR2E, pitTBR, pitTBR1E, pitTBR2E
        };
    }
    public const string baseTBR = "TBR Base";
    public const string baseTBR1E = "TBR Base +1";
    public const string baseTBR2E = "TBR Base +2";
    public const string pitTBR = "TBR Pit";
    public const string pitTBR1E = "TBR Pit +1";
    public const string pitTBR2E = "TBR Pit +2";
}