using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supporter2Script : MonoBehaviour {

    private float time = 0;

    //ステータス(最大体力、現体力移動速度、召喚エネルギー、上昇ぱわー)
    public float MaxHp = 15;
    public float hp;
    private float _moveSpeed = 0.025f;
    public int Energy = 20;
    private float SupportPower = 5;

    //動く、止まる
    public bool move = true;

    //最新情報スクリプト
    private GameObject info;
    private LatestInfo info_sc;

    //シーン上のプレイヤー名と体力,最大hp
    private Dictionary<string, float> playHpDic = new Dictionary<string, float>();
    //シーン上のプレイヤー名と体力,最大hp
    private Dictionary<string, float> playMaxHpDic = new Dictionary<string, float>();

    //すでに能力を上昇させたプレイヤー名を保存
    private List<string> playList = new List<string>();

    //リストに名前があるかどうか　0なし1あり
    private int judge = 0;

    private GameObject _damageUI;

    void Start()
    {
        //最新情報スクリプト取得
        info = GameObject.Find("LatestInfo");
        info_sc = info.GetComponent<LatestInfo>();

        //名前とhpと最大hpを登録
        info_sc.RegplayHp(transform.name, MaxHp);
        info_sc.RegplayMaxHp(transform.name, MaxHp);
    }

    void Update()
    {
        //追加
        //体力と最大hpを更新
        playHpDic = info_sc.GetplayHp;
        this.hp = playHpDic[transform.name];
        playMaxHpDic = info_sc.GetplayMaxHp;
        this.MaxHp = playMaxHpDic[transform.name];

        time += Time.deltaTime;

        if (move)
        {
            if (transform.position.x < -3)
                transform.Translate(_moveSpeed, 0, 0);
        }

        //一秒ごとに新しいキャラがシーン上にいないか探す
        if (time >= 1)
        {
            time = 0;

            //playPowDicのキーのリストで処理を回す
            List<string> keyList = new List<string>(playMaxHpDic.Keys);

            foreach (string key in keyList)
            {
                //リストに何も入っていないとき
                if (playList.Count == 0)
                {
                    playMaxHpDic[key] += SupportPower;
                    Debug.Log(key + playMaxHpDic[key]);
                    //次に処理が行われないように
                    playList.Add(key);
                }
                else
                {
                    //リストに名前があるか
                    for (int i = 0; i < playList.Count; i++)
                    {
                        if (playList[i] == key)
                        {
                            judge = 1;
                            break;
                        }
                    }
                    //ないとき
                    if (judge == 0)
                    {
                        playMaxHpDic[key] += SupportPower;
                        Debug.Log(key + playMaxHpDic[key]);
                        playList.Add(key);
                    }
                    else
                        judge = 0;
                }
            }
            //更新したプレイヤー名と攻撃力を返す
            info_sc.SetplayMaxHp(playMaxHpDic);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
            //Dictionaryの消去
            info_sc.playHpDelete(transform.name);
            info_sc.playMaxHpDelete(transform.name);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Supporter")
        {
            move = false;
        }  
    }

    void OnTriggerExit2D(Collider2D other)
    {
        move = true;
    }
    public void DamageUI(float damage)
    {
        damageUIScript damageUIS = _damageUI.GetComponent<damageUIScript>();
        damageUIS.damage = damage;
        GameObject damageText = Instantiate(_damageUI) as GameObject;
        damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
    }
}
