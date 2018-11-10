using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DragButt : UIEventListener {//會抓到按下與放開的座標（需要設定主攝影機）

	public Camera ToCam;

	public bool Open;
	
	public Vector2 StartV2;
	public Vector2 LocalStartV2 {
		get {
			return GetLocalV2 (StartV2);
		}
	}
	public Vector2 EndV2;
	public Vector2 LocalEndV2 {
		get {
			return GetLocalV2 (EndV2);
		}
	}
	public Vector2  DragV2 {
		get {
			return EndV2 - StartV2;
		}
	}
	public Vector2 LocalDragV2 {
		get {
			return GetLocalV2 (DragV2);
		}
	}
	public Vector2 GapV2;
	public Vector2 LocalGapV2 {
		get {
			return GetLocalV2 (GapV2);
		}
	}
	public bool IsMove;

	public UnityEvent	StartEvent;
	public VoidDel 		StartDel;
	public UnityEvent	OpenEvent;
	public VoidDel 		OpenDel;
	public UnityEvent   EndEvent;
	public VoidDel		EndDel;
	
	void Start () {
//		StartDel = new VoidDel ();
//		OpenDel = new VoidDel ();
//		EndDel = new VoidDel ();

		if (ToCam == null) {
			ToCam = Camera.main;
		}
		onPress += (go, state) => {
			Open = state;
			if (state) {
				StartV2 = GetV2 (Input.mousePosition);
				GapV2 = (Vector2)(transform.position) - StartV2;
				StartEvent.Invoke ();
				LoadDel (StartDel);
			} else {
				EndEvent.  Invoke ();
				LoadDel (EndDel);
			}
		};
	}

	 void Update () {
		if (!Open) return;
		EndV2   = GetV2 (Input.mousePosition);
		if (IsMove) {
			transform.position = EndV2 + GapV2;
		}
		OpenEvent.Invoke ();
		LoadDel (OpenDel);
	}

	public void LoadDel (VoidDel Del) {
		if (Del != null) {
			Del ();
		}
	}

	public Vector2 GetV2 (Vector3 V3) {
		return GetV2 (ToCam, V3);
	}
	public Vector2 GetV2 (Camera Cam, Vector3 V3) {
		return Cam.ScreenToWorldPoint (V3);
	}

	public Vector2 GetLocalV2 (Vector2 V2) {
		return V2 / ToCam.transform.lossyScale.x;
	}
	public Vector2 GetULoacalV2 (Vector2 V2) {
		return V2 * ToCam.transform.lossyScale.x;
	}
}
