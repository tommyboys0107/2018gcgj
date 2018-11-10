using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;

    public ShopManager shopManager;
    public MapManager mapManager;
    public CharManager charManager;


	void Awake ()
    {
        instance = this;

        Enter();


    }

    void Enter()
    {

    }

}
