using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NumberBar : SpNumber {
	public int Long;

	public List<GameObject> ALLNumber;
	
	//IEnumerator Start () {
	//	yield return new WaitForSeconds (1);
	//	ReCheck (123.4f);
	//	yield return new WaitForSeconds (1);
	//	ReCheck (99);
	//	yield return new WaitForSeconds (1);
	//	ReCheck (-99999.9f);
	//	yield return new WaitForSeconds (1);
	//	ReCheck (5);
	//	yield return new WaitForSeconds (1);
	//	ReCheck (100000f);
	//}

	public void ReCheck (float n) {
		string zeros = "";
		for (int i = 0; i < n; i++) {zeros += "0";}
		string _n = n.ToString (zeros + ".0");
		print (_n);
		ReCheck (_n);
	}
	
	public void ReCheck (string n) {
		//string _n = n.ToString ();
		for (int i = 0; i < n.Length; i++) {//檢查每一節符號
			string ImName = GetImName (n [i]);
			if (i + 1 > ALLNumber.Count) {//數字物件是否已經存在
				GameObject a = SpOneNumber (ImName);
				ALLNumber.Add (a);
			} else {
				ChIm (ALLNumber [i].GetComponent<UISprite> (), ImName);
			}
		}

		List<GameObject> DidObj = new List<GameObject> ();//預計會辦刪除的物件群組
		for (int i = n.Length;i < ALLNumber.Count;i++) {//挑出用不到的數字如果小於長度就變成零如果大於長度就丟入DidObj
			DidObj.Add (ALLNumber [i]);
		}
		for (int i = 0; i < DidObj.Count; i++) {
			ALLNumber.Remove (DidObj [i]);
			Destroy (DidObj [i]);	
		}
		Grid.enabled = true;
	}
}