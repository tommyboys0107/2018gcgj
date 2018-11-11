using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TimeLoop : MonoBehaviour {
	public Void_IntDel Del;
	public UnityEvent TheEvent;
	public float Delay;
	public float Time = 1;
	public int n;

	void Start () {
		StartCoroutine(StartDel());
	}

	public void Open ()
	{
		enabled = true;
		StartCoroutine(StartDel());
	}

	public IEnumerator StartDel ()
	{
		yield return new WaitForSeconds (Delay);
		for (;;) {
			if(Del != null) Del(n);
			TheEvent.Invoke();
			n++;
			yield return new WaitForSeconds(Time);
		}
	}

	public void Test () {
		print (n);
	}
}
