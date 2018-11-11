﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour 
{
    [SerializeField]
    GameObject mainChar;


    int _leaveTime = 0;
    public int leaveTime
    {
        get { return _leaveTime; }
        set 
        {
            if (value == 0) GameManager.instance.timeUp();
            _leaveTime = value;
        }

    }

    public Vector2Int pos;



    public bool charMoveTo(int _x,int _y)
    {
        mainChar.transform.position = GameManager.instance.mapManager.cellToWorld(new Vector3Int(_x, _y, 0)) + new Vector3(0,0,-1);

        pos = new Vector2Int(_x, _y);

        Debug.Log("MoveTo : " + pos.x + " , " + pos.y);

        return true;


    }


}
