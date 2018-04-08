using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter1Script : Token {
	
	//HP
	int hp = 50;
	//敵の攻撃速度の時間
	float time = 1.0f;
	//敵のスクリプト
	SuraimuScript suraimuScript;
	//敵の攻撃力
	int power;
	//フラッグ
	bool enemyFlag = false;
	bool move = true;
	//モンスター
	GameObject monster;
	
	//召喚エネルギー
	public int energy = 10;
	
	//はじめ
	void Start (){
	}
	
	// 毎フレームごと
	void Update () {
		if(move)
			transform.Translate(0.05f, 0, 0);
		if(enemyFlag){
			time -= Time.deltaTime;
			if(time <= 0.0f){
				hp -= this.power;
				Debug.Log(hp);
				time = 1.0f;
			}
			if(hp <= 0){
				suraimuScript.Flag();
				Destroy(gameObject);
			}
		}
	}
	
	//ぶつかったとき
	void OnTriggerEnter2D(Collider2D other){

		//速度をゼロに
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//敵のフラッグオン
		enemyFlag = true;
		move = false;
		
		if(other.gameObject.tag == "Suraimu"){
			this.monster = GameObject.Find("Suraimu");
			suraimuScript = monster.GetComponent<SuraimuScript>();
			power = suraimuScript.sDamage(power);
		}
	}
}
