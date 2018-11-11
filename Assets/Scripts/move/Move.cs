using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{
   
    

    List<Vector2Int> CanPassList = new List<Vector2Int>();
    List<Vector2Int> FirstList = new List<Vector2Int>();
    Vector2Int lastPos;
    Vector2Int targetPos;
    Vector2Int beforePos;

        

    public void Check () {

        if (GameManager.instance.charManager.pos == GameManager.instance.mapManager.EndPoint)
        {
            GameManager.instance.uIDelegate.win();
            return;
        }

        if( GameManager.instance.charManager.HP > 0)
        {
            GameManager.instance.charManager.HP--;
        }
        else
        {
            GameManager.instance.uIDelegate.lose();
            return;
        }


        Vector2Int V2 = GameManager.instance.charManager.pos;
        int k = 1;
        Vector2Int[] V2_ARROW = new Vector2Int[]{
            V2 + new Vector2Int(0,k),
            V2 + new Vector2Int(0,-k),
            V2 + new Vector2Int(-k,0),
            V2 + new Vector2Int(k,0)
        };

        Vector3Int V0 = new Vector3Int(lastPos.x, lastPos.y, 0);
        Vector3Int VBefore = new Vector3Int(beforePos.x, beforePos.y, 0);

        CanPassList.Clear();

        for (int i = 0; i < V2_ARROW.Length; i++) ///判斷方向是否可前進，，計入list
        {
            Vector3Int V3 = new Vector3Int(V2_ARROW[i].x, V2_ARROW[i].y, 0);
            Cell C = GameManager.instance.mapManager.getCell_3(V3);

            if (C == null) continue;

            if(C.isPassable == true && V3 != V0 )
            {
                CanPassList.Add(V2_ARROW[i]);
            }
        }

        FirstList = new List<Vector2Int>();
        for (; k < 11;k++)
        {
            for (int j = 0; j < CanPassList.Count;j++)
            {
                Vector3Int V4 = new Vector3Int(CanPassList[j].x, CanPassList[j].y, 0);
                Cell D = GameManager.instance.mapManager.getCell_3(V4);
                if (D.itemState != null)
                {
                    if (D.itemState.type == 0) ///碰到道具
                    {
                        FirstList.Add(CanPassList[j]);
                    }
                    else if(D.itemState.type == 1)
                    {
                        FirstList.Remove(CanPassList[j]);
                        CanPassList.Remove(CanPassList[j]);
                    }

                }
            }
            if (FirstList.Count != 0) break;
        }

        Vector2Int Before = targetPos;

        if (CanPassList.Count == 0)  //若遇到死路（無路可走），就加入原本走的路，使其回頭
        {
            CanPassList.Add(lastPos);
        }


        if (FirstList.Count != 0)
        {
            k = 1;
            targetPos = FirstList[Random.Range(0, FirstList.Count)];
            FirstList.Clear();
        }
        else if (FirstList.Count == 0)
        {
            k = 1;
            targetPos = CanPassList[Random.Range(0, CanPassList.Count)];
        }

        Vector2Int After = targetPos;

        lastPos = V2;

        GameManager.instance.charManager.ChangeCharFace(GetFace(Before, After));
        GameManager.instance.charManager.charMoveTo(targetPos.x, targetPos.y);  //
        GameManager.instance.mapManager.freshCellItem(Before, null);

    }


    public int GetFace(Vector2Int Before,Vector2Int After)
    {
        int finResult;
        int xResult= 0;
        int yResult = 0;
        xResult = After.x - Before.x;
        yResult = After.y - Before.y;
        if(xResult==1 && yResult ==0)
        {
            ///結果為右
            finResult = 1;
        }
        else if (xResult==-1 && yResult ==0)
        {
            ///結果為左
            finResult = 3;
        }
        else if (yResult==1 && xResult ==0)
        {
            ///結果為上
            finResult = 0;
        }
        else if (yResult==-1 && xResult ==0)
        {
            ///結果為下
            finResult = 2;
        }
        else
        {
            finResult = -1;
        }


        return finResult;


    }

}
