using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Cell : Tile
{
    public Vector2Int pos;
    public bool isPassable;
    public Item itemState;



    static public Cell GetDefault(Vector2Int _pos)
    {
        Cell returnCell = new Cell();

        returnCell.pos = _pos;
        returnCell.isPassable = false;
        returnCell.itemState = null;

        return returnCell;
    }
}
