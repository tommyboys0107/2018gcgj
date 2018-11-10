using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStoreCon : ObjArray {
	public UISprite _Butt;

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
		Vector2 EndV2 = Go.GetComponent <DragButt> ().EndV2;
		print ("在場地x=" + EndV2.x + "  y=" + EndV2.y + "放開");


		GameObject aaaa = GameObject.Find ("aaaa");
		aaaa.transform.position = EndV2;
	}

	[ContextMenu ("test")]
	public void test () {
		SetPrice (0,999);
	}
}
