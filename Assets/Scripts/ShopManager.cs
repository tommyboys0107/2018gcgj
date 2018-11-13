using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    int _coin = 0;
    public int coin
    {
        get { return _coin; }
        set 
        { 
            UIMainCon.SetGP(value); 
            _coin = value; 
        }
    }


    bool _isPlaying = false;
    public bool isPlaying
    {
        get { return _isPlaying; }
        set
        {
            setUICost(!value);
            _isPlaying = value;
        }
    }

    public List<Item> itemList;

    public Item HoldItem;


    public void Init()
    {
        /*
        修改體力顯示 UIMainCon.SetHP(int);
        修改金錢顯示 UIMainCon.SetGP(int);
        修改商品價格顯示 UIMainCon.SetPrice(int 編號, int 價格)
        */

        //加入道具資料
        itemList = new List<Item>()
        {

            //誘餌
            new Item()
            {
                type = 0,
                staticCost = 2,
                DynamicCost = 4
            },

            //反誘餌
            new Item()
            {
                type = 1,
                staticCost = 1,
                DynamicCost = 2
            }

        };

}

    //cheat code
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            coin += 10;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            coin -= 10;
        }
    }

    //刷新UI上的道具價格
    void setUICost(bool isStatic)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            UIMainCon.SetPrice(i, isStatic ? itemList[i].staticCost : itemList[i].DynamicCost);
        }
    }
    

    //購買道具
    public bool buyItem(int _itemIndex)
    {
        if (_itemIndex >= itemList.Count)
        {
            return false;   //購買不存在的index
        }

        int spendCoin = isPlaying ? itemList[_itemIndex].DynamicCost : itemList[_itemIndex].staticCost;
        if (coin >= spendCoin)      //判斷金幣是否足夠
        {
            coin -= spendCoin;      //消耗金幣
            HoldItem = itemList[_itemIndex];

            return true;
        }
        else
        {
            return false;
        }
    }

    //放置道具在格子上
    public void setItemInCell(Vector2Int _cellPos)
    {
        Cell targetCell = GameManager.instance.mapManager.getCell(_cellPos);

        if (targetCell != null)
        {
            targetCell.itemState = HoldItem;
            GameManager.instance.mapManager.freshCellItem(_cellPos, HoldItem);  //刷新上方的圖
        }
        else
        {
            takeItemback(HoldItem);
        }
        
        HoldItem = null;
        if (targetCell == null)
        {
            Debug.Log("A");
        }
    }
    public void setItemInCell(Vector3Int _cellPos)
    {
        setItemInCell(new Vector2Int(_cellPos.x, _cellPos.y));
    }
    public void setItemInCell_World(Vector3 _pos)
    {
        setItemInCell(GameManager.instance.mapManager.worldToCell(_pos));
    }

    //僅將道具從格子移除
    public bool removeItemFromCell(Vector2Int _cellPos)
    {
        Cell targetCell = GameManager.instance.mapManager.getCell(_cellPos);

        if (targetCell != null)
        {
            targetCell.itemState = null;
            GameManager.instance.mapManager.freshCellItem(_cellPos, null);  //刷新上方的圖

            return true;
        }
        return false;
    }

    //返還指定道具的代價
    public void takeItemback(Item _item)
    {
        int spendCoin = isPlaying ? _item.DynamicCost : _item.staticCost;
        coin += spendCoin;      //加回金幣
    }

}

public class Item
{
    public int type;
    public int staticCost;
    public int DynamicCost;
}