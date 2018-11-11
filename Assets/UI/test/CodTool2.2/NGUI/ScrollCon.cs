using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScrollCon : MonoBehaviour
{//用來讀取拖動條的刻度
	public UIScrollView Scroll;
	
	[System.Serializable]
	public struct ScrollObj {
		public float g;
		public Transform From;
		public GameObject [] AllObj;
		public int ObjL {
			get {
				return AllObj.Length;
			}
		}
	}
	
	public ScrollObj XObj;
	public int Xn {
		get {
			if (XObj.ObjL <= 0) {
				return 0;
			}
			return Getn (XObj);
		}
		set {
			Setn (XObj, value, Yn);
		}
	}
	
	
	public ScrollObj YObj;
	public int Yn {
		get {
			if (YObj.ObjL <= 0) {
				return 0;
			}
			return Getn (YObj);
		}
		set {
			Setn (YObj, Xn, value);
		}
	}

	public Void_IntIntDel UpDateEvent;
	void Update () {
		if (UpDateEvent != null) {
			UpDateEvent (Xn, Yn);
		}
	}

	public int Getn (ScrollObj Obj) {
		return (int)MyCalculate.SaladMod ((-transform.localPosition.y + Obj.g / 2) / Obj.g, Obj.ObjL);
	}
	public void Setn (ScrollObj Obj, int x , int y) {
		transform.localPosition = new Vector3 (x, y) * -Obj.g;
		GetComponent<UIPanel> ().clipOffset = -transform.localPosition;
	}
}
