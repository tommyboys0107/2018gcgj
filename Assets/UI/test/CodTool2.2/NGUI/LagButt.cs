using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 按著過一段時間才會生效的按鈕
/// </summary>
public class LagButt : UIEventListener {

	public float Time;
	public UnityEvent StartEvent;
	public UnityEvent EndEvent;

	IEnumerator ModObj;
	void Start () {
		onPress += (go, state) => {
			if (state) {
				ModObj = Open ();
				StartCoroutine (ModObj);
			} else {
				StopCoroutine (ModObj);
			}
		};
	}
	
	public IEnumerator Open () {
		StartEvent.Invoke ();
		yield return new WaitForSeconds (Time);
		EndEvent.Invoke ();
	}
}
