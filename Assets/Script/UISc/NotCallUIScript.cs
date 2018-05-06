using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotCallUIScript : MonoBehaviour {

	Text damageText;
	
	//テキストの透明度
	float alpha;
	
	//フェードアウトするスピード
	float fadeSpeed = 0.5f;
	
	// Use this for initialization
	void Start () {
		damageText = GetComponentInChildren<Text>();
		alpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//透明にしていく
		alpha -= fadeSpeed * Time.deltaTime;
		
		//テキストのcolor
		damageText.color = new Color(1, 0, 0, alpha);
		
		if(alpha < 0){
			Destroy(gameObject);
		}
	}
}
