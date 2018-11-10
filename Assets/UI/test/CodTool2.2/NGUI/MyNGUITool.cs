using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NGUI自製進階工具
/// </summary>
public class MyNGUITool : MonoBehaviour {

	/// <summary>
	/// 讓某個漸變從n開始然後播放/倒轉(用b控制)
	/// </summary>
	static public void TwPlay (UITweener tw, float n, bool b) {
		tw.tweenFactor = n;
		tw.Sample (n, true);
		tw.Play (b);
	}
}