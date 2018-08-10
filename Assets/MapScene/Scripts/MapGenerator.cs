using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;
using System;

public class MapGenerator : MonoBehaviour {

    // 人間界最終ステージの数
    private const double MaxStageNumHumanWorld = 8;

    public GameObject map1Prefab;
    public GameObject map2Prefab;
    public GameObject bonfireBtnPrefab;
    public GameObject flagBtnPrefab;
    public GameObject statusBtnPrefab;
    public GameObject settingBtnPrefab;
    public GameObject variables;
    public GameObject settingObject;

    private int mapNum;
    private GameObject mapPrefab = null;
    private Canvas canvas;

    // Use this for initialization
    void Start () {

        double stageNum;
        bool isSetBefore;
        int bgmNum;
        int seNum;
        int effectNum;
        int damageNum;
        this.canvas = GameObject.FindObjectOfType<Canvas>();

        //stageNum = 7;
        // ジョーカースクリプトから変数を受け取る。
        if (GlobalObject.getInstance().Params == null)
        {
            Debug.Log("ジョーカースクリプトから遷移");
            Debug.Log("StatusManager.variable.get(\"stage.number\") = " + StatusManager.variable.get("stage.number"));
            
            stageNum = GetNewStageNum(double.Parse(StatusManager.variable.get("stage.number")));

            isSetBefore = bool.Parse(StatusManager.variable.get("is.setBefore"));
            bgmNum = int.Parse((double.Parse(StatusManager.variable.get("bgm.number")) / 0.2).ToString());
            seNum = int.Parse((double.Parse(StatusManager.variable.get("se.number")) / 0.2).ToString());
            effectNum = int.Parse(StatusManager.variable.get("effect.number"));
            damageNum = int.Parse(StatusManager.variable.get("damage.number"));
        }
        else
        {
            Debug.Log("戦闘シーンかステータス画面、設定画面から遷移");

            string stageNumStr = (string)GlobalObject.getInstance().Params[0];

            SettingObject settingObjectFromOthers = (SettingObject)GlobalObject.getInstance().Params[1];
            isSetBefore = settingObjectFromOthers.IsSetBefore;
            bgmNum = settingObjectFromOthers.BgmNum;
            seNum = settingObjectFromOthers.SeNum;
            effectNum = settingObjectFromOthers.EffectNum;
            damageNum = settingObjectFromOthers.DamageNum;

            // 戦闘シーンからステージ番号を受け取る。
            if (double.TryParse(stageNumStr, out stageNum))
            {
                stageNum = GetNewStageNum(stageNum);
            }
            // ステータス画面か設定画面からステージ番号を受け取る。
            else
            {               
                stageNum = double.Parse(stageNumStr.Substring(0, stageNumStr.IndexOf(" ")));
            }
        }
        Debug.Log("stageNum = " + stageNum);

        // シーン間引き継ぎ変数の初期化（ジョーカースクリプトからの遷移かを判断するため）
        GlobalObject.getInstance().SetStringParam(null);
        GlobalObject.getInstance().SetParam(null);
        GlobalObject.getInstance().SetParams(null);

        // ステージ番号設定
        this.variables.GetComponent<Variables>().SetStageNum(stageNum);

        // 前回ユーザ設定の設定
        SetLastSettings(isSetBefore, bgmNum, seNum, effectNum, damageNum);

        // マップ画面決定（人間界or魔界）
        if (stageNum <= MaxStageNumHumanWorld)
        {
            this.mapNum = 1;
        }
        else
        {
            this.mapNum = 2;
        }

        // 人間界マップ
        if (this.mapNum == 1)
        {
            this.mapPrefab = this.map1Prefab;

            if (stageNum == 1)
            {
                GameObject bonfireBtnIns1 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns1.transform.position = new Vector3(-340, -180, 0);
                bonfireBtnIns1.transform.SetParent(this.canvas.transform, false);
            }
            else if(stageNum == 2)
            {
                GameObject bonfireBtnIns2 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns2.transform.position = new Vector3(-260.4f, -145.6f, 0);
                bonfireBtnIns2.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
            }
            else if (stageNum == 3)
            {
                GameObject bonfireBtnIns3 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns3.transform.position = new Vector3(-133, 0, 0);
                bonfireBtnIns3.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
                InstantiateFlag2();
            }
            else if (stageNum == 4)
            {
                GameObject bonfireBtnIns4 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns4.transform.position = new Vector3(-289.3f, 29, 0);
                bonfireBtnIns4.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
                InstantiateFlag2();
                InstantiateFlag3();
            }
            else if (stageNum == 5)
            {
                GameObject bonfireBtnIns5 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns5.transform.position = new Vector3(29, 145.6f, 0);
                bonfireBtnIns5.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
                InstantiateFlag2();
                InstantiateFlag3();
                InstantiateFlag4();
            }
            else if (stageNum == 6)
            {
                GameObject bonfireBtnIns6 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns6.transform.position = new Vector3(260.4f, -26.2f, 0);
                bonfireBtnIns6.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
                InstantiateFlag2();
                InstantiateFlag3();
                InstantiateFlag4();
                InstantiateFlag5();
            }
            else if (stageNum == 7)
            {
                GameObject bonfireBtnIns7 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns7.transform.position = new Vector3(231.5f, -145.6f, 0);
                bonfireBtnIns7.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
                InstantiateFlag2();
                InstantiateFlag3();
                InstantiateFlag4();
                InstantiateFlag5();
                InstantiateFlag6();
            }
            else if (stageNum == 8)
            {
                GameObject bonfireBtnIns8 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns8.transform.position = new Vector3(-34.7f, -203.9f, 0);
                bonfireBtnIns8.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag1();
                InstantiateFlag2();
                InstantiateFlag3();
                InstantiateFlag4();
                InstantiateFlag5();
                InstantiateFlag6();
                InstantiateFlag7();
            }            
        }

        // 魔界マップ
        else if (this.mapNum == 2)
        {
            this.mapPrefab = this.map2Prefab;

            if (stageNum == 9)
            {
                GameObject bonfireBtnIns9 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns9.transform.position = new Vector3(150, -133.9f, 0);
                bonfireBtnIns9.transform.SetParent(this.canvas.transform, false);
            }
            else if (stageNum == 10)
            {
                GameObject bonfireBtnIns10 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns10.transform.position = new Vector3(-50, -63.9f, 0);
                bonfireBtnIns10.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag9();
            }
            else if (stageNum == 11)
            {
                GameObject bonfireBtnIns11 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns11.transform.position = new Vector3(-460, 7.9f, 0);
                bonfireBtnIns11.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag9();
                InstantiateFlag10();
            }
            else if (stageNum == 12)
            {
                GameObject bonfireBtnIns12 = Instantiate(this.bonfireBtnPrefab) as GameObject;
                bonfireBtnIns12.transform.position = new Vector3(-210, 142.9f, 0);
                bonfireBtnIns12.transform.SetParent(this.canvas.transform, false);

                InstantiateFlag9();
                InstantiateFlag10();
                InstantiateFlag11();
            }            
        }

        GameObject mapInstance = Instantiate(this.mapPrefab) as GameObject;
        mapInstance.transform.position = new Vector3(0, 0, 0);

        GameObject statusBtnInstance = Instantiate(this.statusBtnPrefab) as GameObject;
        statusBtnInstance.transform.position = new Vector3(330, -135, 0);
        statusBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject settingBtnInstance = Instantiate(this.settingBtnPrefab) as GameObject;
        settingBtnInstance.transform.position = new Vector3(330, -195, 0);
        settingBtnInstance.transform.SetParent(this.canvas.transform, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 数値が小数点以下を含むかを判断する。
    /// </summary>
    /// <param name="doubleNum">数値</param>
    /// <returns>含む場合はtrue、整数ならfalse</returns>
    public static bool IsDecimal(double doubleNum)
    {
        if (doubleNum - Math.Floor(doubleNum) != 0) return true;

        return false;
    }

    /// <summary>
    /// ジョーカースクリプト後ストーリーからのステージ番号を
    /// 次の番号（整数）に変換して取得する。
    /// </summary>
    /// <param name="stageNum">ステージ番号</param>
    /// <returns>変換後のステージ番号</returns>
    private double GetNewStageNum(double stageNum)
    {
        if (stageNum == 0) stageNum++; 
        if (IsDecimal(stageNum)) stageNum += 0.5;

        return stageNum;
    }

    /// <summary>
    /// 前回の設定を反映する。
    /// </summary>
    /// <param name="isSetBefore">設定されたことがあるか</param>
    /// <param name="bgmNum">BGMの音量</param>
    /// <param name="seNum">効果音の音量</param>
    /// <param name="effectNum">エフェクト表示の有無</param>
    /// <param name="damageNum">ダメージ表示の有無</param>
    private void SetLastSettings(bool isSetBefore, int bgmNum, int seNum, int effectNum, int damageNum)
    {
        this.settingObject.GetComponent<SettingObject>().SetIsSetBefore(isSetBefore);
        this.settingObject.GetComponent<SettingObject>().SetBgmNum(bgmNum);
        this.settingObject.GetComponent<SettingObject>().SetSeNum(seNum);
        this.settingObject.GetComponent<SettingObject>().SetEffectNum(effectNum);
        this.settingObject.GetComponent<SettingObject>().SetDamageNum(damageNum);

        Debug.Log("MapGenerator - IsSetBefore = " + this.settingObject.GetComponent<SettingObject>().IsSetBefore);
        Debug.Log("MapGenerator - BgmNum = " + this.settingObject.GetComponent<SettingObject>().BgmNum);
        Debug.Log("MapGenerator - SeNum = " + this.settingObject.GetComponent<SettingObject>().SeNum);
        Debug.Log("MapGenerator - EffectNum = " + this.settingObject.GetComponent<SettingObject>().EffectNum);
        Debug.Log("MapGenerator - DamageNum = " + this.settingObject.GetComponent<SettingObject>().DamageNum);
    }

    private void InstantiateFlag1()
    {
        GameObject flagBtnIns1 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns1.transform.position = new Vector3(-463, -233, 0);
        flagBtnIns1.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag2()
    {
        GameObject flagBtnIns2 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns2.transform.position = new Vector3(-260.4f, -145.6f, 0);
        flagBtnIns2.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag3()
    {
        GameObject flagBtnIns3 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns3.transform.position = new Vector3(-133, 0, 0);
        flagBtnIns3.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag4()
    {
        GameObject flagBtnIns4 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns4.transform.position = new Vector3(-289.3f, 29, 0);
        flagBtnIns4.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag5()
    {
        GameObject flagBtnIns5 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns5.transform.position = new Vector3(29, 145.6f, 0);
        flagBtnIns5.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag6()
    {
        GameObject flagBtnIns6 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns6.transform.position = new Vector3(260.4f, -26.2f, 0);
        flagBtnIns6.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag7()
    {
        GameObject flagBtnIns7 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns7.transform.position = new Vector3(231.5f, -145.6f, 0);
        flagBtnIns7.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag8()
    {
        GameObject flagBtnIns8 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns8.transform.position = new Vector3(-34.7f, -203.9f, 0);
        flagBtnIns8.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag9()
    {
        GameObject flagBtnIns9 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns9.transform.position = new Vector3(150, -133.9f, 0);
        flagBtnIns9.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag10()
    {
        GameObject flagBtnIns10 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns10.transform.position = new Vector3(-50, -63.9f, 0);
        flagBtnIns10.transform.SetParent(this.canvas.transform, false);
    }

    private void InstantiateFlag11()
    {
        GameObject flagBtnIns11 = Instantiate(this.flagBtnPrefab) as GameObject;
        flagBtnIns11.transform.position = new Vector3(-460, 7.9f, 0);
        flagBtnIns11.transform.SetParent(this.canvas.transform, false);
    }
}
