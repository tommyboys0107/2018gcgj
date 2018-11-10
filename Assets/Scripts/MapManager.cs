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

    //用格子系座標設定指定格子
    public void setCell(Vector3Int _cellPos, Cell _cell)
    {
        mainTilemap.SetTile(_cellPos, _cell);
    }


    //


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

    //

    //
    public Cell setCellSprite(Vector3Int _pos, Sprite _sp)
    {
        return setCellSprite(getCell(_pos), _sp);
    }

    public Cell setCellSprite(Cell _cell, Sprite _sp)
    {
        _cell.sprite = _sp;
        return _cell;
    }


}
