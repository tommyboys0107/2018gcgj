using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStoreCon : ObjArray {
	public UISprite _Butt;

	public delegate bool Bool_IntDel (int n);

	void Start () {
		for (int i = 0; i < AllObj.Length; i++) {
			int _i = i;
			UIMainCon._.UI.UIStore.GetObjT <DragButt> (i).StartDel += (V3) => {
				// Bool_IntDel DelInt = (n) => {
				// 	print ("選取" + n + "號道具");
				// 	return n == 0;
				// };
				// bool b = DelInt (_i);
				bool b = UIDelegate.instance.buyItem (_i);
				if (!b) {
					print ("錢不夠中斷購買");
					GetObjT <DragButt> (_i).Open = false;
				} else {
					_Butt.gameObject.SetActive (true);
					_Butt.spriteName = GetObjT <UISprite> (_i).spriteName;
				}
			};
			UIMainCon._.UI.UIStore.GetObjT <DragButt> (i).EndDel += (V3) => {
				print ("在場地x=" + V3.x + "  y=" + V3.y + "放開");
			};
		}
	}

	public void SetPrice (int n, int value) {
		AllObj [n].obj.GetComponentInChildren <UILabel> ().text = value.ToString ();
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
