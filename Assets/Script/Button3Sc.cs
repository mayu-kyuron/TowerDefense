using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Sc : MonoBehaviour {
	
	//オブジェクトの登録
	public GameObject generator;
	public GameObject kazuText;
	public GameObject healer1Pre;
	public GameObject fighter1Pre;
	public GameObject witch1Pre;
		
	//キャラナンバー
	public int charaNumber = 6;
	
	//キャラクターの召喚エネルギー
	public int charaEnergy;
	
	//数スクリプト
	KazuScript kazuSc;
	
	//現在持っているエネルギー
	int bEnergy;
	
//--------------------------------------------------------------
	void Start () {
	
		//数スクリプトの取得
		kazuSc = kazuText.GetComponent<KazuScript>();
		
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
		
		//ヒーラー1
		else if(charaNumber == 6){
			
			//ヒーラー1スクリプトの取得
			Healer1Sc playerScript = healer1Pre.GetComponent<Healer1Sc>();
			//エネルギーの代入
			charaEnergy = playerScript.energy;
		}
	}
//--------------------------------------------------------------
	void Update () {
		//数スクリプトのエネルギーを取得
		bEnergy = kazuSc.energy;
	}
//---------------------------------------------------------------	
	public void ButtonPush(){
		if(bEnergy < charaEnergy){
			Debug.Log("召喚できない");
		}
		else if(bEnergy >= charaEnergy){
			GeneratorScript gs = generator.GetComponent<GeneratorScript>();
			gs.Generate(charaNumber);
			kazuSc.Decrease(charaEnergy);
		}
	}
}
