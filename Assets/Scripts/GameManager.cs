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







    void Awake ()
    {
        instance = this;

        GameObject G = Instantiate(UIPrefab);

        uIMainCon = FindObjectOfType(typeof(UIMainCon)) as UIMainCon;

        mapManager.Init();
        uIMainCon.Init();
        uIDelegate.Init();
        shopManager.Init();

        shopManager.coin = 1000;
        charManager.HP = 1000;
        charManager.pos = mapManager.StartPoint;

        charManager.mainChar.transform.position = mapManager.cellToWorld(new Vector3Int(charManager.pos.x, charManager.pos.y, 0)) + new Vector3(0, 0, -1);
    

  

        


    }

    void Enter()
    {

    }




    public void timeUp()
    {
        Debug.Log("Time Up");
    }

}
