using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mapper : MonoBehaviour
{
    public static List<string> baseRightRoom = new List<string>{"R"};
    public static List<string> baseLeftRoom = new List<string>{"L"};
    public static List<string> baseTopRoom = new List<string>{"T"};
    public static List<string> baseBottomRoom = new List<string>{"B"};
    public static List<string> baseRightTopRoom = new List<string>{"TR"};
    public static List<string> baseRightBottomRoom = new List<string>{"BR"};
    public static List<string> baseLeftTopRoom = new List<string>{"TL"};
    public static List<string> baseLeftBottomRoom = new List<string>{"BL"};
    public static List<string> baseLeftRightBottomRoom = new List<string>{"BLR"};
    public static List<string> baseLeftRightTopRoom = new List<string>{"TLR"};
    public static List<string> baseLeftRightTopBottomRoom = new List<string>{"TBLR", "TBLR +1"};
    public static List<string> baseLeftTopBottomRoom = new List<string>{"TBL"};
    public static List<string> baseTopBottomRoom = new List<string>{"TB"};
    public static List<string> baseLeftRightRoom = new List<string>{"LR"};
    public static List<string> fClosedRoom;

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

