using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScaleY_test : MonoBehaviour {

		[ContextMenu ("Rest0")]
	public void Rest0 () {
		ScreenScaleY_Interface [] SIN = GetComponentsInChildren<ScreenScaleY_Interface> ();
		for (int i = 0; i < SIN.Length; i++) {
			SIN [i].Open0 ();
		}
	}
	
	[ContextMenu ("Rest1")]
	public void Rest1 () {
		ScreenScaleY_Interface [] SIN = GetComponentsInChildren<ScreenScaleY_Interface> ();
		for (int i = 0; i < SIN.Length; i++) {
			SIN [i].Open1 ();
		}
	}
		
	public void Rest (float n) {
		ScreenScaleY_Interface [] SIN = GetComponentsInChildren<ScreenScaleY_Interface> ();
		for (int i = 0; i < SIN.Length; i++) {
			SIN [i].Open ();
		}
	}
}
