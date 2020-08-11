using System.Collections.Generic;

class TopRightPath: GeneratePath {

    public TopRightPath(){
        this.path = "Map/TR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseTR, baseTR1E, baseTR2E, pitTR, pitTR1E, pitTR2E
        };
    }
    public const string TRPath = "Map/TR/";
    public const string baseTR = "TR Base";
    public const string baseTR1E = "TR Base +1";
    public const string baseTR2E = "TR Base +2";
    public const string pitTR = "TR Pit";
    public const string pitTR1E = "TR Pit +1";
    public const string pitTR2E = "TR Pit +2";
}