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
		public UIEventListener GoPlayButt;
		public UIEventListener RestButt;
		public DragButt MoveViewButt;
		public UIEndCon UIGameOver;
		public UIEndCon UIYouWin;
		public ObjArray OtherButts;
	}
	public _UI UI;

	public void Init () {

		_ = this;

        UI.RestButt.onClick += (go) => {
            UIDelegate.instance.restart();
        };
        UI.UIGameOver.UI.RButt.onClick += (go) => {
            UIDelegate.instance.restart();
        };
        UI.UIYouWin.UI.RButt.onClick += (go) => {
            UIDelegate.instance.restart();
        };
		UI.GoPlayButt.onClick += (go) => {
			UIDelegate.instance.goPlay ();
			OnOffMove (true);
		};
		UI.MoveViewButt.OpenDel += (V3) => {
			UIDelegate.instance.moveView (UI.MoveViewButt.DragV2);
		};
		
    }

	void Start () {
		if (UIDelegate.instance == null) return;

		UIDelegate.instance.lose += () => {
			GameOver ();
		};
		UIDelegate.instance.win += () => {
			YouWin ();
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
	static public void GameOver () {
		_.UI.UIGameOver.Open ();
	}
	static public void YouWin () {
		_.UI.UIYouWin.Open ();
	}
	static public void OnOffMove (bool b) {
		_.UI.MoveViewButt.gameObject.SetActive (!b);
		_.UI.OtherButts.OnOnlyObjs (b ? 1 : 0);
	}
}
