using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaitherAttackScript : MonoBehaviour {

	float power = 5.0f;
	private float attackTime = 3.0f;
	
	private float time = 0;
	
	int playerType = 0;
	
	bool enemy = false;
	
	GaitherSc gaitherS;
	Fighter1Script F1S;
	Witch1Sc W1S;
	ShipSc shipSc;
	
	GameObject parentGaither;
	GameObject player;
	GameObject ship;
	
	// Use this for initialization
	void Start () {
		ship = GameObject.Find("Ship");
		shipSc = ship.GetComponent<ShipSc>();
		parentGaither = transform.root.gameObject;
		gaitherS = parentGaither.GetComponent<GaitherSc>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemy){
			time += Time.deltaTime;
			if(time >= attackTime){
				time = 0;
				if(playerType == 1){
					F1S.hp -= power;
					//Debug.Log("ファイター" + F1S.hp);
					F1S.DamageUI(power);
				} 
				else if(playerType == 4){
					W1S.hp -= power;
					//Debug.Log("ウィッチ" + W1S.hp);
					W1S.DamageUI(power);
				}
				else if(playerType == 3){
					shipSc.hp -= power;
					shipSc.DamageUI(power);
				}
			}
		}
	}
	void OnTriggerStay2D(Collider2D other){
		
		if(enemy == false){
			if(other.gameObject.tag == "Fighter1"){
				enemy = true;
				gaitherS.move = false;
				player = GameObject.Find("Fighter1(Clone)");
				F1S = player.GetComponent<Fighter1Script>();
				playerType = 1;
			}
			else if(other.gameObject.tag == "Witch1"){
				enemy = true;
				gaitherS.move = false;
				player = GameObject.Find("Witch1(Clone)");
				W1S = player.GetComponent<Witch1Sc>();
				playerType = 4;
			}
			else if(other.gameObject.tag == "Ship"){
				enemy = true;
				gaitherS.move = false;
				playerType = 3;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other){
		enemy = false;
		gaitherS.move = true;
	}
}
