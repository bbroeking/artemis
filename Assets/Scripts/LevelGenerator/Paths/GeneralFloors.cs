using System.Collections.Generic;

class GeneralFloors : GeneratePath {

    public GeneralFloors(){
        this.floors = new List<string>{
            base1E,
            // base2E,
            // pit1E, pit2E, baseRocks,
            //spikes
        };
    }
    public const string base1E = "Base +1";
    // public const string base2E = "Base +2";
    // public const string pit1E = "Pit +1";
    // public const string pit2E = "Pit +2";
    // public const string spikes = "Spikes";
    // public const string baseRocks = "Base Rocks +1";
}