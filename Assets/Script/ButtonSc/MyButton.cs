using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButton : MonoBehaviour {
	
	GameObject Serect1;
	Serect1 serect1;
	
	GameObject Charahyozi;
	Charahyozi hyozi;
	
	bool serect = false;
	
	// Use this for initialization
	void Start () {
		Serect1 = GameObject.Find("Serect1");
		serect1 = Serect1.GetComponent<Serect1>();
		
		Charahyozi = GameObject.Find("Charahyozi");
		hyozi = Charahyozi.GetComponent<Charahyozi>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick1(){
	
		serect = serect1.serectOk;
		
		if(serect){
			hyozi.Hyozi(1);
		}
	}
	
	public void OnClick3(){
	
		serect = serect1.serectOk;
		
		if(serect){
			hyozi.Hyozi(3);
		}
	}
}
