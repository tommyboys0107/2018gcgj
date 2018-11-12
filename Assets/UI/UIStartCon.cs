using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartCon : MonoBehaviour {

	public UIEventListener StartButt;
	public UIEventListener PeopleButt;
	public GameObject Peoples;

	void Start () {
		StartButt.onClick += (go) => {
			SceneManager.LoadScene ("main");
		};
		PeopleButt.onClick += (go) => {
			if (Peoples.gameObject.active) {
				Peoples.gameObject.SetActive (false);
			} else {
				Peoples.gameObject.SetActive (true);
			}
		};
	}
}
