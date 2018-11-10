using UnityEngine;
//using System.Collections;

public class ColorButt : UIEventListener {
	//可以改變一個按鈕的顏色的陽春按鈕(需裝ＮＧＵＩ)
	[System.Serializable]
	public struct ColorMod {
		public UIWidget Obj;
		public Color OnColor;// = Color.black;
		public Color OffColor;// = Color.white;
	}
	/// <summary>
	/// 觸動行還是切換型
	/// </summary>
	public bool Switch = false;

	public bool OK;

	public ColorMod[] ColorMods = new ColorMod[2];

	void Start () {
		if (Switch) {
			onClick += (go) => {
				SetColor (!OK);
				OK = !OK;
			};
		} else {
			onPress += (GameObject go, bool state) => {
				OK = state;
				SetColor (state);
			};
		}
	}

	public void SetColor (bool state) {
		foreach (ColorMod i in ColorMods) {
			if (state) {
				i.Obj.color = i.OnColor;
			} else {
				i.Obj.color = i.OffColor;
			}
		}
	}

	[ContextMenu ("GetObjColor")]
	public void GetObjColor () {
		ColorMods [0].Obj = GetComponent <UIWidget> ();
		for (int i = 0; i < ColorMods.Length; i++) {
			ColorMod _i = ColorMods [i];
			ColorMods [i].OnColor  = _i.Obj.color;
			ColorMods [i].OffColor = _i.Obj.color;
		}
	}
}
