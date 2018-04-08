using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2Sc : MonoBehaviour {
	
	//オブジェクトの登録
	public GameObject generator;
	public GameObject kazuText;
	public GameObject fighter1Pre;
	public GameObject witch1Pre;
	
	//キャラクターナンバー
	public int charaNumber = 4;
	
	//キャラクターの必要エネルギー
	public int charaEnergy;
	
	//数スクリプト
	KazuScript kazuScript;
	
	//現在持っているエネルギー数
	int bEnergy;
	
//----------------------------------------------------------------------------------------
	void Start () {
	
		//数スクリプトの取得
		kazuScript = kazuText.GetComponent<KazuScript>();
		
		//ファイター1なら
		if(charaNumber == 1){
		
			//ファイター1スクリプトの取得
			Fighter1Script playerScript= fighter1Pre.GetComponent<Fighter1Script>();
			//エネルギーの代入
			charaEnergy = playerScript.energy;
		}
		
		//ウィッチ1
		else if(charaNumber == 4){
			
			//ウィッチ1スクリプトの取得
			Witch1Sc playerScript = witch1Pre.GetComponent<Witch1Sc>();
			//エネルギーの代入
			charaEnergy = playerScript.energy;
		}
		
	}
//-------------------------------------------------------------------------------------------
	void Update () {
		//数スクリプトのエネルギーを取得
		bEnergy = kazuScript.energy;
	}
	public void ButtonPush(){
		if(bEnergy < charaEnergy){
			Debug.Log("召喚できない");
		}
		else if(bEnergy >= charaEnergy){
			GeneratorScript gs = generator.GetComponent<GeneratorScript>();
			gs.Generate(charaNumber);
			kazuScript.Decrease(charaEnergy);
		}
	}
}
