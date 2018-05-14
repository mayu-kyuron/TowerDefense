using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healer1Sc : MonoBehaviour {

	public int energy = 15;
	public float hp = 10;
	float moveSpeed = 0.015f;
	public bool move = true;
	public GameObject damageUI;

	void Start (){
	}

	void Update () {
		if(move){
			if(transform.position.x < 0)
			transform.Translate(moveSpeed, 0, 0);
		}
		if(hp <= 0){
			Destroy(gameObject);
		}
	}
	
	public void DamageUI(float damage){
		damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
		damageUIS.damage = damage;
		GameObject damageText = Instantiate(damageUI) as GameObject;
		damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
	}
}
