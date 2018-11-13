using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour 
{
    [SerializeField]
    public Tilemap mainTilemap;

    public const int LAYER_CELL = 0;
    public const int LAYER_ITEM = 1;

    public Sprite wallSprite;
    public Sprite[] roadSprite;

    public Sprite[] itemSprite;

    public TextAsset Data;


    Vector2Int mapSize = Vector2Int.zero;

    public Vector2Int StartPoint = new Vector2Int(3, 0);
    public Vector2Int EndPoint = new Vector2Int(3, 19);

    public enum ArrowFlag
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }

    public void Init ()
    {
        readData();
        renderMap();
    }
    
    public void readData()
    {

        string[] lines = Data.text.Split('\n');

        for (int i = 0; i < lines.Length;i++)
        {

            string[] d = lines[lines.Length-i-1].Split(',');
            for (int j = 0; j < d.Length; j++)
            {
                if (j == 0) mapSize = new Vector2Int(d.Length, lines.Length);


                Vector3Int _pos = new Vector3Int(j, i, LAYER_CELL);
                string d_v = d[j];

                Cell C = Cell.GetDefault(V3_V2(_pos));

                setCell(V2_V3(C.pos), C);

                C.isPassable = (d_v == "1");
            }
        }
        
    }

    void renderMap()
    {

        for (int i = 0; i < mapSize.y; i++)
        {
            for (int j = 0; j < mapSize.x; j++)
            {
                Vector3Int _pos = new Vector3Int(j, i, LAYER_CELL);
                Cell C = getCell(V3_V2(_pos));

                setCell(V2_V3(C.pos), null);

                if (C.isPassable)
                {
                    C.sprite = roadSprite[getRoadSpriteIndex(getCellRoadType(C.pos))];
                }
                else
                {
                    C.sprite = wallSprite;
                }

                setCell(V2_V3(C.pos), C);
            }
        }

    }
    

    public bool checkWin()
    {
        if (GameManager.instance.charManager.pos == EndPoint)
        {
            GameManager.instance.uIDelegate.win();
            return true;
        }
        return false;
    }
    
    //刷新道具圖
    public void freshCellItem(Vector2Int _cellPos, Item _item)
    {
        Sprite targetSp;

        if (_item == null)
        {
            targetSp = null;
        }
        else
        {
            targetSp = itemSprite[_item.type];
        }

        Cell C = getCell(_cellPos);
        if (C == null) C = Cell.GetDefault(_cellPos);

        C.sprite = targetSp;

        setCell(new Vector3Int(_cellPos.x, _cellPos.y, LAYER_ITEM), null);
        setCell(new Vector3Int(_cellPos.x, _cellPos.y, LAYER_ITEM), C);
    }

    //取得指定座標格的方向Flag
    ArrowFlag getCellRoadType(Vector2Int _pos)
    {
        ArrowFlag flag = ArrowFlag.None;

        List<ArrowFlag> flagList = new List<ArrowFlag>() { ArrowFlag.Top, ArrowFlag.Right, ArrowFlag.Bottom, ArrowFlag.Left };
        
        for(int i = 0; i < flagList.Count; i++)
        {
            Cell targetCell = getNeighborCell<Cell>(_pos, flagList[i]);
            if (targetCell != null)
            {
                if (targetCell.isPassable)
                {
                    flag = flag | flagList[i];
                }
            }
        }

        return flag;
    }

    //由方向Flag轉換為對應Int
    int getRoadSpriteIndex(ArrowFlag _flag)
    {

        switch (_flag)
        {
            case ArrowFlag.Top | ArrowFlag.Bottom: return 0;                                             //上下
            case ArrowFlag.Right | ArrowFlag.Left: return 1;                                             //左右

            case ArrowFlag.Top | ArrowFlag.Right: return 2;                                              //上右
            case ArrowFlag.Top | ArrowFlag.Left: return 3;                                               //上左
            case ArrowFlag.Right | ArrowFlag.Bottom: return 4;                                           //右下
            case ArrowFlag.Left | ArrowFlag.Bottom: return 5;                                            //左下

            case ArrowFlag.Top | ArrowFlag.Right | ArrowFlag.Bottom: return 6;                           //上右下
            case ArrowFlag.Top | ArrowFlag.Right | ArrowFlag.Left: return 7;                             //上右左
            case ArrowFlag.Top | ArrowFlag.Bottom | ArrowFlag.Left: return 8;                            //上下左
            case ArrowFlag.Right | ArrowFlag.Bottom | ArrowFlag.Left: return 9;                          //右下左
                
            case ArrowFlag.Top | ArrowFlag.Right | ArrowFlag.Bottom | ArrowFlag.Left: return 10;         //上右下左

            case ArrowFlag.Top: return 11;                                                               //上
            case ArrowFlag.Right: return 12;                                                             //右
            case ArrowFlag.Bottom: return 13;                                                            //下
            case ArrowFlag.Left: return 14;                                                              //左

            default: return 0;
        }
    }

    //取得指定相鄰方向的格子
    public T getNeighborCell<T>(Vector2Int _pos, ArrowFlag _arrow) where T : Tile
    {
        Dictionary<ArrowFlag, Vector2Int> neighborPosList = new Dictionary<ArrowFlag, Vector2Int>();

        neighborPosList.Add(ArrowFlag.Top, new Vector2Int(0, 1));
        neighborPosList.Add(ArrowFlag.Right, new Vector2Int(1, 0));
        neighborPosList.Add(ArrowFlag.Bottom, new Vector2Int(0, -1));
        neighborPosList.Add(ArrowFlag.Left, new Vector2Int(-1, 0));
        
        return getCell<T>(V2_V3(_pos + neighborPosList[_arrow]));
    }

    //

    //用格子系座標取得格子
    public Cell getCell(Vector3Int _cellPos)
    {
        return mainTilemap.GetTile<Cell>(_cellPos);
    }
    public Cell getCell(Vector2Int _cellPos)
    {
        return getCell(new Vector3Int(_cellPos.x, _cellPos.y, LAYER_CELL));
    }
    public T getCell<T>(Vector3Int _cellPos) where T : Tile
    {
        return mainTilemap.GetTile<T>(_cellPos);
    }

    //用格子系座標設定指定格子
    public void setCell(Vector3Int _cellPos, Cell _cell)
    {
        mainTilemap.SetTile(_cellPos, _cell);
    }
    public void setCell(Vector2Int _cellPos, Cell _cell)
    {
        setCell(V2_V3(_cellPos), _cell);
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

    //設定格子的圖片
    public Cell setCellSprite(Vector3Int _pos, Sprite _sp)
    {
        return setCellSprite(getCell(_pos), _sp);
    }
    public Cell setCellSprite(Cell _cell, Sprite _sp)
    {
        _cell.sprite = _sp;
        return _cell;
    }



    static Vector3Int V2_V3(Vector2Int V2)
    {
        return new Vector3Int(V2.x, V2.y, LAYER_CELL);
    }
    static Vector2Int V3_V2(Vector3Int V3)
    {
        return new Vector2Int(V3.x, V3.y);
    }

}
