using UnityEngine;
using System.Collections;

public class ImButt : UIEventListener {
	//改變按鈕圖片的陽春按鈕（NGUI）
	public UISprite Sp;
	
	public string OnImName = "0";
	public string OffImName = "1";

	void Start () {
		onPress += (GameObject go, bool state) => {
			if(state){
				Sp.spriteName = OnImName;
			} else {
				Sp.spriteName = OffImName;
			}
		};
	}

	[ContextMenu ("SetObj")]
	public void SetObj () {
		Sp = GetComponent <UISprite> ();
		OnImName = Sp.spriteName;
		OffImName = Sp.spriteName;
	}
}
