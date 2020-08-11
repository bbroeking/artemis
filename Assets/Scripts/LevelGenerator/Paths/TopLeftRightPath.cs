using System.Collections.Generic;
class TopLeftRightPath : GeneratePath {

    public TopLeftRightPath(){
        this.path = "Map/TLR/";
        this.boss = "Boss";
        this.general = new List<string>{
            baseTLR, baseTLR1E, baseTLR2E, pitTLR, pitTLR1E, pitTLR2E
        };
    }
    public const string baseTLR = "TLR Base";
    public const string baseTLR1E = "TLR Base +1";
    public const string baseTLR2E = "TLR Base +2";
    public const string pitTLR = "TLR Pit";
    public const string pitTLR1E = "TLR Pit +1";
    public const string pitTLR2E = "TLR Pit +2";
}