using UnityEngine;

public enum RoomType {
    Standard,
    LargeStandard
}
public class Room
{
    public static GeneratePath generalFloors = new GeneralFloors();
    public static GeneratePath bossFloors = new BossFloors();
    public Vector2 gridPos;
    public bool top, bottom, left, right;
    public bool isBossRoom;
    public bool isCleared;
    public string floorPath;
    public RoomType roomType;
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
        if (Random.value <= 0.75f) roomType = RoomType.LargeStandard;
        else roomType = RoomType.Standard;
    }

    public override string ToString()
    {
        return "gridPos: " + gridPos.ToString() + " T/B/L/R " + System.Convert.ToInt32(top)
                + System.Convert.ToInt32(bottom) + System.Convert.ToInt32(left) + 
                System.Convert.ToInt32(right);
    }

    public string GetWallPath(){
        if (isBossRoom) return "Rooms/Maps/Walls/Boss";
        string wallPath = "";
        if (top) wallPath = wallPath + "T";
        if (bottom) wallPath = wallPath + "B";
        if (left) wallPath = wallPath + "L";
        if (right) wallPath = wallPath + "R";
        // Return Path
        if (roomType == RoomType.Standard) return "Rooms/Maps/Walls/Standard/" + wallPath;
        else if (roomType == RoomType.LargeStandard) return "Rooms/Maps/Walls/LargeStandard/" + wallPath;
        else return null;
    }

    public string GetFloorPath(){
        return this.floorPath;
    }

    public void SetBossRoom(){
        this.floorPath = bossFloors.GenerateRandomFloorPath();
        this.isBossRoom = true;
    }

    public void SetCleared(){
        this.isCleared = true;
    }
}
