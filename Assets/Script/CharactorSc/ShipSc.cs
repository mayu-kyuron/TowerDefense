using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSc : MonoBehaviour {

	public float hp = 150.0f;
	public GameObject damageUI;
	Slider slider;
	
	// Use this for initialization
	void Start () {
		slider = GameObject.Find("HPgage").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(hp <= 0){
			SceneManager.LoadScene("GameOver");
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
	}
	
	public void DamageUI(float damage){
		damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
		damageUIS.damage = damage;
		GameObject damageText = Instantiate(damageUI) as GameObject;
		damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
		slider.value = hp;
	}
}
