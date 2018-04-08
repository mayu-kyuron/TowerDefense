using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraimuScript : Token {
	
	//移動速度
	public float speed = 1.0f;
	
	//辺り判定
	Rigidbody2D rigid2D;
	
	//攻撃力
	public int power = 10;
	
	//敵と戦闘しているか
	bool enemyF = true;
	
//---------------------------------------------------------
	void Start () {
		this.rigid2D = GetComponent<Rigidbody2D>();
		SetVelocity(180, speed);
	}
//----------------------------------------------------------
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
	}
	
	void OnTriggerStay2D(Collider2D other){
		this.rigid2D.velocity = Vector2.zero;
	}
	void OnTriggerExit2D(Collider2D other){
		SetVelocity(180, speed);
	}
	
	public void Flag(){
		enemyF = false;
	}
	public int sDamage(int power){
		if(enemyF){
			power = this.power;
			enemyF = false;
		}
		else{
			power = 0;
		}
		return power;
	}
}
