using System.Collections.Generic;

class TopLeftPath : GeneratePath {

    public TopLeftPath(){
        this.path = "Map/TL/";
        this.boss = "";
        this.general = new List<string>{
            baseTL, baseTL1E, baseTL2E, pitTL, pitTL1E, pitTL2E
        };
    }
    public const string baseTL = "TL Base";
    public const string baseTL1E = "TL Base +1";
    public const string baseTL2E ="TL Base +2";
    public const string pitTL =  "TL Pit";
    public const string pitTL1E = "TL Pit +1";
    public const string pitTL2E = "TL Pit +2";
}