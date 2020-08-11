using System.Collections.Generic;
class TopBottomPath : GeneratePath {
    public TopBottomPath(){
        this.path = "Map/TB/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseTB, baseTB1E, baseTB2E, pitTB, pitTB1E, pitTB2E
        };
    }
    public const string baseTB = "TB Base";
    public const string baseTB1E = "TB Base +1";
    public const string baseTB2E = "TB Base +2";
    public const string pitTB = "TB Pit";
    public const string pitTB1E = "TB Pit +1";
    public const string pitTB2E = "TB Pit +2";

}