using System.Collections.Generic;
using UnityEngine;

public class Mapper : MonoBehaviour
{
    public static GeneratePath bottomLeftPath = new BottomLeftPath();
    public static GeneratePath bottomLeftRightPath = new BottomLeftRightPath();
    public static GeneratePath bottomPath = new BottomPath();
    public static GeneratePath bottomRightPath = new BottomRightPath();
    public static GeneratePath leftPath = new LeftPath();
    public static GeneratePath leftRightPath = new LeftRightPath();
    public static GeneratePath rightPath = new RightPath();
    public static GeneratePath topBottomLeftPath = new TopBottomLeftPath();
    public static GeneratePath topBottomLeftRightPath = new TopBottomLeftRightPath();
    public static GeneratePath topBottomPath = new TopBottomPath();
    public static GeneratePath topBottomRightPath = new TopBottomRightPath();
    public static GeneratePath topLeftPath = new TopLeftPath();
    public static GeneratePath topLeftRightPath = new TopLeftRightPath();
    public static GeneratePath topPath = new TopPath();
    public static GeneratePath topRightPath = new TopRightPath();
    public Room currentRoom;
    public string SelectRoom(Room room)
    {
        currentRoom = room;

        if (room.top)
        {
            if (room.bottom)
            {
                if (room.left)
                {
                    if (room.right)
                    {
                        return SelectScene(topBottomLeftRightPath);
                    }
                    return SelectScene(topBottomLeftPath);
                }
                return SelectScene(topBottomPath);
            }
            if (room.left)
            {
                if (room.right)
                {
                    return SelectScene(topLeftRightPath);
                }
                return SelectScene(topLeftPath);
            }
            if (room.right)
            {
                return SelectScene(topRightPath);
            }
            return SelectScene(topPath);
        }

        // Bottoms
        if (room.bottom)
        {
            if (room.left)
            {
                if (room.right)
                {
                    return SelectScene(bottomLeftRightPath);
                }
                return SelectScene(bottomLeftPath);
            }
            if (room.right)
            {
                return SelectScene(bottomRightPath);
            }
            return SelectScene(bottomPath);
        }

        // Lefts
        if (room.left)
        {
            if (room.right)
            {
                return SelectScene(leftRightPath);
            }
            return SelectScene(leftPath);
        }

        //Rights
        if (room.right)
        {
            return SelectScene(rightPath);
        }
        return null;
    }

    private string SelectScene(GeneratePath generatePath){
        if(this.currentRoom.isBossRoom){
            return generatePath.GenerateBossRoomPath();
        }
        return generatePath.GenerateRandomRoomPath();
    }

}

