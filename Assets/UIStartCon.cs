using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartCon : MonoBehaviour {

	public UIEventListener StartButt;

	void Start () {
		StartButt.onClick += (go) => {
			SceneManager.LoadScene ("main");
		};
	}
}
