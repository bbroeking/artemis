using UnityEngine;
using System;

public class Room
{
    public static GeneratePath generalFloors = new GeneralFloors();
    public Vector2 gridPos;
    public bool top, bottom, left, right;
    public bool isBossRoom;
    public bool isCleared;
    public string floorPath;
    public Room(Vector2 _gridPos, bool top, bool bottom, bool left, bool right)
    {
        gridPos = _gridPos;
        this.top = top;
        this.bottom = bottom;
        this.left = left;
        this.right = right;
        this.isBossRoom = false;
        this.isCleared = false;
        this.floorPath = generalFloors.GenerateRandomFloorPath();
    }

    public override string ToString()
    {
        return "gridPos: " + gridPos.ToString() + " T/B/L/R " + System.Convert.ToInt32(top)
                + System.Convert.ToInt32(bottom) + System.Convert.ToInt32(left) + 
                System.Convert.ToInt32(right);
    }

    public string GetWallPath(){
        string wallPath = "";
        if (top) wallPath = wallPath + "T";
        if (bottom) wallPath = wallPath + "B";
        if (left) wallPath = wallPath + "L";
        if (right) wallPath = wallPath + "R";
        return "Rooms/Maps/Walls/" + wallPath;
    }

    public string GetFloorPath(){
        return this.floorPath;
    }

    public void SetBossRoom(){
        this.isBossRoom = true;
    }

    public void SetCleared(){
        this.isCleared = true;
    }
}
