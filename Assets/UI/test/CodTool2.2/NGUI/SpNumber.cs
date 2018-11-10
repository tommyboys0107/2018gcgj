using UnityEngine;
using System.Collections;

public class SpNumber : MonoBehaviour {//單存的生產出數字（只掌管生產）
	public GameObject Number;//基底數字ＯＢＪ

	public string NumberNames = "";//數字圖片名
	[System.Serializable]
	public struct Symbol {
		public char Name;
		public string ImName;
	}
	public Symbol [] AllSymbol;//特殊符號表Ｓ
	public string NullSymbol;
	
	public UIGrid Grid;

	[ContextMenu("test")]
	void test() {
		StartNumber (-1.234f);
	}
	
	public GameObject[] StartNumber (float n) {
		return StartNumber (n.ToString ());
	}
	public GameObject[] StartNumber (string n)
	{
		GameObject [] r = new GameObject [n.Length];
		for (int i = 0; i < n.Length; i++) {
			r [i] = SpOneNumber (GetImName (n [i]));
		}
		Grid.enabled = true;
		return r;
	}
	
	
	public GameObject SpOneNumber (string Name) {//生產數字
		GameObject a = MyCalculate.SpObj (Number, transform, Vector3.zero);
		ChIm (a.GetComponent<UISprite> (), Name);
		return a;
	}

	public string GetImName (char n) {//返回這個符號對應的圖片名字
		if ("0123456789".IndexOf (n) != -1) {//這一個符號是否是數字？
				return NumberNames + n;
			} else {
				for (int j = 0; j < AllSymbol.Length; j++) {//特殊符號表裡是否有能用的
					if (n == AllSymbol [j].Name) {
						return AllSymbol [j].ImName;
					}
				}
				return NullSymbol;
			}
	}

	public void ChIm (UISprite UI,string Name) {//改變字體圖鑑
		UI.spriteName = Name;
	}
}
