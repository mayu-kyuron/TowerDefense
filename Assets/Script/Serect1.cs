using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serect1 : MonoBehaviour {
	
	public GameObject DirectionalLight;
	Light sunLight;
	public bool serectOk = false;
	
	// Use this for initialization
	void Start () {
		
		sunLight = DirectionalLight.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void OnClick(){
		sunLight.color = new Color(1, 1, 1, 1);
		serectOk = true;
	}
}
