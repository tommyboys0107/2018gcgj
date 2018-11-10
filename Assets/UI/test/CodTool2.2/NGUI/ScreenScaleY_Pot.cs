using UnityEngine;
using System.Collections;

public class ScreenScaleY_Pot : MonoBehaviour,ScreenScaleY_Interface {

	public float MaxY;
	public float MinY;

	public float x {
		get {
			return transform.localPosition.x;
		}
	}
	void Start () {
		Open ();
	}

	[ContextMenu ("set0")]
	public void set0 () {
		MinY = transform.localPosition.y;
	}
	[ContextMenu ("set1")]
	public void set1 () {
		MaxY = transform.localPosition.y;
	}

	[ContextMenu ("open0")]
	public void Open0 () {
		transform.localPosition = new Vector3 (x, MinY, 0);
	}
	[ContextMenu ("open1")]
	public void Open1 () {
		transform.localPosition = new Vector3 (x, MaxY, 0);
	}
	public void Open () {
		transform.localPosition = new Vector3 (x, (MaxY - MinY) * (ScreenScaleY.Me.YScale) + MinY, 0);
	}
}
