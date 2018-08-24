using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBtnController : MonoBehaviour {
	
	public bool selected = false;

    private Light sunLight;
    private GameObject cautionText;
    private Charahyozi charaHyozi;
	private AudioSource audioSource;
	
	void Start () {
        //this.sunLight = GameObject.Find("Directional light").GetComponent<Light>();
        this.cautionText = GameObject.Find("CautionText");
        this.charaHyozi = GameObject.Find("Charahyozi").GetComponent<Charahyozi>();
		this.audioSource = this.gameObject.GetComponent<AudioSource>();

		int seNum = this.charaHyozi.GetComponent<Charahyozi>().settingObject.GetComponent<SettingObject>().SeNum;
		this.audioSource.volume = seNum * 0.2f;
	}
	
	void Update () {
	}
	
	public void OnClick(){
		this.audioSource.PlayOneShot(this.audioSource.clip);

		this.cautionText.GetComponent<Text>().text = "";

        //this.sunLight.color = new Color(1, 1, 1, 1);
        this.charaHyozi.SetFalseToOtherSelectBtns(this.gameObject);
	}
}