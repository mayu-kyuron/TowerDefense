using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour {

	public bool flag = false;
	bool button = false;
	
	GameObject child;
	
	float time = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(button){
			time += Time.deltaTime;
			if(time >= 2.0f){
				flag = true;
				Destroy(gameObject);
			}
		}
	}
	public void FirstButton(){
		button = true;
		child = transform.FindChild("Text").gameObject;
		FirstTextScript firstTextS = child.GetComponent<FirstTextScript>();
		firstTextS.move = true;
	}
}
