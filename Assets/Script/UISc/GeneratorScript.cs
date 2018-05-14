using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorScript : MonoBehaviour {
	
	//オブジェクトの登録
	public GameObject fighter1Pre;
	public GameObject witch1Pre;
	public GameObject healer1Pre;
	public GameObject slimePre;
	public GameObject gaitherPre;
	
	public GameObject firstBPre;
	
	FirstScript firstS;
	
	//出すオブジェクトの宣言
	GameObject go;
	GameObject MGo;
	
	//確率
	int dice;
	
	//時間
	float time = 0;
	float callTime = 0;
	
	int number = 0;
	int Maxnumber = 20;
	int deathNumber = 0;
	// Use this for initialization
	void Start () {
		firstS = firstBPre.GetComponent<FirstScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(firstS.flag){
			time += Time.deltaTime;
			if(number < Maxnumber){
				if(time >= callTime){
					time = 0;
					dice = Random.Range(1, 6);
					if(dice <= 3){
						MGo = Instantiate(slimePre) as GameObject;
					}else{
						MGo = Instantiate(gaitherPre) as GameObject;
					}
					MGo.transform.position = new Vector2(7, -2);
					number++;
					callTime = Random.Range(1, 7);
				}
			}
		}
		if(deathNumber == Maxnumber){
			Invoke("Clear", 2.0f);
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
		go.transform.position = new Vector2(-7, -2);
	}
	
	public void Count(){
		deathNumber++;
	}
	
	void Clear(){
		SceneManager.LoadScene("Clear");
	}
}
