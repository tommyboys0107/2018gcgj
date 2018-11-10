using UnityEngine;
using UnityEngine.Events;
//using System.Collections;

public class DragDetect : MonoBehaviour {
	//偵測手指按下後是否有快速拖動 有的話放開時不啟動OpenEvent
	public UIEventListener Butt;
	public float DragLeng = 5;
	public bool Open;
	public UnityEvent OpenEvent;
	public UnityEvent CloseEvent;//一出現快速拖動現象馬上啟動它
	
	
	
	void Start () {
		Butt.onPress += (go, state) => {
			if (!state && Open) {
				OpenEvent.Invoke ();
			}
			Open = state;
		};

		Butt.onDrag += (go, delta) => {//已將界線判斷由方形改為原型 但還沒測試
			if (delta.magnitude > DragLeng) {
				CloseEvent.Invoke ();
				Open = false;
			}
		};
	}
}
