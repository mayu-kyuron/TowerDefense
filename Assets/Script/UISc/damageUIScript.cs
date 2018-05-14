﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageUIScript : MonoBehaviour {
	
	Text damageText;
	
	public float damage = 0;
	
	//テキストの透明度
	float alpha;
	
	//フェードアウトするスピード
	float fadeSpeed = 1.3f;
	
	//テキストの移動値
	float moveValue = 0.4f;
	
	// Use this for initialization
	void Start () {
		damageText = GetComponentInChildren<Text>();
		damageText.text = damage.ToString();
		alpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//透明にしていく
		alpha -= fadeSpeed * Time.deltaTime;
		
		//テキストのcolor
		damageText.color = new Color(0, 1, 0, alpha);
		
		transform.position += Vector3.up * moveValue * Time.deltaTime;
		
		if(alpha < 0){
			Destroy(gameObject);
		}
	}
}
