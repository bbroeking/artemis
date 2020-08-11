using System.Collections.Generic;

class BottomLeftPath : GeneratePath {

    public BottomLeftPath(){
        this.path = "Map/BL/";
        this.boss = "";
        this.general = new List<string>{
            baseBL, baseBL1E, baseBL2E, pitBL, pitBL1E, pitBL2E
        };
    }
    public const string baseBL = "BL Base";
    public const string baseBL1E = "BL Base +1";
    public const string baseBL2E = "BL Base +2";
    public const string pitBL = "BL Pit";
    public const string pitBL1E = "BL Pit +1";
    public const string pitBL2E = "BL Pit +2";
}