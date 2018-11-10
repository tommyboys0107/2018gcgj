using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour 
{
    [SerializeField]
    GameObject mainChar;



    public Vector2Int pos;



    bool charMoveTo(int _x,int _y)
    {
        //mainChar.transform.position = GameManager.instance.mapManager.cellToWorld(new Vector3Int(_x, _y, 0));

        pos = new Vector2Int(_x, _y);

        return true;


    }


}
