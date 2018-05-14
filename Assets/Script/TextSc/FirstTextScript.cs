using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTextScript : MonoBehaviour {
	
	float moveValue = -100f;
	public bool move = false;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(moveValue, 0, 0);
		if(move == false){
			//減速
			if(moveValue <= -0.001f){
				moveValue *= 0.87f;
			}
		}
		else{
			moveValue *= 1.3f;
		}
		if(transform.position.x <-1000){
			Destroy(gameObject);
		}
	}
}
