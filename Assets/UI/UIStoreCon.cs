using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStoreCon : ObjArray {
	public UISprite _Butt;

	void Start () {
		for (int i = 0; i < AllObj.Length; i++) {
				UIMainCon._.UI.UIStore.GetObjT <DragButt> (i).EndDel += (V3) => {
				print ("在場地x=" + V3.x + "  y=" + V3.y + "放開");
			};
		}
	}

	public void SetPrice (int n, int value) {
		AllObj [n].obj.GetComponentInChildren <UILabel> ().text = value.ToString ();
	}

	public void ButtonDragStart (GameObject Go) {
		_Butt.gameObject.SetActive (true);
		_Butt.spriteName = Go.GetComponent <UISprite> ().spriteName;
	}
	public void ButtonDragOpen (GameObject Go) {
		_Butt.transform.position = UIMainCon._.UICamera.ScreenToWorldPoint (Input.mousePosition);
	}
	public void ButtonDragEnd (GameObject Go) {
		_Butt.gameObject.SetActive (false);
	}

	[ContextMenu ("test")]
	public void test () {
		SetPrice (0,999);
	}
}
