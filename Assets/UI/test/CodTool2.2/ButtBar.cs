using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtBar : ObjArray {

	public GameObject c;

	public Void_IntDel Del;

	public int _n = -1;
	public int n {
		get { 
			return _n;
		}
		set {
			if (Del != null) Del (value);

			_n = value;
		}
	}

	void Start () {
		for (int i = 0; i < AllObj.Length; i++) {
			UIEventListener _i = AllObj [i].obj.GetComponent <UIEventListener> ();
			int ii = i;
			_i.onClick += (go) => {
				n = ii;
			};
		}

		Del += (n) => {
			if (c != null) {
				if (n >= 0) {
					c.gameObject.SetActive (true);
					c.transform.position = AllObj [n].obj.transform.position;
				} else {
					c.gameObject.SetActive (false);
				}
			}
		};
	}
}
