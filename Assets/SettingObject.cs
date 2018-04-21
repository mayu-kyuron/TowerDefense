using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingObject : MonoBehaviour {

    // 設定されたことがあるか
    // false：設定されたことなし、true：設定されたことあり
    private bool isSetBefore;

    // BGMの音量
    // 1:最小(0.2)、2:やや小(0.4)、3:普通(0.6)、4:やや大(0.8)、5:最大(1)
    private int bgmNum;

    // 効果音の音量
    // 1:最小(0.2)、2:やや小(0.4)、3:普通(0.6)、4:やや大(0.8)、5:最大(1)
    private int seNum;

    // エフェクト表示の有無
    // 0:なし、1:あり
    private int effectNum;

    // ダメージ表示の有無
    // 0:なし、1:あり
    private int damageNum;

    /// <summary>
    /// 設定されたことがあるかを取得する。
    /// </summary>
    public bool IsSetBefore
    {
        get { return this.isSetBefore; }
    }

    /// <summary>
    /// 設定されたことがあるかを設定する。
    /// </summary>
    /// <param name="isSetBefore"></param>
    public void SetIsSetBefore(bool isSetBefore)
    {
        this.isSetBefore = isSetBefore;
    }

    /// <summary>
    /// BGMの音量を取得する。
    /// </summary>
    public int BgmNum
    {
        get { return this.bgmNum; }
    }

    /// <summary>
    /// BGMの音量を設定する。
    /// </summary>
    /// <param name="bgmNum"></param>
    public void SetBgmNum(int bgmNum)
    {
        this.bgmNum = bgmNum;
    }

    /// <summary>
    /// 効果音の音量を取得する。
    /// </summary>
    public int SeNum
    {
        get { return this.seNum; }
    }

    /// <summary>
    /// 効果音の音量を設定する。
    /// </summary>
    /// <param name="seNum"></param>
    public void SetSeNum(int seNum)
    {
        this.seNum = seNum;
    }

    /// <summary>
    /// エフェクト表示の有無を取得する。
    /// </summary>
    public int EffectNum
    {
        get { return this.effectNum; }
    }

    /// <summary>
    /// エフェクト表示の有無を設定する。
    /// </summary>
    /// <param name="effectNum"></param>
    public void SetEffectNum(int effectNum)
    {
        this.effectNum = effectNum;
    }

    /// <summary>
    /// ダメージ表示の有無を取得する。
    /// </summary>
    public int DamageNum
    {
        get { return this.damageNum; }
    }

    /// <summary>
    /// ダメージ表示の有無を設定する。
    /// </summary>
    /// <param name="damageNum"></param>
    public void SetDamageNum(int damageNum)
    {
        this.damageNum = damageNum;
    }
}
