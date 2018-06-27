using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBtnController : MonoBehaviour {
	
	public bool selected = false;

    private Light sunLight;
    private GameObject cautionText;
    private Charahyozi charaHyozi;

    // Use this for initialization
    void Start () {
        //this.sunLight = GameObject.Find("Directional light").GetComponent<Light>();
        this.cautionText = GameObject.Find("CautionText");
        this.charaHyozi = GameObject.Find("Charahyozi").GetComponent<Charahyozi>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void OnClick(){
        this.cautionText.GetComponent<Text>().text = "";

        //this.sunLight.color = new Color(1, 1, 1, 1);
        this.charaHyozi.SetFalseToOtherSelectBtns(this.gameObject);
	}
}