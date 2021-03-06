﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CliffLeeCL;

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

        goPlay += GameManager.instance.charManager.move.Check;
        goPlay += delegate { GameManager.instance.itemManager.isPlaying = true; };
        goPlay += delegate { AudioManager.Instance.PlaySound(AudioManager.AudioName.StartGame, 0.9F); };

        restart += GameManager.instance.Reload;

        moveView += GameManager.instance.charManager.View;

        buyItem += GameManager.instance.itemManager.buyItem;

        setItemInCell += GameManager.instance.itemManager.setItemInCell_World;
        setItemInCell += delegate { AudioManager.Instance.PlaySound(AudioManager.AudioName.ItemDrop, 0.8F); };
        //setItemInCell += LogCellPos;

        lose += delegate { AudioManager.Instance.PlaySound(AudioManager.AudioName.GameOver, 0.8F); };

        win += delegate { AudioManager.Instance.PlaySound(AudioManager.AudioName.LevelClear1, 0.8F); };
        win += delegate { AudioManager.Instance.PlaySound(AudioManager.AudioName.LevelClear2, 0.8F); };
    }

    void LogCellPos(Vector3 _Pos)
    {
        Vector2Int V2 = GameManager.instance.mapManager.getCell(GameManager.instance.mapManager.worldToCell(_Pos)).pos;
        Debug.LogFormat("{0} , {1}", V2.x, V2.y);
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
