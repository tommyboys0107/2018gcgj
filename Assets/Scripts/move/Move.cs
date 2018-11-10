using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour 
{
   
    

    List<Vector2Int> CanPassList = new List<Vector2Int>();
    Vector2Int lastPos;




    void Start()
    {
        InvokeRepeating("Check", 0.5F, 0.5F);

    }



     public void Check () {

        Vector2Int V2 = GameManager.instance.charManager.pos;

        Vector2Int[] V2_ARROW = new Vector2Int[]{
            V2 + Vector2Int.up,
            V2 + Vector2Int.down,
            V2 + Vector2Int.left,
            V2 + Vector2Int.right
        };

        Vector3Int V0 = new Vector3Int(lastPos.x, lastPos.y, 0);

        CanPassList = new List<Vector2Int>();

        for (int i = 0; i < V2_ARROW.Length; i++)
        {
            Vector3Int V3 = new Vector3Int(V2_ARROW[i].x, V2_ARROW[i].y, 0);
            Cell C = GameManager.instance.mapManager.getCell(V3);

            if (C == null) continue;

            if(C.isPassable == true && V3 != V0 )
            {
                CanPassList.Add(V2_ARROW[i]);
            }
        }

        if(CanPassList.Count == 0)  //若遇到死路（無路可走），就加入原本走的路，使其回頭
        {
            CanPassList.Add(lastPos);
        }


        Vector2Int targetPos = CanPassList[Random.Range(0, CanPassList.Count)];

        lastPos = V2;


        GameManager.instance.charManager.charMoveTo(targetPos.x, targetPos.y);  //


    }

}
