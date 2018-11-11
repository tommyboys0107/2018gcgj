using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndCon : MonoBehaviour {

	[Serializable]
	public struct _UI {
		public UIEventListener RButt;
		public UITweener Tween;
	}
	public _UI UI;

	public void Open () {
		UI.Tween.Play (true);
	}
}
