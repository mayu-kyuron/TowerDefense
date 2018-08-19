using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusGenerator : MonoBehaviour {

    public GameObject backBtnPrefab;
    public GameObject fighterBtnPrefab;
    public GameObject witchBtnPrefab;
    public GameObject healerBtnPrefab;
    public GameObject guardianBtnPrefab;
    public GameObject supporterBtnPrefab;
    public GameObject monsterBtnPrefab;
    public GameObject charaPrefab;
    public GameObject explanationPrefab;
    public GameObject statusPrefab;
    public GameObject leftArrowBtnPrefab;
    public GameObject rightArrowBtnPrefab;
    public GameObject pageNumPrefab;
    public GameObject variables;
    public GameObject settingObject;

    private Canvas canvas;

    // Use this for initialization
    void Start () {

        this.canvas = GameObject.FindObjectOfType<Canvas>();
        //double stageNum = 9;
		double stageNum = double.Parse(GlobalObject.getInstance().Params[0].ToString());

		// ステージ番号の設定
		this.variables.GetComponent<Variables>().SetStageNum(stageNum);

        // 前回ユーザ設定の設定
        if ((object[])GlobalObject.getInstance().Params != null
            && (object)GlobalObject.getInstance().Params[1] != null)
        {
            SetLastSettings();
        }

        // ボタン表示
        GameObject[] btnInstances = DisplayButtons();
        GameObject guardianBtnInstance = btnInstances[0];
        GameObject supporterBtnInstance = btnInstances[1];
        GameObject monsterBtnInstance = btnInstances[2];

        // キャラクター表示
        GameObject charaInstance = Instantiate(this.charaPrefab) as GameObject;
        charaInstance.transform.position = new Vector3(-120, 10, 0);
        charaInstance.transform.SetParent(this.canvas.transform, false);

        // 説明ウィンドウ表示
        GameObject explanationInstance = Instantiate(this.explanationPrefab) as GameObject;
        explanationInstance.transform.position = new Vector3(210, 120, 0);
        explanationInstance.transform.SetParent(this.canvas.transform, false);

        // ステータスウィンドウ表示
        GameObject statusInstance = Instantiate(this.statusPrefab) as GameObject;
        statusInstance.transform.position = new Vector3(195, -102, 0);
        statusInstance.transform.SetParent(this.canvas.transform, false);

        // ページ番号表示
        GameObject pageNumInstance = Instantiate(this.pageNumPrefab) as GameObject;
        pageNumInstance.transform.position = new Vector3(223, -197.5f, 0);
        pageNumInstance.transform.SetParent(this.canvas.transform, false);

        // 初期設定（ファイターAのステータスを表示）
        SetFirstCharacter();

        if (stageNum == 1)
        {
            guardianBtnInstance.GetComponent<Button>().interactable = false;
            supporterBtnInstance.GetComponent<Button>().interactable = false;
            monsterBtnInstance.GetComponent<Button>().interactable = false;

            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (stageNum == 2)
        {
            guardianBtnInstance.GetComponent<Button>().interactable = false;
            supporterBtnInstance.GetComponent<Button>().interactable = false;

            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (stageNum == 3)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (stageNum == 4)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (stageNum == 5)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (stageNum == 6)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (stageNum == 7)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (stageNum == 8)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (stageNum == 9)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (stageNum == 10)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All3peoplePageText1;

        }
        else if (stageNum == 11)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
        else if (stageNum == 12)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 前回の設定を反映する。
    /// </summary>
    private void SetLastSettings()
    {
        SettingObject settingObjectFromOthers = (SettingObject)GlobalObject.getInstance().Params[1];
        this.settingObject.GetComponent<SettingObject>().SetIsSetBefore(settingObjectFromOthers.IsSetBefore);
        this.settingObject.GetComponent<SettingObject>().SetBgmNum(settingObjectFromOthers.BgmNum);
        this.settingObject.GetComponent<SettingObject>().SetSeNum(settingObjectFromOthers.SeNum);
        this.settingObject.GetComponent<SettingObject>().SetEffectNum(settingObjectFromOthers.EffectNum);
        this.settingObject.GetComponent<SettingObject>().SetDamageNum(settingObjectFromOthers.DamageNum);
    }

    /// <summary>
    /// ボタンを表示する。
    /// </summary>
    /// <returns>ボタンインスタンスの配列（ガーディアン、サポーター、モンスター）</returns>
    private GameObject[] DisplayButtons()
    {
        GameObject backBtnInstance = Instantiate(this.backBtnPrefab) as GameObject;
        backBtnInstance.transform.position = new Vector3(-340, 190, 0);
        backBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject fighterBtnInstance = Instantiate(this.fighterBtnPrefab) as GameObject;
        fighterBtnInstance.transform.position = new Vector3(-330, 120, 0);
        fighterBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject witchBtnInstance = Instantiate(this.witchBtnPrefab) as GameObject;
        witchBtnInstance.transform.position = new Vector3(-330, 60, 0);
        witchBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject healerBtnInstance = Instantiate(this.healerBtnPrefab) as GameObject;
        healerBtnInstance.transform.position = new Vector3(-330, 0, 0);
        healerBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject guardianBtnInstance = Instantiate(this.guardianBtnPrefab) as GameObject;
        guardianBtnInstance.transform.position = new Vector3(-330, -60, 0);
        guardianBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject supporterBtnInstance = Instantiate(this.supporterBtnPrefab) as GameObject;
        supporterBtnInstance.transform.position = new Vector3(-330, -120, 0);
        supporterBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject monsterBtnInstance = Instantiate(this.monsterBtnPrefab) as GameObject;
        monsterBtnInstance.transform.position = new Vector3(-330, -180, 0);
        monsterBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject leftArrowBtnInstance = Instantiate(this.leftArrowBtnPrefab) as GameObject;
        leftArrowBtnInstance.transform.position = new Vector3(63.6f, -190, 0);
        leftArrowBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject rightArrowBtnInstance = Instantiate(this.rightArrowBtnPrefab) as GameObject;
        rightArrowBtnInstance.transform.position = new Vector3(325, -190, 0);
        rightArrowBtnInstance.transform.SetParent(this.canvas.transform, false);

        return new GameObject[] { guardianBtnInstance, supporterBtnInstance, monsterBtnInstance };
    }

    /// <summary>
    /// 初期設定（ファイターAを設定）する。
    /// </summary>
    private void SetFirstCharacter()
    {
        this.variables.GetComponent<Variables>().SetJudgeCharaTypeNum(1);
        this.variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.canvas.gameObject.transform.FindChild("explanationPrefab(Clone)")
            .gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterAExp;
        this.canvas.gameObject.transform.FindChild("statusPrefab(Clone)")
            .gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterAStatus;
        this.canvas.gameObject.transform.FindChild("statusPrefab(Clone)")
            .gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.FighterAStatus2;
    }
}
