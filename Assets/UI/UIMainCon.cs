using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainCon : MonoBehaviour {
	static public UIMainCon _;
	public Camera UICamera;

	[Serializable]
	public struct _UI {
		public UIStoreCon UIStore;
	}
	public _UI UI;

	void Awake () {
		_ = this;
	}
}
