using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour 
{
    [SerializeField]
    public Tilemap mainTilemap;


    public Dictionary<TileBase,Cell> cellMap;



    public Cell getCell(TileBase _index)
    {
        return cellMap[_index];
    }



    void Start ()
    {

    }



    //用格子系座標取得格子
    public Cell getCell(Vector3Int _cellPos)
    {

        return mainTilemap.GetTile<Cell>(_cellPos);
    }

    //用格子系座標取得世界系座標
    public Vector3 cellToWorld(Vector3Int _cellPos)
    {
        return mainTilemap.GetCellCenterWorld(_cellPos);
    }

    //用世界系座標取得格子系座標
    public Vector3Int worldToCell(Vector3 _worldPosition)
    {
        return mainTilemap.WorldToCell(_worldPosition);
    }





}
