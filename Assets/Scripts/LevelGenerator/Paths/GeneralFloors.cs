using System.Collections.Generic;

class GeneralFloors : GeneratePath {

    public GeneralFloors(){
        this.general = new List<string>{
            base1E, base2E, pit1E, pit2E, boss, spikes
        };
    }
    public const string base1E = "Base +1";
    public const string base2E = "Base +2";
    public const string pit1E = "Pit +1";
    public const string pit2E = "Pit +2";
    public const string boss = "Boss";
    public const string spikes = "Spikes";
}