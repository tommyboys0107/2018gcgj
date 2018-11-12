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
        Item Item01 = new Item();
        Item01.type = 0;
        Item01.staticCost = 2;
        Item01.DynamicCost = 4;

        Item Item02 = new Item();
        Item02.type = 1;
        Item02.staticCost = 1;
        Item02.DynamicCost = 2;

        itemList = new List<Item>() { Item01, Item02 };

    }

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


    void setUICost(bool isStatic)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            UIMainCon.SetPrice(i, isStatic ? itemList[i].staticCost : itemList[i].DynamicCost);
        }
    }




    public bool buyItem(int _itemIndex)
    {
        if (_itemIndex >= itemList.Count)
        {
            return false;   //購買不存在的index
        }

        int spendCoin = isPlaying ? itemList[_itemIndex].DynamicCost : itemList[_itemIndex].staticCost;
        if (coin >= spendCoin)    //判斷金幣是否足夠
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

    public void setItemInCell_2(Vector2Int _cellPos)
    {
        Cell targetCell = GameManager.instance.mapManager.getCell(_cellPos);

        if (targetCell != null)
        {
            targetCell.itemState = HoldItem;
            GameManager.instance.mapManager.freshCellItem(_cellPos, HoldItem);  //刷新上方的圖
        }
        else
        {
            int spendCoin = isPlaying ? HoldItem.DynamicCost : HoldItem.staticCost;
            coin += spendCoin;      //因為放置失敗所以加回金幣
        }
        
        HoldItem = null;
    }
    public void setItemInCell(Vector3Int _cellPos)
    {
        setItemInCell_2(new Vector2Int(_cellPos.x, _cellPos.y));
    }
    public void setItemInCell_World(Vector3 _pos)
    {
        setItemInCell(GameManager.instance.mapManager.worldToCell(_pos));
    }

}

public class Item
{
    public int type;
    public int staticCost;
    public int DynamicCost;
}