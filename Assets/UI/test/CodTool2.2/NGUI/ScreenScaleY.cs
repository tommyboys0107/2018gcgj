using UnityEngine;
using System.Collections;

public class ScreenScaleY : MonoBehaviour {//指定一的UIWidget跟最大與最小尺寸算出縮放比例0~1

	static public ScreenScaleY Me;
	
	public UIPanel D;

	/// <summary>
	/// 目標的長寬比例 高/寬
	/// </summary>
	public float ScreenHW {
		get {
			if (D == null) {
				return (float)Screen.height / (float)Screen.width;
			} else {
				return (float)D.height / (float)D.width;
			}
		}	
	}

	/// <summary>
	/// 通常設定為1536
	/// </summary>
	public float X = 1536;
	/// <summary>
	/// 若寬為Ｘ那麼高為多少？
	/// </summary>
	public float Y {
		get {
			return ScreenHW * X;
		}
	}
	public float MaxY = 2726;
	public float MinY = 2048;

	public float YScale {
		get {
			return (Y - MinY) / (MaxY - MinY);
		}
	}
	public int YScaleInt {
		get {
			return (int)YScale;
		}
	}
	void Awake () {
		Me = this;
	}

	//[ContextMenu ("Rest0")]
	//public void Rest0 () {
	//	ScreenScaleY_Interface [] SIN = GetComponentsInChildren<ScreenScaleY_Interface> ();
	//	for (int i = 0; i < SIN.Length; i++) {
	//		SIN [i].Open0 ();
	//	}
	//}
	
	//[ContextMenu ("Rest1")]
	//public void Rest1 () {
	//	ScreenScaleY_Interface [] SIN = GetComponentsInChildren<ScreenScaleY_Interface> ();
	//	for (int i = 0; i < SIN.Length; i++) {
	//		SIN [i].Open1 ();
	//	}
	//}

	//[ContextMenu ("Rest")]
	//public void Rest (float n) {
	//	ScreenScaleY_Interface [] SIN = GetComponentsInChildren<ScreenScaleY_Interface> ();
	//	for (int i = 0; i < SIN.Length; i++) {
	//		SIN [i].Open ();
	//	}
	//}
}

public interface ScreenScaleY_Interface {
	void Open ();
	void Open0 ();
	void Open1 ();
}
