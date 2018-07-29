using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Witch2Script : MonoBehaviour {

    //ステータス(hpと移動速度)
    private float MaxHp = 15;
    public float hp;
    private float moveSpeed = 0.025f;

    //動けるかのフラッグ
    public bool move = true;

    //召喚エネルギー
    public int energy = 15;

    //ダメージUI
    public GameObject damageUI;

    //追加------------------------------------
    //最新情報スクリプト
    private GameObject info;
    private LatestInfo info_sc;

    //シーン上のプレイヤー名と体力
    private Dictionary<string, float> playHpDic = new Dictionary<string, float>();
    private Dictionary<string, float> playMaxHpDic = new Dictionary<string, float>();

    void Start()
    {
        //追加
        //最新情報スクリプト取得
        info = GameObject.Find("LatestInfo");
        info_sc = info.GetComponent<LatestInfo>();

        //名前と体力を登録
        info_sc.RegplayHp(transform.name, MaxHp);
        info_sc.RegplayMaxHp(transform.name, MaxHp);
    }
    //----------------------------------------------------------------	
    // 毎フレームごと
    void Update()
    {
        //追加
        //体力を更新
        playHpDic = info_sc.GetplayHp;
        this.hp = playHpDic[transform.name];
        playMaxHpDic = info_sc.GetplayMaxHp;
        this.MaxHp = playMaxHpDic[transform.name];

        //動き
        if (move)
        {
            if (transform.position.x < 0)
                transform.Translate(moveSpeed, 0, 0);
        }

        //死亡処理
        if (hp <= 0)
        {
            Destroy(gameObject);
            //Dictionaryの消去
            info_sc.playPowDelete(transform.name);
            info_sc.playHpDelete(transform.name);
            info_sc.playMaxHpDelete(transform.name);
        }
    }

    //ダメージの視覚化
    public void DamageUI(float damage)
    {
        damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
        damageUIS.damage = damage;
        GameObject damageText = Instantiate(damageUI) as GameObject;
        damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
    }
}

