using System.Collections.Generic;
class TopBottomLeftPath : GeneratePath {

    public TopBottomLeftPath(){
        this.path = "Map/TBL/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseTBL, baseTBL1E, baseTBL2E, pitTBL, pitTBL1E, pitTBL2E
        };
    }
    public const string baseTBL = "TBL Base";
    public const string baseTBL1E = "TBL Base +1";
    public const string baseTBL2E = "TBL Base +2";
    public const string pitTBL = "TBL Pit";
    public const string pitTBL1E = "TBL Pit +1";
    public const string pitTBL2E = "TBL Pit +2";
}