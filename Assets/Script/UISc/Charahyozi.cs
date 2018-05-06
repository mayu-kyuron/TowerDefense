using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charahyozi : MonoBehaviour {
	
	public Sprite fighter1;
	public Sprite witch1;
	
	//int dankai = 0;
	
	public GameObject DirectionalLight;
	Light sunLight;
	
	GameObject Serect1;
	Serect1 serect1;
	
	public GameObject image1Obj;
	Image image1;
	
	// Use this for initialization
	void Start () {
		sunLight = DirectionalLight.GetComponent<Light>();
		
		Serect1 = GameObject.Find("Serect1");
		serect1 = Serect1.GetComponent<Serect1>();
		
		image1 = image1Obj.GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Hyozi(int handan){
		
		if(handan == 1){
			image1.sprite = fighter1;
		}
		else {
			image1.sprite = witch1;
		}
		
		sunLight.color = new Color(0, 0, 0, 1);
		
		serect1.serectOk = false;
	}
}
