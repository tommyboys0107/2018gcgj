using UnityEngine;
//using UnityEditor;
using UnityEngine.Events;
using System.Collections;

public class CriteriumTw : MonoBehaviour {
	//在某幾個物件之間輪迴移動每到一個物件都會啟動一個Event(NGUI)

	public TweenTransform Tw;
	
	[System.Serializable]
	public struct T {
		public GameObject Obj;
		public float duration;
		public UnityEvent Eve;
	}

	public T[] AllT;

	public int NowP = -1;
	public int NextP {
		get {
			return (NowP + 1) % AllT.Length;
			}
	}
	
	void Start () {
		if (Tw == null) Tw = gameObject.AddComponent<TweenTransform>();
		Tw.onFinished.Add (new EventDelegate(this,"Go"));
		//Go ();
	}
	
	[ContextMenu("Go")]
	public void Go () {
		NowP = NextP;
		Tw.from = AllT [NowP].Obj.transform;
		Tw.to = AllT [NextP].Obj.transform;
		Tw.duration = AllT[NowP].duration;
		Tw.ResetToBeginning();
		Tw.PlayForward ();
		AllT [NowP].Eve.Invoke ();
	}
	

	public void test (string a) {
		print (a);
	}
}
