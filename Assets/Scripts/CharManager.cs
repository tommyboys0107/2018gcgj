using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharManager : MonoBehaviour 
{
    [SerializeField]
    GameObject mainChar;
    [SerializeField]
    SpriteRenderer charSpRender;
    public Move move;

    public Sprite[] charFaceSp;

    [Header("攝影機跟隨的速度")]
    public float cameraFollow = 0.5F;


    int _leaveTime = 0;
    public int leaveTime
    {
        get { return _leaveTime; }
        set 
        {
            if (value == 0) GameManager.instance.timeUp();
            _leaveTime = value;
        }

    }

    public Vector2Int pos;



    private void Start()
    {
        move.Check();
    }

    public bool charMoveTo(int _x,int _y)
    {
        float MoveTime = 0.5F;
        mainChar.transform.DOMove(GameManager.instance.mapManager.cellToWorld(new Vector3Int(_x, _y, 0)) + new Vector3(0, 0, -1), MoveTime)
                .OnComplete(delegate
                {
                    move.Check();
                });

        pos = new Vector2Int(_x, _y);


        return true;
    }

    private void Update()
    {
        CameraFollowChar();
    }


    Vector3 _vel;
    void CameraFollowChar()
    {
        GameManager.instance.mainCamera.transform.position = Vector3.SmoothDamp(
            GameManager.instance.mainCamera.transform.position,
            Vector3.Scale(mainChar.transform.position, new Vector3(1, 1, 0)) + new Vector3(0, 0, -100),
            ref _vel,
            cameraFollow
        );
    }

    public void ChangeCharFace(int _face)
    {
        if (_face != -1)
        {
            charSpRender.sprite = charFaceSp[_face];
        }
    }

}
