using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDelegate : MonoBehaviour
{
    static public UIDelegate instance;

    public delegate void EnterGame();                                           //按下登入頁面的開始鈕
    public delegate void GoPlay();                                              //按下開始行進
    public delegate void Restart();                                             //按下重來按鈕
    public delegate void MoveView(Vector2 _delta);                              //移動視野
    public delegate void BuyItem(int _itemIndex);                               //買道具
    public delegate void SetItemInCell(Vector3 _worldPosition);                 //放置道具



    void Awake()
    {
        instance = this;
    }



}
