using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public int gridSizeX = 10; // number of squares in the positive and negative x direction
    public int gridSizeY = 10; // number of squares in the postive and negative y direction
    public int numberOfRooms = 20; // number of rooms to generate
    public Room[,] rooms; // location of Room in [0, gridSize * 2]
    public List<Vector2> takenPositions = new List<Vector2>(); // populated locations
    public List<Vector2> toBeGeneratedPositions = new List<Vector2>(); // locations that have yet to be placed
    private Mapper map; // helper function for figuring out what tile to place

    void Awake()
    {
        map = GameObject.FindGameObjectWithTag("RoomMapper").GetComponent<Mapper>();
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        Room room = new Room(Vector2.zero, true, true, true, true);
        rooms[gridSizeX, gridSizeY] = room;
        takenPositions.Insert(0, Vector2.zero);
        AddToBeGeneratedPositions(room);
        
        for (int i = 0; i <= numberOfRooms; i++)
        {
            if (toBeGeneratedPositions.Count == 0)
            {
                break;
            }
            int vecIdx = Random.Range(0, toBeGeneratedPositions.Count - 1);
            Vector2 vec = toBeGeneratedPositions[vecIdx];
            toBeGeneratedPositions.RemoveAt(vecIdx);
            Room nr = PlaceTile(vec);
            rooms[(int)vec.x + gridSizeX, (int)vec.y + gridSizeY] = nr;
            AddToBeGeneratedPositions(nr);
            takenPositions.Insert(0, vec);
        }
        foreach(Vector2 vec in toBeGeneratedPositions)
        {
            Room nr = PlaceClosedTile(vec);
            rooms[(int)vec.x + gridSizeX, (int)vec.y + gridSizeY] = nr;
            takenPositions.Insert(0, vec);
        }
        DrawMap();
    }

    Room PlaceTile(Vector2 vec)
    {
        bool doorTop = false;
        bool wallTop = false;
        bool doorBot = false;
        bool wallBot = false;
        bool doorLeft = false;
        bool wallLeft = false;
        bool doorRight = false;
        bool wallRight = false;

        // Check fits top
        Vector2 above = vec + new Vector2(0, 1);
        Room roomAbove = rooms[(int)above.x + gridSizeX, (int)above.y + gridSizeY];
        if (roomAbove != null)
        {
            if (roomAbove.bottom)
                doorTop = true;
            else
                wallTop = true;
        }
        // Check fits bottom
        Vector2 below = vec + new Vector2(0, -1);
        Room roomBelow = rooms[(int)below.x + gridSizeX, (int)below.y + gridSizeY];
        if (roomBelow != null)
        {
            if (roomBelow.top)
                doorBot = true;
            else
                wallBot = true;
        }
        // Check fits left
        Vector2 toTheLeft = vec + new Vector2(-1, 0);
        Room roomToTheLeft = rooms[(int)toTheLeft.x + gridSizeX, (int)toTheLeft.y + gridSizeY];
        if (roomToTheLeft != null)
        {
            if (roomToTheLeft.right)
                doorLeft = true;
            else
                wallLeft = true;
        }
        // Check fits right
        Vector2 toTheRight = vec + new Vector2(1, 0);
        Room roomToTheRight = rooms[(int)toTheRight.x + gridSizeX, (int)toTheRight.y + gridSizeY];
        if (roomToTheRight != null)
        {
            if (roomToTheRight.left)
                doorRight = true;
            else
                wallRight = true;
        }

        // if it doesn't fit, figure out what closes it
        Room nr = SelectRoomTile(vec, doorTop, wallTop, doorBot, wallBot, doorLeft, wallLeft, doorRight, wallRight);

        return nr;
    }

    Room PlaceClosedTile(Vector2 vec)
    {
        bool doorTop = false;
        bool wallTop = false;
        bool doorBot = false;
        bool wallBot = false;
        bool doorLeft = false;
        bool wallLeft = false;
        bool doorRight = false;
        bool wallRight = false;

        // Check fits top
        Vector2 above = vec + new Vector2(0, 1);
        Room roomAbove = rooms[(int)above.x + gridSizeX, (int)above.y + gridSizeY];
        if (roomAbove != null && roomAbove.bottom)
            doorTop = true;
        else
            wallTop = true;

        // Check fits bottom
        Vector2 below = vec + new Vector2(0, -1);
        Room roomBelow = rooms[(int)below.x + gridSizeX, (int)below.y + gridSizeY];
        if (roomBelow != null && roomBelow.top)
            doorBot = true;
        else
            wallBot = true;

        // Check fits left
        Vector2 toTheLeft = vec + new Vector2(-1, 0);
        Room roomToTheLeft = rooms[(int)toTheLeft.x + gridSizeX, (int)toTheLeft.y + gridSizeY];
        if (roomToTheLeft != null && roomToTheLeft.right)
            doorLeft = true;
        else
            wallLeft = true;

        // Check fits right
        Vector2 toTheRight = vec + new Vector2(1, 0);
        Room roomToTheRight = rooms[(int)toTheRight.x + gridSizeX, (int)toTheRight.y + gridSizeY];
        if (roomToTheRight != null && roomToTheRight.left)
            doorRight = true;
        else
            wallRight = true;

        // if it doesn't fit, figure out what closes it
        Room nr = SelectRoomTile(vec, doorTop, wallTop, doorBot, wallBot, doorLeft, wallLeft, doorRight, wallRight);

        return nr;
    }

    Room SelectRoomTile(Vector2 vec, bool doorTop, bool wallTop, bool doorBot, bool wallBot, 
        bool doorLeft, bool wallLeft, bool doorRight, bool wallRight)
    {
        bool top, bottom, left, right;
        // Top
        if (doorTop)
        {
            top = true;
        } else if (wallTop)
        {
            top = false;
        } else
        {
            top = Random.value <= 0.5f;
        }

        // Bottom
        if (doorBot)
        {
            bottom = true;
        }
        else if (wallBot)
        {
            bottom = false;
        }
        else
        {
            bottom = Random.value <= 0.5f;
        }

        // Left
        if (doorLeft)
        {
            left = true;
        }
        else if (wallLeft)
        {
            left = false;
        }
        else
        {
            left = Random.value <= 0.5f;
        }

        // Right
        if (doorRight)
        {
            right = true;
        }
        else if (wallRight)
        {
            right = false;
        }
        else
        {
            right = Random.value <= 0.5f;
        }
        return new Room(vec, top, bottom, left, right);
    }

    void AddToBeGeneratedPositions(Room newRoom)
    {
        if (newRoom.top)
        {
            Vector2 pos = newRoom.gridPos + new Vector2(0, 1);
            if (!takenPositions.Contains(pos) && !toBeGeneratedPositions.Contains(pos) && pos.y + 1 < gridSizeY)
            {
                toBeGeneratedPositions.Insert(0, pos);
            }
        }
        if (newRoom.bottom)
        {
            Vector2 pos = newRoom.gridPos;
            pos.y -= 1;
            if (!takenPositions.Contains(pos) && !toBeGeneratedPositions.Contains(pos) && pos.y - 1 > -gridSizeY) 
            {
                toBeGeneratedPositions.Insert(0, pos);
            }
        }
        if (newRoom.left)
        {
            Vector2 pos = newRoom.gridPos;
            pos.x -= 1;
            if (!takenPositions.Contains(pos) && !toBeGeneratedPositions.Contains(pos) && pos.x - 1 > -gridSizeX) 
            {
                toBeGeneratedPositions.Insert(0, pos);
            }
        }
        if (newRoom.right)
        {
            Vector2 pos = newRoom.gridPos;
            pos.x += 1;
            if (!takenPositions.Contains(pos) && !toBeGeneratedPositions.Contains(pos) && pos.x + 1 < gridSizeX) 
            {
                toBeGeneratedPositions.Insert(0, pos);
            }
        }
    }

    void DrawMap()
    {
        foreach(Room room in rooms)
        {
            if(room == null)
            {
                continue;
            }
            Vector2 drawPos = room.gridPos;
            drawPos.x *= 14;
            drawPos.y *= 14;
            GameObject selectedRoom = map.SelectRoom(room);

            Instantiate(selectedRoom, drawPos, Quaternion.identity);
        }
    }

    
    void DrawMapString()
    {
        for (int y = 0; y < rooms.GetLength(0); y++)
        {
            string line = "";
            for (int x = 0; x < rooms.GetLength(1); x++)
            {
                if (rooms[x, y] == null)
                {
                    line += "O";
                } else
                {
                    line += "X";
                }
            }
            Debug.Log(line+"\n");
        }
    }
}
