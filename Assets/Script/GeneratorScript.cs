using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {
	
	//オブジェクトの登録
	public GameObject fighter1Pre;
	public GameObject witch1Pre;
	public GameObject healer1Pre;
	public GameObject slimePre;
	public GameObject gaitherPre;
	
	//出すオブジェクトの宣言
	GameObject go;
	GameObject MGo;
	
	//確率
	int dice;
	
	//時間
	float time = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time >= 10000){
			time = 0;
			dice = Random.Range(1, 4);
			if(dice <= 2){
				MGo = Instantiate(slimePre) as GameObject;
			}else{
				MGo = Instantiate(gaitherPre) as GameObject;
			}
			MGo.transform.position = new Vector2(7, -2);
		}
	}
	public void Generate(int charaBango){
		if(charaBango == 1){
			go = Instantiate(fighter1Pre) as GameObject;
		}
		else if(charaBango == 4){
			go = Instantiate(witch1Pre) as GameObject;
		}
		else if(charaBango == 6){
			go = Instantiate(healer1Pre) as GameObject;
		}
		go.transform.position = new Vector2(-6, -2);
	}
}
