using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//エネルギー数
public class KazuScript : MonoBehaviour {

	//エネルギーテキスト
	public GameObject kazuText;
	
	//エネルギー数
	public int energy = 0;
	
	//時間
	float time = 1.0f;
	
	//ボタン１のスクリプト
	Button1Script buttonScript;
	//ボタン1の登録
	public GameObject button1;
	
	//プレイヤーの必要エネルギー
	int playerEnergy;
	
//---------------------------------------------------------------------------------------------------
	void Start () {
	}
	
//---------------------------------------------------------------------------------------------------
	void Update () {
		
		time -= Time.deltaTime;
		
		if(time <= 0.0f && energy < 20){
			energy += 5;
			kazuText.GetComponent<Text>().text = this.energy.ToString();
			time = 1.0f;
		}
	}
	
	public void Decrease(int charaEnergy){
		energy -= charaEnergy;
		this.kazuText.GetComponent<Text>().text = this.energy.ToString();
	}
}
