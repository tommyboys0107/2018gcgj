using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Cell : TileBase
{
    public Vector2Int pos;
    public bool isPassable;
    public Item itemState;
}
