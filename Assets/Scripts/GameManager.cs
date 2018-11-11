using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

    public UIDelegate uIDelegate;
    public ShopManager shopManager;
    public MapManager mapManager;
    public CharManager charManager;

    public UIMainCon uIMainCon;
    [SerializeField]
    GameObject UIPrefab;

    public Camera mainCamera;


    public Sprite sp;


	void Awake ()
    {
        instance = this;

        GameObject G = Instantiate(UIPrefab);

        uIMainCon = FindObjectOfType(typeof(UIMainCon)) as UIMainCon;

        mapManager.Init();
        uIMainCon.Init();
        uIDelegate.Init();
        shopManager.Init();

        shopManager.coin = 100;

        Enter();


    }

    void Enter()
    {

        //設定起始點
        mapManager.setCell(new Vector3Int(3, 0, 1), mapManager.setCellSprite(Cell.GetDefault(new Vector2Int(3, 0)), sp));



    }




    public void timeUp()
    {
        Debug.Log("Time Up");
    }

}
