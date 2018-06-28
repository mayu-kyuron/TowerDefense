using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch2AttackScript : MonoBehaviour {

    //ステータス(攻撃力、攻撃頻度)
    public float power = 10.0f;
    private float attackTime = 3.0f;

    private float time = 0;

    //Witch本体の宣言
    GameObject parentWitch2;
    Witch2Script W2Sc;

    //最新情報の宣言
    private GameObject info;
    private LatestInfo info_sc;
    private Dictionary<string, float> monsHpDic = new Dictionary<string, float>();
    private Dictionary<string, float> playPowDic = new Dictionary<string, float>();

    //敵と戦闘しているかいるかのフラッグ
    bool enemy = false;

    //攻撃対象モンスターの名前保存場所宣言
    private List<string> monsList = new List<string>();

    void Start()
    {
        parentWitch2 = transform.root.gameObject;
        W2Sc = parentWitch2.GetComponent<Witch2Script>();

        info = GameObject.Find("LatestInfo");
        info_sc = info.GetComponent<LatestInfo>();

        //名前と攻撃力を登録
        info_sc.RegplayPow(parentWitch2.name, power);
    }

    void Update()
    {
        //常にモンスターのhp最新情報を取得
        monsHpDic = info_sc.GetmonsHp;

        //攻撃力を更新
        playPowDic = info_sc.GetplayPow;
        this.power = playPowDic[parentWitch2.name];

        if (enemy)
        {
            time += Time.deltaTime; 
            if(time >= attackTime)
            {
                for(int a = 0; a < monsList.Count; a++)
                {
                    Debug.Log(monsList[a]);
                }
                time = 0;

                //キーのリストで処理を回す
                List<string> keyList = new List<string>(monsHpDic.Keys);

                foreach (string key in keyList)
                {
                    for(int i = 0; i < monsList.Count; i++)
                    {
                        if (monsList[i] == key) {
                            monsHpDic[key] -= power;
                            break;
                        }
                    }
                }
                info_sc.SetmonsHp(monsHpDic);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //攻撃対象のモンスター名を登録
        monsList.Add(other.name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //レイヤー名の取得
        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        if (layerName == "monster")
        {
            W2Sc.move = false;
            enemy = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //動く
        W2Sc.move = true;

        //敵なし
        enemy = false;

        //攻撃対象モンスター名の消去
        monsList.Remove(other.name);
    }
}
