using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour 
{
    [SerializeField]
    public Tilemap mainTilemap;


    public Sprite[] tileSprite;

    public Sprite[] itemSprite;

    public TextAsset Data;



    public Vector2Int StartPoint = new Vector2Int(3, 0);
    public Vector2Int EndPoint = new Vector2Int(3, 19);


    public void Init ()
    {
        readData();
    }




    public void readData()
    {
        string[] lines = Data.text.Split('\n');

        for (int i = 0; i < lines.Length;i++)
        {

            string[] d = lines[lines.Length-i-1].Split(',');
            for (int j = 0; j < d.Length;j++)
            {
                Vector3Int _pos = new Vector3Int(j, i, 0);
                string d_v = d[j];

                Cell C = Cell.GetDefault(new Vector2Int(_pos.x, _pos.y));
                C.sprite = tileSprite[int.Parse(d_v)];
                setCell(V2_V3(C.pos), C);

                getCell_3(_pos).isPassable = (d_v == "1");
            }
        }


    }

    public bool CheckWin()
    {
        if (GameManager.instance.charManager.pos == EndPoint)
        {
            GameManager.instance.uIDelegate.win();
            return true;
        }
        return false;
    }

    public void freshCellItem(Vector2Int _cellPos, Item _item)
    {
        //刷新道具圖
        Sprite targetSp;

        if (_item == null)
        {
            targetSp = null;
        }
        else
        {
            targetSp = itemSprite[_item.type];
        }

        Cell C = Cell.GetDefault(_cellPos);
        C.sprite = targetSp;

        setCell(new Vector3Int(_cellPos.x, _cellPos.y, 1), C);

    }


    //用格子系座標取得格子
    public Cell getCell_3(Vector3Int _cellPos)
    {
        return mainTilemap.GetTile<Cell>(_cellPos);
    }
    public Cell getCell(Vector2Int _cellPos)
    {
        return getCell_3(new Vector3Int(_cellPos.x, _cellPos.y,0));
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

    public Cell setCellSprite(Vector3Int _pos, Sprite _sp)
    {
        return setCellSprite(getCell_3(_pos), _sp);
    }

    public Cell setCellSprite(Cell _cell, Sprite _sp)
    {
        _cell.sprite = _sp;
        return _cell;
    }


    static Vector3Int V2_V3(Vector2Int V2)
    {
        return new Vector3Int(V2.x, V2.y, 0);
    }

    static Vector2Int V3_V2(Vector3Int V3)
    {
        return new Vector2Int(V3.x, V3.y);
    }

}
