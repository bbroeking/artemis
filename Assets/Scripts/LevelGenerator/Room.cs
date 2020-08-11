using UnityEngine;
using System;

public class Room
{
    public Vector2 gridPos;
    //public int type;
    public bool top, bottom, left, right;
    public bool isBossRoom;
    public Room(Vector2 _gridPos, bool top, bool bottom, bool left, bool right)
    {
        gridPos = _gridPos;
        this.top = top;
        this.bottom = bottom;
        this.left = left;
        this.right = right;
        this.isBossRoom = false;
    }

    public override string ToString()
    {
        return "gridPos: " + gridPos.ToString() + " T/B/L/R " + System.Convert.ToInt32(top)
                + System.Convert.ToInt32(bottom) + System.Convert.ToInt32(left) + 
                System.Convert.ToInt32(right);
    }

    public void SetBossRoom(){
        this.isBossRoom = true;
    }
}
