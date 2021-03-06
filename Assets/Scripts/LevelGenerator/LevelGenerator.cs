﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : GenericSingleton
{
    [Header("Level Attributes")]
    public int gridSizeX = 5; // number of squares in the positive and negative x direction
    public int gridSizeY = 5; // number of squares in the postive and negative y direction
    public int numberOfRooms = 3; // number of rooms to generate
    public int currentLevel = 1;
    public static int currentGridPosX;
    public static int currentGridPosY;
    public static bool levelExists;

    [Header("Level Generations")]
    public static Room[,] rooms; // location of Room in [0, gridSize * 2]
    public static List<Vector2> takenPositions; // populated locations
    public static List<Vector2> toBeGeneratedPositions; // locations that have yet to be placed
    private Room currentRoom;
    public Room CurrentRoom { get { return currentRoom; }}

    [Header("UI Panels")]
    UISingleton uISingleton;
    LevelPanel levelPanel;

    public static LevelGenerator Instance { get; private set; } 
    void Awake(){
        if(Instance == null){
            Instance = this;
            GenerateLevel();
            DontDestroyOnLoad(this.gameObject);
        } 
        else { Destroy(gameObject); }
    }
    void Start(){
        uISingleton = UISingleton.Instance;
        // Find All UI Objects
        levelPanel = uISingleton.GetComponentInChildren<LevelPanel>();
        
        UpdateUI();
    }
    public void UpdateUI(){
        levelPanel.SetTexts(this.currentLevel);
        levelPanel.UpdateTextsValues();
    }
    public void GenerateLevel(){
        takenPositions = new List<Vector2>();
        toBeGeneratedPositions = new List<Vector2>();
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];

        currentGridPosX = gridSizeX;
        currentGridPosY = gridSizeY;

        Room room = new Room(Vector2.zero, true, true, true, true);
        rooms[currentGridPosX, currentGridPosY] = room;

        takenPositions.Insert(0, Vector2.zero);
        AddToBeGeneratedPositions(room);
        
        for (int i = 0; i <= numberOfRooms; i++)
        {
            if (toBeGeneratedPositions.Count == 0) break;
            int vecIdx = Random.Range(0, toBeGeneratedPositions.Count - 1);
            Vector2 vec = toBeGeneratedPositions[vecIdx];
            toBeGeneratedPositions.RemoveAt(vecIdx);
            PlaceTileInPosition(vec);
        }
        for(int j = 0; j < toBeGeneratedPositions.Count - 1; j++){
            PlaceClosedTileInPosition(toBeGeneratedPositions[j], false);
        }
        PlaceClosedTileInPosition(toBeGeneratedPositions[toBeGeneratedPositions.Count - 1], true);
    }
    public void SetLevelSettings(int gridSizeX, int gridSizeY, int numberOfRooms){
        this.gridSizeX = gridSizeX;
        this.gridSizeY = gridSizeY;
        this.numberOfRooms = numberOfRooms;
    }
    public void PlaceTileInPosition(Vector2 vec){
        Room nr = PlaceTile(vec);
        Vector2 vecOffset = new Vector2((int)vec.x + gridSizeX, (int)vec.y + gridSizeY);
        rooms[(int) vecOffset.x, (int) vecOffset.y] = nr;
        AddToBeGeneratedPositions(nr);
        takenPositions.Insert(0, vec);
    }
    public void PlaceClosedTileInPosition(Vector2 vec, bool isBossRoom){
        Room nr = PlaceClosedTile(vec);
        if(isBossRoom) nr.SetBossRoom();
        rooms[(int)vec.x + gridSizeX, (int)vec.y + gridSizeY] = nr;
        takenPositions.Insert(0, vec);
    }
    public Room GetFirstRoom(){
        return rooms[currentGridPosX, currentGridPosY];
    }
    public Room GetNextRoom(int xoff, int yoff){
        currentGridPosX = currentGridPosX + xoff;
        currentGridPosY  = currentGridPosY + yoff;
        SetCurrentRoom();
        return rooms[currentGridPosX, currentGridPosY];
    }

    public void SetCurrentRoom(){
        currentRoom = rooms[currentGridPosX, currentGridPosY];
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
        if (doorTop) top = true;
        else if (wallTop) top = false;
        else top = Random.value <= 0.5f;

        // Bottom
        if (doorBot) bottom = true;
        else if (wallBot) bottom = false;
        else bottom = Random.value <= 0.5f;

        // Left
        if (doorLeft) left = true;
        else if (wallLeft) left = false;
        else left = Random.value <= 0.5f;

        // Right
        if (doorRight) right = true;
        else if (wallRight) right = false;
        else right = Random.value <= 0.5f;

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

    public void DrawMapString()
    {
        for (int y = rooms.GetLength(0)-1; y >= 0; y--)
        {
            string line = "";
            line += y.ToString();
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

    public DoorType GetDoorType(int xoff, int yoff){
        int doorLeadToX = currentGridPosX + xoff;
        int doorLoadToY  = currentGridPosY + yoff;
        Room room = rooms[doorLeadToX, doorLoadToY];
        if (room.isBossRoom) return DoorType.Boss;
        return DoorType.Basic;
    }
}
