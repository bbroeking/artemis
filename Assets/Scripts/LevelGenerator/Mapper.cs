using System.Collections.Generic;
using UnityEngine;

public class Mapper : MonoBehaviour
{
    public static List<string> baseRightRoom = new List<string>{MapPath.baseR, MapPath.baseR1E, MapPath.baseR2E,
                                                                MapPath.pitR, MapPath.pitR1E, MapPath.pitR2E};
    public static List<string> baseLeftRoom = new List<string>{MapPath.baseL, MapPath.baseL1E, MapPath.baseL2E,
                                                                MapPath.pitL, MapPath.pitL1E, MapPath.pitL2E};
    public static List<string> baseTopRoom = new List<string>{MapPath.baseT, MapPath.baseT1E, MapPath.baseT2E,
                                                                MapPath.pitT, MapPath.pitT1E, MapPath.pitT2E};
    public static List<string> baseBottomRoom = new List<string>{MapPath.baseB, MapPath.baseB1E, MapPath.baseB2E,
                                                                    MapPath.pitB, MapPath.pitB1E, MapPath.pitB2E};
    public static List<string> baseRightTopRoom = new List<string>{MapPath.baseTR, MapPath.baseTR1E, MapPath.baseTR2E,
                                                                    MapPath.pitTR, MapPath.pitTR1E, MapPath.pitTR2E};
    public static List<string> baseRightBottomRoom = new List<string>{MapPath.baseBR, MapPath.baseBR1E, MapPath.baseBR2E,
                                                                      MapPath.pitBR, MapPath.pitBR1E, MapPath.pitBR2E};
    public static List<string> baseLeftTopRoom = new List<string>{MapPath.baseTL, MapPath.baseTL1E, MapPath.baseTL2E,
                                                                  MapPath.pitTL, MapPath.pitTL1E, MapPath.pitTL2E};
    public static List<string> baseLeftBottomRoom = new List<string>{MapPath.baseBL, MapPath.baseBL1E, MapPath.baseBL2E,
                                                                     MapPath.pitBL, MapPath.pitBL1E, MapPath.pitBL2E};
    public static List<string> baseLeftRightBottomRoom = new List<string>{MapPath.baseBLR, MapPath.baseBLR1E, MapPath.baseBLR2E,
                                                                          MapPath.pitBLR, MapPath.pitBLR1E, MapPath.pitBLR2E};
    public static List<string> baseLeftRightTopRoom = new List<string>{MapPath.baseTLR, MapPath.baseTLR1E, MapPath.baseTLR2E,
                                                                       MapPath.pitTLR, MapPath.pitTLR1E, MapPath.pitTLR2E};
    public static List<string> baseLeftRightTopBottomRoom = new List<string>{MapPath.baseTBLR, MapPath.baseTBLR1E, MapPath.baseTBLR2E,
                                                                             MapPath.pitTBLR, MapPath.pitTBLR1E, MapPath.pitTBLR2E};
    public static List<string> baseLeftTopBottomRoom = new List<string>{MapPath.baseTBL, MapPath.baseTBL1E, MapPath.baseTBL2E,
                                                                        MapPath.pitTBL, MapPath.pitTBL1E, MapPath.pitTBL2E};
    public static List<string> baseTopBottomRoom = new List<string>{MapPath.baseTB, MapPath.baseTB1E, MapPath.baseTB2E,
                                                                    MapPath.pitTB, MapPath.pitTB1E, MapPath.pitTB2E};
    public static List<string> baseLeftRightRoom = new List<string>{MapPath.baseLR, MapPath.baseLR1E, MapPath.baseLR2E,
                                                                    MapPath.pitLR, MapPath.pitLR1E, MapPath.pitLR2E};
    public static List<string> fClosedRoom = null;

    public string SelectRoom(Room room)
    {
        if (room.top)
        {
            if (room.bottom)
            {
                if (room.left)
                {
                    if (room.right)
                    {
                        return SelectScene(baseLeftRightTopBottomRoom);
                    }
                    return SelectScene(baseLeftTopBottomRoom);
                }
                return SelectScene(baseTopBottomRoom);
            }
            if (room.left)
            {
                if (room.right)
                {
                    return SelectScene(baseLeftRightTopRoom);
                }
                return SelectScene(baseLeftTopRoom);
            }
            if (room.right)
            {
                return SelectScene(baseRightTopRoom);
            }
            return SelectScene(baseTopRoom);
        }

        // Bottoms
        if (room.bottom)
        {
            if (room.left)
            {
                if (room.right)
                {
                    return SelectScene(baseLeftRightBottomRoom);
                }
                return SelectScene(baseLeftBottomRoom);
            }
            if (room.right)
            {
                return SelectScene(baseRightBottomRoom);
            }
            return SelectScene(baseBottomRoom);
        }

        // Lefts
        if (room.left)
        {
            if (room.right)
            {
                return SelectScene(baseLeftRightRoom);
            }
            return SelectScene(baseLeftRoom);
        }

        //Rights
        if (room.right)
        {
            return SelectScene(baseRightRoom);
        }

        // Else
        return SelectScene(fClosedRoom);
    }

    private string SelectScene(List<string> scenes){
        var random = new System.Random();
        int index = random.Next(scenes.Count);
        return scenes[index];
    }

}

