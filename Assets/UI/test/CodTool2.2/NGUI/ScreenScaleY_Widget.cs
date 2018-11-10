using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaleY_Widget : MonoBehaviour,ScreenScaleY_Interface {
	public UIWidget Widget;

	public int MaxY = 200;
	public int MinY = 180;

	void Start () {
		if (Widget == null) {
			Widget = GetComponent <UIWidget> ();
		}
		Open ();
	}

	[ContextMenu ("open0")]
	public void Open0 () {
		Widget.height = MinY;
	}
	[ContextMenu ("open1")]
	public void Open1 () {
		Widget.height = MaxY;
	}
	public void Open () {
		Widget.height = ((MaxY - MinY) * (ScreenScaleY.Me.YScaleInt) + MinY);
	}
}
