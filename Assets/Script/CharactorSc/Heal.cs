using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {
	
	float time = 0;
	float healTime = 2.0f;
	bool healFlag = false;
	GameObject player;
	Healer1Sc healer1Script;
	
	void Start (){
		GameObject parent = transform.root.gameObject;
		healer1Script = parent.GetComponent<Healer1Sc>();
		
	}
	
	void Update (){
		if(healFlag){
			time = Time.deltaTime;
			if(time >= healTime){
			}
		}
	}		
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Fighter1"){
			 healer1Script.move = false;
			 healFlag = true;
		}
	}
}
