using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

    public UIDelegate uIDelegate;
    public ItemManager itemManager;
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

        uIMainCon.Init();
        uIDelegate.Init();
        itemManager.Init();
        mapManager.Init();
        
        charManager.pos = mapManager.StartPoint;

        charManager.mainChar.transform.position = mapManager.cellToWorld(new Vector3Int(charManager.pos.x, charManager.pos.y, 0)) + new Vector3(0, 0, -1);
        mainCamera.transform.position = mapManager.cellToWorld(new Vector3Int(charManager.pos.x, charManager.pos.y, 0)) + new Vector3(0, 0, -100);

        itemManager.isPlaying = false;






    }

    void Enter()
    {

    }



}
