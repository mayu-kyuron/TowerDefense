using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;

public class BonfireController : MonoBehaviour {

    private GameObject mapGenerator;

    // Use this for initialization
    void Start () {
        this.mapGenerator = GameObject.Find("MapGenerator");
    }
	
	// Update is called once per frame
	void Update () {

	}

    // クリックされたらジョーカースクリプトへ
    private void OnClick()
    {
        // ステージ番号取得
        string stageNum = this.mapGenerator.GetComponent<MapGenerator>()
            .variables.GetComponent<Variables>().StageNum.ToString();

        // 設定オブジェクトのフィールド取得
        GameObject settingObject = this.mapGenerator.GetComponent<MapGenerator>().settingObject;
        string isSetBefore = settingObject.GetComponent<SettingObject>().IsSetBefore.ToString();
        string bgmNum = settingObject.GetComponent<SettingObject>().BgmNum.ToString();
        string seNum = settingObject.GetComponent<SettingObject>().SeNum.ToString();
        string effectNum = settingObject.GetComponent<SettingObject>().EffectNum.ToString();
        string damageNum = settingObject.GetComponent<SettingObject>().DamageNum.ToString();

        Debug.Log("BonfireController - isSetBefore = " + isSetBefore);
        Debug.Log("BonfireController - bgmNum = " + bgmNum);
        Debug.Log("BonfireController - seNum = " + seNum);
        Debug.Log("BonfireController - effectNum = " + effectNum);
        Debug.Log("BonfireController - damageNum = " + damageNum);

        // ジョーカースクリプトに渡す値を設定
        StatusManager.variable.set("stage.number", stageNum);
        StatusManager.variable.set("is.setBefore", isSetBefore);
        StatusManager.variable.set("bgm.number", bgmNum);
        StatusManager.variable.set("se.number", seNum);
        StatusManager.variable.set("effect.number", effectNum);
        StatusManager.variable.set("damage.number", damageNum);

        // シーン遷移
        NovelSingleton.StatusManager.callJoker("wide/material", "");
    }
}
