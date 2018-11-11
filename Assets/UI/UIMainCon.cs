using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainCon : MonoBehaviour {
	static public UIMainCon _;
	public Camera UICamera;

	[Serializable]
	public struct _UI {
		public UIStoreCon UIStore;
		public UILabel HPLabel;
		public UILabel GPLabel;
		public UIEventListener RestButt;
	}
	public _UI UI;

	void Awake () {
		_ = this;
	}

	void Start () {
		UI.RestButt.onClick += (go) => {
			UIDelegate.instance.restart();
		};
	}

	static public void SetHP (int value) {
		_.UI.HPLabel.text = value.ToString ();
	}
	static public void SetGP (int value) {
		_.UI.GPLabel.text = value.ToString ();
	}
	static public void SetPrice (int n, int value) {
		_.UI.UIStore.AllObj [n].obj.GetComponentInChildren <UILabel> ().text = value.ToString ();
	}
}
