using System.Collections.Generic;
class TopBottomLeftRightPath : GeneratePath {

    public TopBottomLeftRightPath(){
        this.path = "Map/TBLR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseTBLR, baseTBLR1E, baseTBLR2E, pitTBLR, pitTBLR1E, pitTBLR2E
        };
    }
    public const string baseTBLR = "TBLR Base";
    public const string baseTBLR1E = "TBLR Base +1";
    public const string baseTBLR2E = "TBLR Base +2";
    public const string pitTBLR = "TBLR Pit";
    public const string pitTBLR1E = "TBLR Pit +1";
    public const string pitTBLR2E = "TBLR Pit +2";

}