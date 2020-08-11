using System.Collections.Generic;
class BottomRightPath : GeneratePath {
    public BottomRightPath(){
        this.path = "Map/BR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseBR, baseBR1E, baseBR2E, pitBR, pitBR1E, pitBR2E
        };
    }
    public const string baseBR = "BR Base";
    public const string baseBR1E = "BR Base +1";
    public const string baseBR2E = "BR Base +2";
    public const string pitBR = "BR Pit";
    public const string pitBR1E = "BR Pit +1";
    public const string pitBR2E = "BR Pit +2";

}