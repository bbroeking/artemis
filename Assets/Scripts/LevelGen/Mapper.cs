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

    public GameObject SelectRoom(Room room)
    {
        if (room.top)
        {
            if (room.bottom)
            {
                if (room.left)
                {
                    if (room.right)
                    {
                        return fLeftRightTopBottomRoom;
                    }
                    return fLeftTopBottomRoom;
                }
                return fTopBottomRoom;
            }
            if (room.left)
            {
                if (room.right)
                {
                    return fLeftRightTopRoom;
                }
                return fLeftTopRoom;
            }
            if (room.right)
            {
                return fRightTopRoom;
            }
            return fTopRoom;
        }

        // Bottoms
        if (room.bottom)
        {
            if (room.left)
            {
                if (room.right)
                {
                    return fLeftRightBottomRoom;
                }
                return fLeftBottomRoom;
            }
            if (room.right)
            {
                return fRightBottomRoom;
            }
            return fBottomRoom;
        }

        // Lefts
        if (room.left)
        {
            if (room.right)
            {
                return fLeftRightRoom;
            }
            return fLeftRoom;
        }

        //Rights
        if (room.right)
        {
            return fRightRoom;
        }

        // Else
        return fClosedRoom;
    }
}
