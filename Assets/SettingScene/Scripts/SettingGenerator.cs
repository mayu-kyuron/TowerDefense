using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingGenerator : MonoBehaviour {

    public GameObject backBtnPrefab;
    public GameObject bgmTextPrefab;
    public GameObject soundBtn1Prefab;
    public GameObject soundBtn2Prefab;
    public GameObject soundBtn3Prefab;
    public GameObject soundBtn4Prefab;
    public GameObject soundBtn5Prefab;
    public GameObject seTextPrefab;
    public GameObject seBtn1Prefab;
    public GameObject seBtn2Prefab;
    public GameObject seBtn3Prefab;
    public GameObject seBtn4Prefab;
    public GameObject seBtn5Prefab;
    public GameObject effectTextPrefab;
    public GameObject effectBtn1Prefab;
    public GameObject effectBtn2Prefab;
    public GameObject damageTextPrefab;
    public GameObject damageBtn1Prefab;
    public GameObject damageBtn2Prefab;
    public GameObject variables;
    public GameObject settingObject;

    private GameObject soundPanel;
    private GameObject sePanel;
    private GameObject effectPanel;
    private GameObject damagePanel;

    // Use this for initialization
    void Start () {
        this.soundPanel = GameObject.Find("soundPanel");
        this.sePanel = GameObject.Find("sePanel");
        this.effectPanel = GameObject.Find("effectPanel");
        this.damagePanel = GameObject.Find("damagePanel");

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        //double stageNum = 9;
        double stageNum = double.Parse(GlobalObject.getInstance().Params[0].ToString());

        // 初期設定
        if ((object[])GlobalObject.getInstance().Params == null)
        {
            Debug.Log("(object[])GlobalObject.getInstance().Params == null");
            SetFirstSettings();
        }
        else
        {
            Debug.Log("(object)GlobalObject.getInstance().Params != null");
            SettingObject settingObject = (SettingObject)GlobalObject.getInstance().Params[1];

            if (settingObject.IsSetBefore)
            {
                Debug.Log("settingObject.IsSetBefore = true");
                SetLastSettings(settingObject);
            }
            else
            {
                Debug.Log("settingObject.IsSetBefore = false");
                SetFirstSettings();
            }
        }

        // ステージ番号設定
        this.variables.GetComponent<Variables>().SetStageNum(stageNum);

        // ボタン表示
        GameObject backBtnInstance = Instantiate(this.backBtnPrefab) as GameObject;
        backBtnInstance.transform.position = new Vector3(-340, 190, 0);
        backBtnInstance.transform.SetParent(canvas.transform, false);

        // BGM選択表示
        GameObject bgmTextInstance = Instantiate(this.bgmTextPrefab) as GameObject;
        bgmTextInstance.transform.position = new Vector3(-226, 100, 0);
        bgmTextInstance.transform.SetParent(canvas.transform, false);

        DisplayBgmSelection();

        // 効果音選択表示
        GameObject seTextInstance = Instantiate(this.seTextPrefab) as GameObject;
        seTextInstance.transform.position = new Vector3(-226, 10, 0);
        seTextInstance.transform.SetParent(canvas.transform, false);
        
        DisplaySeSelection();

        // エフェクト選択表示
        GameObject effectTextInstance = Instantiate(this.effectTextPrefab) as GameObject;
        effectTextInstance.transform.position = new Vector3(-226, -80, 0);
        effectTextInstance.transform.SetParent(canvas.transform, false);

        DisplayEffectSelection();

        // ダメージ選択表示
        GameObject damageTextInstance = Instantiate(this.damageTextPrefab) as GameObject;
        damageTextInstance.transform.position = new Vector3(-226, -170, 0);
        damageTextInstance.transform.SetParent(canvas.transform, false);

        DisplayDamageSelection();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 初期設定をする。
    /// </summary>
    private void SetFirstSettings()
    {
        this.settingObject.GetComponent<SettingObject>().SetIsSetBefore(true);
        this.settingObject.GetComponent<SettingObject>().SetBgmNum(3);
        this.settingObject.GetComponent<SettingObject>().SetSeNum(3);
        this.settingObject.GetComponent<SettingObject>().SetEffectNum(1);
        this.settingObject.GetComponent<SettingObject>().SetDamageNum(1);
    }

    /// <summary>
    /// 前回の設定を反映する。
    /// </summary>
    private void SetLastSettings(SettingObject settingObjectFromOthers)
    {
        this.settingObject.GetComponent<SettingObject>().SetBgmNum(settingObjectFromOthers.BgmNum);
        this.settingObject.GetComponent<SettingObject>().SetSeNum(settingObjectFromOthers.SeNum);
        this.settingObject.GetComponent<SettingObject>().SetEffectNum(settingObjectFromOthers.EffectNum);
        this.settingObject.GetComponent<SettingObject>().SetDamageNum(settingObjectFromOthers.DamageNum);
    }

    /// <summary>
    /// BGM音量の選択肢を表示する。
    /// </summary>
    private void DisplayBgmSelection()
    {
        GameObject soundBtn1Instance = Instantiate(this.soundBtn1Prefab) as GameObject;
        soundBtn1Instance.transform.position = new Vector3(-50, 80, 0);
        soundBtn1Instance.transform.SetParent(this.soundPanel.transform, false);
        soundBtn1Instance.GetComponent<Toggle>().group = this.soundPanel.GetComponent<ToggleGroup>();

        GameObject soundBtn2Instance = Instantiate(this.soundBtn2Prefab) as GameObject;
        soundBtn2Instance.transform.position = new Vector3(50, 80, 0);
        soundBtn2Instance.transform.SetParent(this.soundPanel.transform, false);
        soundBtn2Instance.GetComponent<Toggle>().group = this.soundPanel.GetComponent<ToggleGroup>();

        GameObject soundBtn3Instance = Instantiate(this.soundBtn3Prefab) as GameObject;
        soundBtn3Instance.transform.position = new Vector3(150, 80, 0);
        soundBtn3Instance.transform.SetParent(this.soundPanel.transform, false);
        soundBtn3Instance.GetComponent<Toggle>().group = this.soundPanel.GetComponent<ToggleGroup>();

        GameObject soundBtn4Instance = Instantiate(this.soundBtn4Prefab) as GameObject;
        soundBtn4Instance.transform.position = new Vector3(250, 80, 0);
        soundBtn4Instance.transform.SetParent(this.soundPanel.transform, false);
        soundBtn4Instance.GetComponent<Toggle>().group = this.soundPanel.GetComponent<ToggleGroup>();

        GameObject soundBtn5Instance = Instantiate(this.soundBtn5Prefab) as GameObject;
        soundBtn5Instance.transform.position = new Vector3(350, 80, 0);
        soundBtn5Instance.transform.SetParent(this.soundPanel.transform, false);
        soundBtn5Instance.GetComponent<Toggle>().group = this.soundPanel.GetComponent<ToggleGroup>();
    }

    /// <summary>
    /// 効果音音量の選択肢を表示する。
    /// </summary>
    private void DisplaySeSelection()
    {
        GameObject seBtn1Instance = Instantiate(this.seBtn1Prefab) as GameObject;
        seBtn1Instance.transform.position = new Vector3(-50, -7, 0);
        seBtn1Instance.transform.SetParent(this.sePanel.transform, false);
        seBtn1Instance.GetComponent<Toggle>().group = this.sePanel.GetComponent<ToggleGroup>();

        GameObject seBtn2Instance = Instantiate(this.seBtn2Prefab) as GameObject;
        seBtn2Instance.transform.position = new Vector3(50, -7, 0);
        seBtn2Instance.transform.SetParent(this.sePanel.transform, false);
        seBtn2Instance.GetComponent<Toggle>().group = this.sePanel.GetComponent<ToggleGroup>();

        GameObject seBtn3Instance = Instantiate(this.seBtn3Prefab) as GameObject;
        seBtn3Instance.transform.position = new Vector3(150, -7, 0);
        seBtn3Instance.transform.SetParent(this.sePanel.transform, false);
        seBtn3Instance.GetComponent<Toggle>().group = this.sePanel.GetComponent<ToggleGroup>();

        GameObject seBtn4Instance = Instantiate(this.seBtn4Prefab) as GameObject;
        seBtn4Instance.transform.position = new Vector3(250, -7, 0);
        seBtn4Instance.transform.SetParent(this.sePanel.transform, false);
        seBtn4Instance.GetComponent<Toggle>().group = this.sePanel.GetComponent<ToggleGroup>();

        GameObject seBtn5Instance = Instantiate(this.seBtn5Prefab) as GameObject;
        seBtn5Instance.transform.position = new Vector3(350, -7, 0);
        seBtn5Instance.transform.SetParent(this.sePanel.transform, false);
        seBtn5Instance.GetComponent<Toggle>().group = this.sePanel.GetComponent<ToggleGroup>();
    }

    /// <summary>
    /// エフェクト表示の選択肢を表示する。
    /// </summary>
    private void DisplayEffectSelection()
    {
        GameObject effectBtn1Instance = Instantiate(this.effectBtn1Prefab) as GameObject;
        effectBtn1Instance.transform.position = new Vector3(0, -95, 0);
        effectBtn1Instance.transform.SetParent(this.effectPanel.transform, false);
        effectBtn1Instance.GetComponent<Toggle>().group = this.effectPanel.GetComponent<ToggleGroup>();

        GameObject effectBtn2Instance = Instantiate(this.effectBtn2Prefab) as GameObject;
        effectBtn2Instance.transform.position = new Vector3(240, -95, 0);
        effectBtn2Instance.transform.SetParent(this.effectPanel.transform, false);
        effectBtn2Instance.GetComponent<Toggle>().group = this.effectPanel.GetComponent<ToggleGroup>();
    }

    /// <summary>
    /// ダメージ表示の選択肢を表示する。
    /// </summary>
    private void DisplayDamageSelection()
    {
        GameObject damageBtn1Instance = Instantiate(this.damageBtn1Prefab) as GameObject;
        damageBtn1Instance.transform.position = new Vector3(0, -184, 0);
        damageBtn1Instance.transform.SetParent(this.damagePanel.transform, false);
        damageBtn1Instance.GetComponent<Toggle>().group = this.damagePanel.GetComponent<ToggleGroup>();

        GameObject damageBtn2Instance = Instantiate(this.damageBtn2Prefab) as GameObject;
        damageBtn2Instance.transform.position = new Vector3(240, -184, 0);
        damageBtn2Instance.transform.SetParent(this.damagePanel.transform, false);
        damageBtn2Instance.GetComponent<Toggle>().group = this.damagePanel.GetComponent<ToggleGroup>();
    }
}
