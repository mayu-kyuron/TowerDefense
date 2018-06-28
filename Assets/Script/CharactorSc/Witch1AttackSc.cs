using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch1AttackSc : MonoBehaviour {
	
	//ステータス
	public float power = 10.0f;
	private float attackTime = 4.0f;
	
	private float time = 0;
	
	bool enemy = false;
	
	Witch1Sc witch1Sc;
	
	GameObject parentWitch1;

	GameObject monster;
	
	int monsterType = 0;
	
	//敵のスクリプト
	SuraimuScript slimeSc;
	GaitherSc gaitherS;

    //追加ーーーーーーーーーーーーーーーーーーーーーー
    //最新情報スクリプト
    private GameObject info;
    private LatestInfo info_sc;

    //シーン上のプレイヤー名と最新攻撃力と体力
    private Dictionary<string, float> playPowDic = new Dictionary<string, float>();

    void Start (){
		parentWitch1 = transform.root.gameObject;
		witch1Sc = parentWitch1.GetComponent<Witch1Sc>();

        //追加
        //最新情報スクリプト取得
        info = GameObject.Find("LatestInfo");
        info_sc = info.GetComponent<LatestInfo>();

        //名前と攻撃力、体力を登録
        info_sc.RegplayPow(parentWitch1.name, power);
    }

    void Update () {

        //追加
        //攻撃力を更新
        playPowDic = info_sc.GetplayPow;
        this.power = playPowDic[parentWitch1.name];

        if (enemy){
			time += Time.deltaTime;
			if(time >= attackTime){
				time = 0;
				if(monsterType == 1){
					slimeSc.hp -= power;
					//Debug.Log("スライム" + slimeSc.hp);
					slimeSc.DamageUI(power);
				} 
				else if(monsterType == 2){
					gaitherS.hp -= power;
					//Debug.Log("ゲイザー" + gaitherS.hp);
					gaitherS.DamageUI(power);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		
		if(enemy == false){
			if(other.gameObject.tag == "Suraimu"){
				enemy = true;
				witch1Sc.move = false;
				monster = GameObject.Find("Suraimu(Clone)");
				slimeSc = monster.GetComponent<SuraimuScript>();
				monsterType = 1;
			}
			else if(other.gameObject.tag == "Gaither"){
				enemy = true;
				witch1Sc.move = false;
				monster = GameObject.Find("Gaither(Clone)");
				gaitherS = monster.GetComponent<GaitherSc>();
				monsterType = 2;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		enemy = false;
		witch1Sc.move = true;
	}
}
