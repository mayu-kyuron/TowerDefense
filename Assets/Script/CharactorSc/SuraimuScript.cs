using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuraimuScript : Token {
	
	//ステータス
	public float hp = 60;
	public float power = 10.0f;
	float moveSpeed = -0.03f;
	private float attackTime = 5.0f;
	
	private float time1 = 0;
    private float time2 = 0;
    public float enemyPower = 0;
    public float enemyAttackTime = 0;

	//フラッグ
	bool move = true;
	bool enemy = false;
    public bool enemyWitch2 = false;

	int playerType = 0;
	
	GameObject player;
	GameObject ship;
	GameObject generator;

	Fighter1Script F1Sc;
	Witch1Sc W1Sc;
    Witch2Script W2Sc;
	ShipSc shipSc;
	GeneratorScript generatorSc;
	
	public GameObject damageUI;

    //追加----------------------------------------------------------------------------------
    //最新情報の取得宣言
    private GameObject info;
    private LatestInfo info_sc;

    //名前の宣言
    private string myName;

    //シーン上のモンスターの名前とhpを保存
    private Dictionary<string, float> monsHpDic = new Dictionary<string, float>();

    void Start () {
        //ship = GameObject.Find("Ship");
        //shipSc = ship.GetComponent<ShipSc>();
        //generator = GameObject.Find("Generator");
        //generatorSc = generator.GetComponent<GeneratorScript>();

        //追加------------------------------------------------------------------------------
        //シーンの名前をmyNameへ
        myName = transform.name;

        //最新情報のスクリプト取得
        info = GameObject.Find("LatestInfo");
        info_sc = info.GetComponent<LatestInfo>();
        info_sc.Regmons(myName, hp);
    }

	void Update () {
		if(move)
			transform.Translate(moveSpeed, 0, 0);
        if (enemyWitch2)
        {
            time1 += Time.deltaTime;
            if (time1 >= enemyAttackTime)
            {
                time1 = 0;
                hp -= enemyPower;
                DamageUI(enemyPower);
            }
        }
        if (enemy){
			
            time2 += Time.deltaTime;
            
			if(time2 >= attackTime){
				time2 = 0;
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
                else if (playerType == 5)
                {
                    W2Sc.hp -= power;
                    //Debug.Log("ウィッチ" + W1Sc.hp);
                    W2Sc.DamageUI(power);
                }
                else if(playerType == 3){
					shipSc.hp -= power;
					shipSc.Damage(power);
				}
			}
		}

        //追加----------------------------------------------------------------------
        //最新の情報を取得
        monsHpDic = info_sc.GetmonsHp;

        //自分のhpを更新
        hp = monsHpDic[myName];
        //----------------------------------------------------------------------
        if (hp <= 0){
			//generatorSc.Count();
			Destroy(gameObject);

            //追加-------------------------------------------------------------------
            //Dictionaryの消去
            info_sc.Delete(myName);
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
            else if (other.gameObject.tag == "Witch2"){
                enemy = true;
                move = false;
                player = GameObject.Find("Witch2");
                W2Sc = player.GetComponent<Witch2Script>();
                playerType = 5;
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
