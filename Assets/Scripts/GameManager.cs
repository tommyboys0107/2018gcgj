using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

    public ShopManager shopManager;
    public MapManager mapManager;
    public CharManager charManager;


    public Sprite sp;


	void Awake ()
    {
        instance = this;

        Invoke("Enter",3F);


    }

    void Enter()
    {
        mapManager.setCell(new Vector3Int(3, 0, 1), mapManager.setCellSprite(Cell.GetDefault(new Vector2Int(3, 0)), sp));



    }

}
