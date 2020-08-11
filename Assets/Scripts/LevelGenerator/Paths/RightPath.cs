using System.Collections.Generic;
class RightPath : GeneratePath {
    public RightPath(){
        this.path = "Map/R/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseR, baseR1E, baseR2E, pitR, pitR1E, pitR2E
        };
    }
    public const string baseR = "R Base";
    public const string baseR1E = "R Base +1";
    public const string baseR2E = "R Base +2";
    public const string pitR = "R Pit";
    public const string pitR1E = "R Pit +1";
    public const string pitR2E = "R Pit +2";
}