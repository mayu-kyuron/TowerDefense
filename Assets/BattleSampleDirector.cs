using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;
using System;

public class BattleSampleDirector : MonoBehaviour {

    // 全ステージ数
    private const double AllStageNum = 12;
    // マップ前にジョーカースクリプト（後ストーリー）に飛ぶステージ
    private readonly double[] StageNumsPlusHalf = { 2, 3, 4, 6, 8, 10 };

    public GameObject settingObject;

    // Use this for initialization
    void Start () {

        // ジョーカースクリプト（前ストーリー）から変数を受け取る
        double stageNum = double.Parse(StatusManager.variable.get("stage.number"));
        bool isSetBefore = bool.Parse(StatusManager.variable.get("is.setBefore"));
        int bgmNum = int.Parse((double.Parse(StatusManager.variable.get("bgm.number")) / 0.2).ToString());
        int seNum = int.Parse((double.Parse(StatusManager.variable.get("se.number")) / 0.2).ToString());
        int effectNum = int.Parse(StatusManager.variable.get("effect.number"));
        int damageNum = int.Parse(StatusManager.variable.get("damage.number"));

        Debug.Log("BattleSampleDirector - isSetBefore = " + isSetBefore);
        Debug.Log("BattleSampleDirector - bgmNum = " + bgmNum);
        Debug.Log("BattleSampleDirector - seNum = " + seNum);
        Debug.Log("BattleSampleDirector - effectNum = " + effectNum);
        Debug.Log("BattleSampleDirector - damageNum = " + damageNum);

        // 後ストーリーのあるものはジョーカースクリプトへ
        if (Array.IndexOf(StageNumsPlusHalf, stageNum) >= 0)
        {
            stageNum += 0.5;

            SetVariablesAndCallJoker(stageNum, isSetBefore, bgmNum, seNum, effectNum, damageNum);
        }
        // 最終ステージだったらエンディングへ
        else if (stageNum == AllStageNum)
        {
            stageNum = -1;

            SetVariablesAndCallJoker(stageNum, isSetBefore, bgmNum, seNum, effectNum, damageNum);
        }
        // それ以外はマップへ
        else
        {
            stageNum++;

            SetVariablesAndLoadMap(stageNum, isSetBefore, bgmNum, seNum, effectNum, damageNum);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 変数を設定してジョーカースクリプトに遷移する。
    /// </summary>
    /// <param name="stageNum">ステージ番号</param>
    /// <param name="isSetBefore">設定されたことがあるか</param>
    /// <param name="bgmNum">BGMの音量</param>
    /// <param name="seNum">効果音の音量</param>
    /// <param name="effectNum">エフェクト表示の有無</param>
    /// <param name="damageNum">ダメージ表示の有無</param>
    private void SetVariablesAndCallJoker(
        double stageNum, bool isSetBefore, int bgmNum, int seNum, int effectNum, int damageNum)
    {
        StatusManager.variable.set("stage.number", stageNum.ToString());
        StatusManager.variable.set("is.setBefore", isSetBefore.ToString());
        StatusManager.variable.set("bgm.number", bgmNum.ToString());
        StatusManager.variable.set("se.number", seNum.ToString());
        StatusManager.variable.set("effect.number", effectNum.ToString());
        StatusManager.variable.set("damage.number", damageNum.ToString());

        NovelSingleton.StatusManager.callJoker("wide/material", "");
    }

    /// <summary>
    /// 変数を設定してマップ画面に遷移する。
    /// </summary>
    /// <param name="stageNum">ステージ番号</param>
    /// <param name="isSetBefore">設定されたことがあるか</param>
    /// <param name="bgmNum">BGMの音量</param>
    /// <param name="seNum">効果音の音量</param>
    /// <param name="effectNum">エフェクト表示の有無</param>
    /// <param name="damageNum">ダメージ表示の有無</param>
    private void SetVariablesAndLoadMap(
        double stageNum, bool isSetBefore, int bgmNum, int seNum, int effectNum, int damageNum)
    {
        this.settingObject.GetComponent<SettingObject>().SetIsSetBefore(isSetBefore);
        this.settingObject.GetComponent<SettingObject>().SetBgmNum(bgmNum);
        this.settingObject.GetComponent<SettingObject>().SetSeNum(seNum);
        this.settingObject.GetComponent<SettingObject>().SetEffectNum(effectNum);
        this.settingObject.GetComponent<SettingObject>().SetDamageNum(damageNum);

        GlobalObject.LoadLevelWithParams("Map", stageNum.ToString(),
            this.settingObject.GetComponent<SettingObject>());
    }
}