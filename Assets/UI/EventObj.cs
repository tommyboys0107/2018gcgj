using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventObj : UIEventListener {
	public UnityEvent Event;
	
	public void Start () {
		onClick += (go) => {
			Event.Invoke ();
		};
	}

	public void Print (string Text) {
		print (Text);
	}
}
