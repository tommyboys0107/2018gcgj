﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;


public class ObjArray : MonoBehaviour {
	[System.Serializable]
	public struct Obj {
		public bool Open {
			get {
				return obj.activeSelf;
			}
		}
		public GameObject obj;
		public UnityEvent EnterEvent;
		public UnityEvent ExitEvent;
	}
	public Obj[] AllObj;
	

	[System.Serializable]
	public struct TestMod {
		public int TestInt {
			get {
				int n = _TestInt;
				_TestInt ++;
				return n;
			}
			set {
				_TestInt = value;
			}
		}
		public int _TestInt;
		public bool TestBool;
	}
	public TestMod Test;

	[ContextMenu ("OnOffObj")]
	public void OnOffObj () {
		OnOffObj (Test.TestInt, Test.TestBool);
	}
	/// <summary>
	/// 開啟或關閉某個物件 並啟動事件
	/// </summary>
	public void OnOffObj (int n, bool OnOff) {
		n = MyCalculate.SaladModInt (n, AllObj.Length);
		if (AllObj [n].obj == null) {
			return;
		}

		if (AllObj [n].Open == OnOff) {
			return;
		}
		AllObj [n].obj.SetActive (OnOff);
		if (OnOff) {
			if(AllObj [n].EnterEvent != null) AllObj [n].EnterEvent.Invoke ();
		} else {
			if(AllObj [n].ExitEvent != null) AllObj [n].ExitEvent.Invoke ();
		}
	}

	[ContextMenu ("OnOffAll")]
	public void OnOffAll () {
		OnOffAll (Test.TestBool);
	}
	/// <summary>
	/// 開啟或關閉全部物件
	/// </summary>
	public void OnOffAll (bool OnOff) {
		for (int i = 0; i < AllObj.Length; i++) {
			OnOffObj(i,OnOff);
		}
	}

	[ContextMenu ("OnOnlyObjs")]
	public void OnOnlyObjs () {
		OnOnlyObjs (Test.TestInt);
	}
	/// <summary>
	/// 關閉全部只留下一個
	/// </summary>
	public void OnOnlyObjs (int n) {
		for (int i = 0; i < AllObj.Length; i++) {
			OnOffObj (i, n == i);
		}
	}
	/// <summary>
	/// 關閉全部只留下幾個
	/// </summary>
	public void OnOnlyObjs (int [] ns) {
		for (int i = 0; i < AllObj.Length;i++) {
			bool A = false;
			for (int j = 0; j < ns.Length; j++) {
				if (ns [j] == i){
					A = true;
				}
			}
			OnOffObj (i, A);
		}
	}

	[ContextMenu ("ContinuousObj")]
	public void ContinuousObj () {
		ContinuousObj (Test.TestInt);
	}
	/// <summary>
	/// 把物件打開到end
	/// </summary>
	public void ContinuousObj (int end) {
		ContinuousObj (0,end);
	}
	/// <summary>
	/// 把物件從start打開到end
	/// </summary>
	public void ContinuousObj (int star, int end) {
		for (int i = 0; i < AllObj.Length; i++) {
			if (i >= star && i <= end) {
				OnOffObj (i, true);
			} else {
				OnOffObj (i, false);
			}
		}
	}
	
	[ContextMenu ("SetObj")]
	public void SetObj() {
		AllObj = new Obj [transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			AllObj [i].obj = transform.GetChild (i).gameObject;
		}
	}
	[ContextMenu ("ResetObj")]
	public void ResetObj () {
		List <Obj> r = new List<Obj> ();
		for (int i = 0; i < AllObj.Length; i++) {
			if (AllObj [i].obj != null) {
				r.Add (AllObj [i]);
			}
		}
		AllObj = r.ToArray ();
	}
	public T GetObjT<T> (int n) {
		return AllObj [n].obj.GetComponent <T> ();
	}
}
