using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaitherSc : MonoBehaviour {

	public float hp = 40;
	float moveSpeed = -0.025f;
	
	Fighter1Script fighter1S;
	Witch1Sc witch1S;
	GeneratorScript generatorSc;
	
	bool enemy = false;
	public bool move = true;
	
	GameObject player;
	public GameObject damageUI;
	GameObject generator;

    //追加----------------------------------------------------------------------------------
    //最新情報の取得宣言
    private GameObject info;
    private LatestInfo info_sc;

    //名前の宣言
    private string myName;

    //シーン上のモンスターの名前とhpを保存
    private Dictionary<string, float> monsHpDic = new Dictionary<string, float>();

    // Use this for initialization
    void Start () {
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
	
	// Update is called once per frame
	void Update () {
		if(move)
			transform.Translate(moveSpeed, 0, 0);

        //追加----------------------------------------------------------------------
        //最新の情報を取得
        monsHpDic = info_sc.GetmonsHp;

        //自分のhpを更新
        hp = monsHpDic[myName];
        //--------------------------------------------------------------------------
        if (hp <= 0){
			//generatorSc.Count();
			Destroy(gameObject);

            //追加---------------------------------------------------------------------
            //Dictionaryの消去
            info_sc.Delete(myName);
        }


    }
	public void DamageUI(float damage){
		damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
		damageUIS.damage = damage;
		GameObject damageText = Instantiate(damageUI) as GameObject;
		damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
	}
}
