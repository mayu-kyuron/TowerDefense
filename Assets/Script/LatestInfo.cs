using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatestInfo : MonoBehaviour {

    //シーン上の
    //モンスター名と最新hp
    private Dictionary<string, float> monsHpDic = new Dictionary<string, float>();
    //プレイヤー名と最新攻撃力
    private Dictionary<string, float> playPowDic = new Dictionary<string, float>();
    //プレイヤー名と最新hp
    private Dictionary<string, float> playHpDic = new Dictionary<string, float>();

    //追加
    //プレイヤー名と最新最大hp
    private Dictionary<string, float> playMaxHpDic = new Dictionary<string, float>();

    void Update() {
    }

    //モンスター名とhpーーーーーーーーーーーー
    //モンスターたちの最新hpをセットで取得する。
    public Dictionary<string, float> GetmonsHp
    {
        get { return this.monsHpDic; }
    }

    //モンスターたちの最新hpをセットで設定する。
    public void SetmonsHp(Dictionary<string, float> a)
    {
        monsHpDic = a;
    }

    //モンスター名とhpを登録する
    public void Regmons(string name, float hp)
    {
        monsHpDic.Add(name, hp);
    }

    //死んだモンスターをmonsHpDicから消去
    public void Delete(string name)
    {
        monsHpDic.Remove(name);
    }

    //プレイヤー名と攻撃力ーーーーーーーーーーーーーーーー
    //シーン上のプレイヤー名と攻撃力を取得
    public Dictionary<string, float> GetplayPow
    {
        get { return this.playPowDic; }
    }

    //シーン上のプレイヤー名と最新攻撃力をセット
    public void SetplayPow(Dictionary<string, float> b)
    {
        monsHpDic = b;
    }

    //プレイヤー名と攻撃力の登録
    public void RegplayPow(string name, float power)
    {
        playPowDic.Add(name, power);
    }

    //死んだプレイヤーをplayPowDicから消去
    public void playPowDelete(string name)
    {
        playPowDic.Remove(name);
    }

    //プレイヤー名と体力ーーーーーーーーーーーーーーーー
    //シーン上のプレイヤー名と体力を取得
    public Dictionary<string, float> GetplayHp
    {
        get { return this.playHpDic; }
    }

    //シーン上のプレイヤー名と最新攻撃力をセット
    public void SetplayHp(Dictionary<string, float> b)
    {
        playHpDic = b;
    }

    //プレイヤー名と攻撃力の登録
    public void RegplayHp(string name, float hp)
    {
        playHpDic.Add(name, hp);
    }

    //死んだプレイヤーをplayHpDicから消去
    public void playHpDelete(string name)
    {
        playHpDic.Remove(name);
    }

    //追加
    //プレイヤー名と最大hpーーーーーーーーーーーーーーーー
    //シーン上のプレイヤー名と最大hpを取得
    public Dictionary<string, float> GetplayMaxHp
    {
        get { return this.playMaxHpDic; }
    }

    //シーン上のプレイヤー名と最新攻撃力をセット
    public void SetplayMaxHp(Dictionary<string, float> b)
    {
        playMaxHpDic = b;
    }

    //プレイヤー名と攻撃力の登録
    public void RegplayMaxHp(string name, float hp)
    {
        playMaxHpDic.Add(name, hp);
    }

    //死んだプレイヤーをplayHpDicから消去
    public void playMaxHpDelete(string name)
    {
        playMaxHpDic.Remove(name);
    }
}
