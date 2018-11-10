using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int coin;

    public bool isPlaying;

    public List<Item> itemList;

    public Item HoldItem;


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


}





public class Item
{
    public int staticCost;
    public int DynamicCost;
}