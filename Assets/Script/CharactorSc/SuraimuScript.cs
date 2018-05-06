using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuraimuScript : Token {
	
	//ステータス
	public float hp = 30;
	public float power = 10.0f;
	float moveSpeed = -0.03f;
	private float attackTime = 5.0f;
	
	private float time = 0;

	//フラッグ
	bool move = true;
	bool enemy = false;

	int playerType = 0;
	
	GameObject player;
	GameObject ship;
	GameObject generator;

	Fighter1Script F1Sc;
	Witch1Sc W1Sc;
	ShipSc shipSc;
	GeneratorScript generatorSc;
	
	public GameObject damageUI;
//---------------------------------------------------------
	void Start () {
		ship = GameObject.Find("Ship");
		shipSc = ship.GetComponent<ShipSc>();
		generator = GameObject.Find("Generator");
		generatorSc = generator.GetComponent<GeneratorScript>();
	}
//----------------------------------------------------------
	void Update () {
		if(move)
			transform.Translate(moveSpeed, 0, 0);
		if(enemy){
			time += Time.deltaTime;
			if(time >= attackTime){
				time = 0;
				if(playerType == 1){
					F1Sc.hp -= power;
					//Debug.Log("ファイター" + F1Sc.hp);
					F1Sc.DamageUI(power);
				}
				else if(playerType == 4){
					W1Sc.hp -= power;
					//Debug.Log("ウィッチ" + W1Sc.hp);
					W1Sc.DamageUI(power);
				}
				else if(playerType == 3){
					shipSc.hp -= power;
					shipSc.DamageUI(power);
				}
			}
		}
		if(hp <= 0){
			generatorSc.Count();
			Destroy(gameObject);
		}
	}
//----------------------------------------------------------------
	void OnTriggerStay2D(Collider2D other){
		
		if(enemy == false){
			if(other.gameObject.tag == "Fighter1"){
				move = false;
				enemy = true;
				player = GameObject.Find("Fighter1(Clone)");
				F1Sc = player.GetComponent<Fighter1Script>();
				playerType = 1;
			}
			else if(other.gameObject.tag == "Witch1"){
				enemy = true;
				move = false;
				player = GameObject.Find("Witch1(Clone)");
				W1Sc = player.GetComponent<Witch1Sc>();
				playerType = 4;
			}
			else if(other.gameObject.tag == "Ship"){
				move = false;
				enemy = true;
				playerType = 3;
			}
		}
	}
//----------------------------------------------------------------
	void OnTriggerExit2D(Collider2D other){
		enemy = false;
		move = true;
	}
	
	public void DamageUI(float damage){
		damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
		damageUIS.damage = damage;
		GameObject damageText = Instantiate(damageUI) as GameObject;
		damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
	}
}
