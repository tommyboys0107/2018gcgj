using UnityEngine;
using System.Collections;

public class MouseCh : MonoBehaviour {
	//取代滑鼠游標(NGUI)
	public GameObject Sp;
	public Camera Tcamera;
	public AudioClip So;
	public Vector3 P;
	void Start () {
		Tcamera = GetComponent<Camera>();
		P *= transform.lossyScale.x;
		Cursor.visible = false;
	}
	

	void OnGUI ()
	{
		Sp.transform.position = Tcamera.ScreenToWorldPoint(Input.mousePosition) + P;
		if (Input.GetMouseButtonDown (0)) {
			Cursor.visible = false;
			Sp.transform.rotation = Quaternion.Euler(new Vector3(0,0,20));
			if(So != null)NGUITools.PlaySound(So);
		}
		if (Input.GetMouseButtonUp (0)) {
			Cursor.visible = false;
			Sp.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
		}
	}
}