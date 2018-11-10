using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaleY_Siz : MonoBehaviour,ScreenScaleY_Interface {

	public float MaxY = 1;
	public float MinY = 0.8f;

	void Start () {
		Open ();
	}
	[ContextMenu ("open0")]
	public void Open0 () {
		transform.localScale = Vector3.one * MinY;
	}
	[ContextMenu ("open1")]
	public void Open1 () {
		transform.localScale = Vector3.one * MaxY;
	}
	public void Open () {
		transform.localScale = Vector3.one * ((MaxY - MinY) * (ScreenScaleY.Me.YScale) + MinY);
	}
}
