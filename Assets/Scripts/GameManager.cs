using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

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



    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    void Awake ()
    {
        instance = this;

        GameObject G = Instantiate(UIPrefab);

        uIMainCon = FindObjectOfType(typeof(UIMainCon)) as UIMainCon;

        mapManager.Init();
        uIMainCon.Init();
        uIDelegate.Init();
        shopManager.Init();

        shopManager.coin = 60;
        charManager.HP = 120;
        charManager.pos = mapManager.StartPoint;

        charManager.mainChar.transform.position = mapManager.cellToWorld(new Vector3Int(charManager.pos.x, charManager.pos.y, 0)) + new Vector3(0, 0, -1);
        mainCamera.transform.position = mapManager.cellToWorld(new Vector3Int(charManager.pos.x, charManager.pos.y, 0)) + new Vector3(0, 0, -100);

        shopManager.isPlaying = false;






    }

    void Enter()
    {

    }



}
