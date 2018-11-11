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


        int spendCoin = isPlaying ? itemList[_itemIndex].staticCost : itemList[_itemIndex].DynamicCost;
        if (coin > spendCoin)    //判斷金幣是否足夠
        {
            coin -= spendCoin;
            HoldItem = itemList[_itemIndex];

            return true;
        }
        else
        {
            return false;
        }
    }

    public void setItemInCell(Vector2Int _cellPos)
    {
        GameManager.instance.mapManager.getCell(_cellPos).itemState = HoldItem;
        Debug.LogFormat("set Item in Cell({0},{1})", _cellPos.x, _cellPos.y);
    }
    public void setItemInCell(Vector3Int _cellPos)
    {
        setItemInCell(new Vector2Int(_cellPos.x, _cellPos.y));
    }
    public void setItemInCell(Vector3 _pos)
    {
        setItemInCell(GameManager.instance.mapManager.worldToCell(_pos));
    }

}





public class Item
{
    public int staticCost;
    public int DynamicCost;
}