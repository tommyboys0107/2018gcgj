using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaleY_Col : MonoBehaviour,ScreenScaleY_Interface {
	public BoxCollider2D Coll;
	public Rect MaxY;
	public Rect MinY;

	void Start () {
		Open ();
	}
	[ContextMenu ("open0")]
	public void Open0 () {
		Coll.offset = MinY.position;
		Coll.size = MinY.size;
	}
	[ContextMenu ("open1")]
	public void Open1 () {
		Coll.offset = MaxY.position;
		Coll.size = MaxY.size;
	}
	public void Open () {
		Coll.offset = GetXY ();
		Coll.size = GetWH ();
	}

	public Vector2 GetXY () {
		float x = (MaxY.x - MinY.x) * ScreenScaleY.Me.YScale + MinY.x;
		float y = (MaxY.y - MinY.y) * ScreenScaleY.Me.YScale + MinY.y;
		return new Vector2 (x, y);
	}
	public Vector2 GetWH () {
		float w = (MaxY.width - MinY.width) * ScreenScaleY.Me.YScale + MinY.width;
		float h = (MaxY.height - MinY.height) * ScreenScaleY.Me.YScale + MinY.height;
		return new Vector2 (w, h);
	}
}
