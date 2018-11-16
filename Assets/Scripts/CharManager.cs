using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharManager : MonoBehaviour 
{
    public GameObject mainChar;
    [SerializeField]
    SpriteRenderer charSpRender;
    public Move move;


    int _HP;
    public int HP
    {
        get { return _HP; }
        set
        {
            int val = Mathf.Clamp(value, 0, 9999);
            UIMainCon.SetHP(val);
            _HP = val;
        }
    }


    public Sprite[] charFaceSp;

    [Header("攝影機跟隨的速度")]
    public float cameraFollow = 0.5F;


    public Vector2Int pos;



    public bool charMoveTo(int _x,int _y)
    {
        float MoveTime = 0.5F;
        mainChar.transform.DOMove(GameManager.instance.mapManager.cellToWorld(new Vector3Int(_x, _y, MapManager.LAYER_CELL)) + new Vector3(0, 0, -1), MoveTime)
                .SetEase(Ease.Linear)
                .OnComplete(delegate
                {


                    Cell standCell = GameManager.instance.mapManager.getCell(new Vector2Int(_x, _y));
                    if (standCell.machine != null)
                        standCell.machine.Enter();  //執行目前所在格子的機關動作



                    move.Check();
                });

        pos = new Vector2Int(_x, _y);


        return true;
    }

    private void Update()
    {
        CameraFollowChar();

        if (Input.GetKeyDown(KeyCode.A))
        {
            HP += 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            HP -= 10;
        }
    }


    Vector3 _vel;
    void CameraFollowChar()
    {
        if (GameManager.instance.itemManager.isPlaying)
        {
            GameManager.instance.mainCamera.transform.position = Vector3.SmoothDamp(
                GameManager.instance.mainCamera.transform.position,
                Vector3.Scale(mainChar.transform.position, new Vector3(1, 1, 0)) + new Vector3(0, 0, -100),
                ref _vel,
                cameraFollow
            );
        }
    }

    public void ChangeCharFace(int _face)
    {
        if (_face != -1)
        {
            charSpRender.sprite = charFaceSp[_face];
        }
    }




    public void View(Vector2 _delta)
    {
        if (!GameManager.instance.itemManager.isPlaying)
        {
            GameManager.instance.mainCamera.transform.position -= new Vector3(_delta.x, _delta.y, 0);
        }
    }
}
