using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Witch1Sc : MonoBehaviour {

	//ステータス
	public float hp = 10;
	float moveSpeed = 0.025f;
	
	//敵と戦闘しているか
	public bool move = true;
	
	//召喚エネルギー
	public int energy = 15;
	
	//ダメージUI
	public GameObject damageUI;

	void Start (){
	}
//----------------------------------------------------------------	
	// 毎フレームごと
	void Update () {
		if(move){
			if(transform.position.x < 0)
			transform.Translate(moveSpeed, 0, 0);
		}
		if(hp <= 0){
			Destroy(gameObject);
		}
	}
//------------------------------------------------------------------
	//ぶつかっているとき
	void OnTriggerStay2D(Collider2D other){
	}
	
	void OnTriggerExit2D(Collider2D other){
	}
	
	public void DamageUI(float damage){
		damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
		damageUIS.damage = damage;
		GameObject damageText = Instantiate(damageUI) as GameObject;
		damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
	}
}
