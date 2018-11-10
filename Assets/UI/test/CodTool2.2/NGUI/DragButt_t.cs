using UnityEngine;
using System.Collections;

public class DragButt_t : DragButt{

	public bool  Out;
	public Vector2 OutLong = new Vector2 (100, 0);
	public DragButt Father;
	
	void Start () {
		if (ToCam == null) {
			ToCam = Camera.main;
		}
		onPress += (go, state) => {
			Open = state;
			if (state) {
				StartV2 = GetV2 (Input.mousePosition);
				StartEvent.Invoke ();
				
			} else {
				if (!Out) {
					EndEvent.Invoke ();
				} else {
					Father.onPress (Father.gameObject, false);
				}
				Out = false;
			}
		};
	}
	
	void Update () {
		if (Open) {
			EndV2   = GetV2 (Input.mousePosition);
//			print (GetLocalV2 (DragV2).ToString ("0.0000"));
			if (!Out) {
				Vector2 V2 = GetULoacalV2 (OutLong);
				if ((V2.x != 0 && Mathf.Abs (DragV2.x) > V2.x) || (V2.y != 0 && Mathf.Abs (DragV2.y) > V2.y)) {
					Out = true;
					Father.onPress (Father.gameObject, true);
				}
				OpenEvent.Invoke ();
			}
		}
	}

	public void Test (string n) {
		print (n);
	}
}