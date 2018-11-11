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
    public delegate bool BuyItem(int _itemIndex);                               //買道具
    public delegate void SetItemInCell(Vector3 _worldPosition);                 //放置道具
    public delegate void Win();
    public delegate void Lose();


    public EnterGame enterGame;
    public GoPlay goPlay;
    public Restart restart;
    public MoveView moveView;
    public BuyItem buyItem;
    public SetItemInCell setItemInCell;
    public Win win;
    public Lose lose;


    public void Init()
    {
        instance = this;

        //

        enterGame = Log;

        goPlay = Log;

        restart = Log;

        moveView = Log;

        buyItem = Log_b;
        buyItem += GameManager.instance.shopManager.buyItem;

        setItemInCell = Log;
        setItemInCell += GameManager.instance.shopManager.setItemInCell_World;

        lose += delegate { Debug.Log("LOSE"); };

        win += delegate { Debug.Log("WIN"); };
    }

void HandleSetItemInCell(Vector3 _worldPosition)
    {
    }


    void Log()
    {
        Debug.Log("Delegate Invoke!");
    }
    void Log(Vector2 _)
    {
        Debug.Log("Delegate Invoke! Param: " + _.ToString());
    }
    void Log(Vector3 _)
    {
        Debug.Log("Delegate Invoke! Param: " + _.ToString());
    }
    void Log(int _)
    {
        Debug.Log("Delegate Invoke! Param: " + _.ToString());
    }
    bool Log_b(int _)
    {
        Debug.Log("Delegate Invoke! Param: " + _.ToString());
        return false;
    }




}
