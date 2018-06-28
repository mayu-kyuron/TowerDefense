using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter1Script : Token {
	
	//ステータス
	public float hp = 30;
	public float power = 10;
	float moveSpeed = 0.05f;
	private float attackTime = 4.0f;
	public int energy = 10;
	
	private float time = 0;
	
	//敵のスクリプト
	SuraimuScript slimeSc;
	GaitherSc gaitherS;
	
	//フラッグ
	bool enemy = false;
	bool move = true;
	bool List = false;
	bool decrease = true;
		
	//モンスター
	GameObject monster;

    //ダメージUI
    public GameObject damageUI;
	
	int monsterType = 0;

    //追加
    //シーン上のプレイヤー名と最新攻撃力と体力
    private Dictionary<string, float> playPowDic = new Dictionary<string, float>();
    private Dictionary<string, float> playHpDic = new Dictionary<string, float>();

    //最新情報スクリプト
    private GameObject info;
    private LatestInfo info_sc;

    void Start (){
        //追加
        //最新情報スクリプト取得
        info = GameObject.Find("LatestInfo");
        info_sc = info.GetComponent<LatestInfo>();

        //名前と攻撃力、体力を登録
        info_sc.RegplayPow(transform.name, power);
        info_sc.RegplayHp(transform.name, hp);

    }
    //----------------------------------------------------------------	
    // 毎フレームごと
    void Update () {
        //追加
        //攻撃力、体力を更新
        playPowDic = info_sc.GetplayPow;
        this.power = playPowDic[transform.name];
        playHpDic = info_sc.GetplayHp;
        this.hp = playHpDic[transform.name];

        if (move){
			if(transform.position.x < 0)
			transform.Translate(moveSpeed, 0, 0);
		}
		if(enemy){
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
		if(hp <= 0){
			Destroy(gameObject);

            //追加
            //Dictionaryの消去
            info_sc.playPowDelete(transform.name);
            info_sc.playHpDelete(transform.name);
        }
	}
//------------------------------------------------------------------
	//ぶつかっているとき
	void OnTriggerStay2D(Collider2D other){
		
		if(enemy == false){
			if(other.gameObject.tag == "Suraimu"){
				enemy = true;
				move = false;
				monster = GameObject.Find("Suraimu(Clone)");
				slimeSc = monster.GetComponent<SuraimuScript>();
				monsterType = 1;
			}
			else if(other.gameObject.tag == "Gaither"){
				enemy = true;
				move = false;
				monster = GameObject.Find("Gaither(Clone)");
				gaitherS = monster.GetComponent<GaitherSc>();
				monsterType = 2;
			}
		}
	}
//---------------------------------------------------------------------
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
