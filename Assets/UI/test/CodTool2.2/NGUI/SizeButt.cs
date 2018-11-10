using UnityEngine;
using System.Collections;

public class SizeButt : UIEventListener {
	public GameObject Obj;
	public UIWidget widget;
	Vector2Int StartSize;
	public float[] Sizes = new float[]{1.1f,1f};


	void Start () {
		if (widget == null) {
			onPress += (GameObject go, bool state) => {
				if(state){
					Obj.transform.localScale = Vector3.one * Sizes[0];
				} else {
					Obj.transform.localScale = Vector3.one * Sizes[1];
				}
			};
		} else {
			StartSize = new Vector2Int (widget.width, widget.height);
			onPress += (GameObject go, bool state) => {
				if(state){
					widget.width = (int)(StartSize.x * Sizes [0]);
					widget.height = (int)(StartSize.y * Sizes [0]);
				} else {
					widget.width = (int)(StartSize.x * Sizes [1]);
					widget.height = (int)(StartSize.y * Sizes [1]);
				}
			};
		}
	}

	[ContextMenu ("GetObj")]
	public void GetObj () {
		Obj = gameObject;
		Sizes [0] = transform.localScale.x * 1.1f;
		Sizes [1] = transform.localScale.x;
	}
}
