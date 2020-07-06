using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapper : MonoBehaviour
{
    public GameObject fRightRoom;
    public GameObject fLeftRoom;
    public GameObject fTopRoom;
    public GameObject fBottomRoom;
    public GameObject fRightTopRoom;
    public GameObject fRightBottomRoom;
    public GameObject fLeftTopRoom;
    public GameObject fLeftBottomRoom;
    public GameObject fLeftRightBottomRoom;
    public GameObject fLeftRightTopRoom;
    public GameObject fLeftRightTopBottomRoom;
    public GameObject fLeftTopBottomRoom;
    public GameObject fTopBottomRoom;
    public GameObject fLeftRightRoom;
    public GameObject fClosedRoom;

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
                        return "TBLR";
                    }
                    return fLeftTopBottomRoom.name;
                }
                return fTopBottomRoom.name;
            }
            if (room.left)
            {
                if (room.right)
                {
                    return fLeftRightTopRoom.name;
                }
                return fLeftTopRoom.name;
            }
            if (room.right)
            {
                return fRightTopRoom.name;
            }
            return fTopRoom.name;
        }

        // Bottoms
        if (room.bottom)
        {
            if (room.left)
            {
                if (room.right)
                {
                    return fLeftRightBottomRoom.name;
                }
                return fLeftBottomRoom.name;
            }
            if (room.right)
            {
                return fRightBottomRoom.name;
            }
            return fBottomRoom.name;
        }

        // Lefts
        if (room.left)
        {
            if (room.right)
            {
                return fLeftRightRoom.name;
            }
            return fLeftRoom.name;
        }

        //Rights
        if (room.right)
        {
            return fRightRoom.name;
        }

        // Else
        return fClosedRoom.name;
    }
}
