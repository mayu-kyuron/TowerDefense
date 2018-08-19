using Novel;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 選択画面のジェネレータ
/// </summary>
public class Charahyozi : MonoBehaviour {

    public static int EmptyImageCount = 5;

    public Sprite fighterASprite;
    public Sprite fighterBSprite;
    public Sprite witchASprite;
    public Sprite witchBSprite;
    public Sprite healerASprite;
    public Sprite healerBSprite;
    public Sprite healerCSprite;
    public Sprite supporterASprite;
    public Sprite supporterBSprite;
    public Sprite emptySprite;
    public Dictionary<int, Sprite> spriteNumMap;

    public GameObject directionalLight;
    public GameObject charaBtnPrefab;
    public GameObject clearBtnPrefab;
    public GameObject selectBtnPrefab;
    public GameObject emptyImgPrefab;
    public GameObject cautionText;
	public GameObject variables;
	public GameObject settingObject;

	public bool selectedAnyChara = false;
    public UnityEngine.UI.Image[] emptyImages = new UnityEngine.UI.Image[EmptyImageCount];
	public Dictionary<int, int> stageNumAllCharaNumMap;

	private Light sunLight;
    private Sprite[] sprites;
    private SelectBtnController[] selectBtnControllers = new SelectBtnController[EmptyImageCount];

	private void Awake() {

		// ジョーカースクリプト（前ストーリー）から変数を受け取る
		//double stageNum = 1;
		double stageNum = double.Parse(StatusManager.variable.get("stage.number"));
		bool isSetBefore = bool.Parse(StatusManager.variable.get("is.setBefore"));
		int bgmNum = int.Parse((double.Parse(StatusManager.variable.get("bgm.number")) / 0.2).ToString());
		int seNum = int.Parse((double.Parse(StatusManager.variable.get("se.number")) / 0.2).ToString());
		int effectNum = int.Parse(StatusManager.variable.get("effect.number"));
		int damageNum = int.Parse(StatusManager.variable.get("damage.number"));

		Debug.Log("Charahyozi - stageNum = " + stageNum);

		// ステージ番号設定
		this.variables.GetComponent<Variables>().SetStageNum(stageNum);

		// 前回ユーザ設定の設定
		SetLastSettings(isSetBefore, bgmNum, seNum, effectNum, damageNum);

		this.stageNumAllCharaNumMap = new Dictionary<int, int> {
			{ 1, 3 }, { 2, 3 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 6, 8 },
			{ 7, 8 }, { 8, 8 }, { 9, 9 }, { 10, 9 }, { 11, 9 }, { 12, 9 },
		};
	}

	void Start () {
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
		//this.sunLight = directionalLight.GetComponent<Light>();

		double stageNum = this.variables.GetComponent<Variables>().StageNum;

		this.sprites = new Sprite[] { fighterASprite, fighterBSprite,
            witchASprite, witchBSprite, healerASprite, healerBSprite, healerCSprite,
            supporterASprite, supporterBSprite };

		this.spriteNumMap = new Dictionary<int, Sprite> {
			{ CharaMonsterNoConst.FighterANo, this.sprites[0] },
			{ CharaMonsterNoConst.FighterBNo, this.sprites[1] },
			{ CharaMonsterNoConst.WitchANo, this.sprites[2] },
			{ CharaMonsterNoConst.WitchBNo, this.sprites[3] },
			{ CharaMonsterNoConst.HealerANo, this.sprites[4] },
			{ CharaMonsterNoConst.HealerBNo, this.sprites[5] },
			{ CharaMonsterNoConst.HealerCNo, this.sprites[6] },
			{ CharaMonsterNoConst.SupporterANo, this.sprites[7] },
			{ CharaMonsterNoConst.SupporterBNo, this.sprites[8] },
		};

		// キャラクターボタン表示
		GameObject charaBtnInstance1;
		GameObject charaBtnInstance2;
		GameObject charaBtnInstance3;
		GameObject charaBtnInstance4;
		GameObject charaBtnInstance5;
		GameObject charaBtnInstance6;
		GameObject charaBtnInstance7;
		GameObject charaBtnInstance8;
		GameObject charaBtnInstance9;

		charaBtnInstance1 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance1.transform.position = new Vector3(230, 182, 0);
        charaBtnInstance1.GetComponent<UnityEngine.UI.Image>().sprite = this.fighterASprite;
        charaBtnInstance1.transform.SetParent(canvas.transform, false);
        charaBtnInstance1.name = "charaBtnInstance1";

		if (stageNum >= 4) {
			charaBtnInstance5 = Instantiate(this.charaBtnPrefab) as GameObject;
			charaBtnInstance5.transform.position = new Vector3(285, 182, 0);
			charaBtnInstance5.GetComponent<UnityEngine.UI.Image>().sprite = this.fighterBSprite;
			charaBtnInstance5.transform.SetParent(canvas.transform, false);
			charaBtnInstance5.name = "charaBtnInstance5";
		}

        charaBtnInstance2 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance2.transform.position = new Vector3(230, 130, 0);
        charaBtnInstance2.GetComponent<UnityEngine.UI.Image>().sprite = this.witchASprite;
        charaBtnInstance2.transform.SetParent(canvas.transform, false);
        charaBtnInstance2.name = "charaBtnInstance2";

		if (stageNum >= 6) {
			charaBtnInstance7 = Instantiate(this.charaBtnPrefab) as GameObject;
			charaBtnInstance7.transform.position = new Vector3(285, 130, 0);
			charaBtnInstance7.GetComponent<UnityEngine.UI.Image>().sprite = this.witchBSprite;
			charaBtnInstance7.transform.SetParent(canvas.transform, false);
			charaBtnInstance7.name = "charaBtnInstance7";
		}

		if (stageNum >= 3) {
			charaBtnInstance4 = Instantiate(this.charaBtnPrefab) as GameObject;
			charaBtnInstance4.transform.position = new Vector3(230, 78, 0);
			charaBtnInstance4.GetComponent<UnityEngine.UI.Image>().sprite = this.healerASprite;
			charaBtnInstance4.transform.SetParent(canvas.transform, false);
			charaBtnInstance4.name = "charaBtnInstance4";
		}

		if (stageNum >= 6) {
			charaBtnInstance8 = Instantiate(this.charaBtnPrefab) as GameObject;
			charaBtnInstance8.transform.position = new Vector3(285, 78, 0);
			charaBtnInstance8.GetComponent<UnityEngine.UI.Image>().sprite = this.healerBSprite;
			charaBtnInstance8.transform.SetParent(canvas.transform, false);
			charaBtnInstance8.name = "charaBtnInstance8";
		}

		if (stageNum >= 9) {
			charaBtnInstance9 = Instantiate(this.charaBtnPrefab) as GameObject;
			charaBtnInstance9.transform.position = new Vector3(340, 78, 0);
			charaBtnInstance9.GetComponent<UnityEngine.UI.Image>().sprite = this.healerCSprite;
			charaBtnInstance9.transform.SetParent(canvas.transform, false);
			charaBtnInstance9.name = "charaBtnInstance9";
		}

        charaBtnInstance3 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance3.transform.position = new Vector3(230, 26, 0);
        charaBtnInstance3.GetComponent<UnityEngine.UI.Image>().sprite = this.supporterASprite;
        charaBtnInstance3.transform.SetParent(canvas.transform, false);
        charaBtnInstance3.name = "charaBtnInstance3";

		if (stageNum >= 5) {
			charaBtnInstance6 = Instantiate(this.charaBtnPrefab) as GameObject;
			charaBtnInstance6.transform.position = new Vector3(285, 26, 0);
			charaBtnInstance6.GetComponent<UnityEngine.UI.Image>().sprite = this.supporterBSprite;
			charaBtnInstance6.transform.SetParent(canvas.transform, false);
			charaBtnInstance6.name = "charaBtnInstance6";
		}

        GameObject charaBtnInstance10 = Instantiate(this.clearBtnPrefab) as GameObject;
        charaBtnInstance10.transform.position = new Vector3(250, -26, 0);
        charaBtnInstance10.transform.SetParent(canvas.transform, false);
        charaBtnInstance10.name = "charaBtnInstance10";

        var charaBtnControllers = new CharaBtnController[this.stageNumAllCharaNumMap[(int)stageNum] + 1];
        for (int i = 0; i < charaBtnControllers.Length; i++) {

            var instanceName = String.Format("charaBtnInstance{0}", i + 1);
			if (i == this.stageNumAllCharaNumMap[(int)stageNum]) instanceName = "charaBtnInstance10";

            charaBtnControllers[i] = GameObject.Find(instanceName).GetComponent<CharaBtnController>();
        }

        // 選択ボタン表示
        GameObject selectBtnInstance1 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance1.transform.position = new Vector3(-300, -177, 0);
        selectBtnInstance1.transform.SetParent(canvas.transform, false);
        selectBtnInstance1.name = "selectBtnInstance1";

        GameObject selectBtnInstance2 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance2.transform.position = new Vector3(-197.5f, -177, 0);
        selectBtnInstance2.transform.SetParent(canvas.transform, false);
        selectBtnInstance2.name = "selectBtnInstance2";

        GameObject selectBtnInstance3 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance3.transform.position = new Vector3(-95, -177, 0);
        selectBtnInstance3.transform.SetParent(canvas.transform, false);
        selectBtnInstance3.name = "selectBtnInstance3";

        GameObject selectBtnInstance4 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance4.transform.position = new Vector3(7.5f, -177, 0);
        selectBtnInstance4.transform.SetParent(canvas.transform, false);
        selectBtnInstance4.name = "selectBtnInstance4";

        GameObject selectBtnInstance5 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance5.transform.position = new Vector3(110, -177, 0);
        selectBtnInstance5.transform.SetParent(canvas.transform, false);
        selectBtnInstance5.name = "selectBtnInstance5";

        for (int i = 0; i < this.selectBtnControllers.Length; i++) {
            var instanceName = String.Format("selectBtnInstance{0}", i + 1);
            this.selectBtnControllers[i] = GameObject.Find(instanceName).GetComponent<SelectBtnController>();
        }

        foreach (CharaBtnController charaBtnController in charaBtnControllers) {
            charaBtnController.SetSelectBtnControllers();
        }

        // 選択キャラ表示用の空イメージ表示
        GameObject emptyImgInstance1 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance1.transform.position = new Vector3(-300, -62, 0);
        emptyImgInstance1.transform.SetParent(canvas.transform, false);
        emptyImgInstance1.name = "emptyImgInstance1";

        GameObject emptyImgInstance2 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance2.transform.position = new Vector3(-197.5f, -62, 0);
        emptyImgInstance2.transform.SetParent(canvas.transform, false);
        emptyImgInstance2.name = "emptyImgInstance2";

        GameObject emptyImgInstance3 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance3.transform.position = new Vector3(-95, -62, 0);
        emptyImgInstance3.transform.SetParent(canvas.transform, false);
        emptyImgInstance3.name = "emptyImgInstance3";

        GameObject emptyImgInstance4 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance4.transform.position = new Vector3(7.5f, -62, 0);
        emptyImgInstance4.transform.SetParent(canvas.transform, false);
        emptyImgInstance4.name = "emptyImgInstance4";

        GameObject emptyImgInstance5 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance5.transform.position = new Vector3(110, -62, 0);
        emptyImgInstance5.transform.SetParent(canvas.transform, false);
        emptyImgInstance5.name = "emptyImgInstance5";

        for (int i = 0; i < EmptyImageCount; i++) {
            var instanceName = String.Format("emptyImgInstance{0}", i + 1);
            this.emptyImages[i] = GameObject.Find(instanceName).GetComponent<UnityEngine.UI.Image>();
        }
    }
	
	void Update () {
		
	}

	/// <summary>
	/// 前回の設定を反映する。
	/// </summary>
	/// <param name="isSetBefore">設定されたことがあるか</param>
	/// <param name="bgmNum">BGMの音量</param>
	/// <param name="seNum">効果音の音量</param>
	/// <param name="effectNum">エフェクト表示の有無</param>
	/// <param name="damageNum">ダメージ表示の有無</param>
	private void SetLastSettings(bool isSetBefore, int bgmNum, int seNum, int effectNum, int damageNum) {
		this.settingObject.GetComponent<SettingObject>().SetIsSetBefore(isSetBefore);
		this.settingObject.GetComponent<SettingObject>().SetBgmNum(bgmNum);
		this.settingObject.GetComponent<SettingObject>().SetSeNum(seNum);
		this.settingObject.GetComponent<SettingObject>().SetEffectNum(effectNum);
		this.settingObject.GetComponent<SettingObject>().SetDamageNum(damageNum);

		Debug.Log("Charahyozi - IsSetBefore = " + this.settingObject.GetComponent<SettingObject>().IsSetBefore);
		Debug.Log("Charahyozi - BgmNum = " + this.settingObject.GetComponent<SettingObject>().BgmNum);
		Debug.Log("Charahyozi - SeNum = " + this.settingObject.GetComponent<SettingObject>().SeNum);
		Debug.Log("Charahyozi - EffectNum = " + this.settingObject.GetComponent<SettingObject>().EffectNum);
		Debug.Log("Charahyozi - DamageNum = " + this.settingObject.GetComponent<SettingObject>().DamageNum);
	}

	/// <summary>
	/// 選択されたボタン以外の真偽値をfalseに設定する。
	/// </summary>
	/// <param name="selectBtnInstance">選択されたボタン</param>
	public void SetFalseToOtherSelectBtns(GameObject selectBtnInstance) {

        foreach (SelectBtnController selectBtnController in this.selectBtnControllers) {
            selectBtnController.selected = false;
        }

        selectBtnInstance.GetComponent<SelectBtnController>().selected = true;
    }
	
    /// <summary>
    /// キャラクターを選択キャラ表示欄に表示する。
    /// </summary>
    /// <param name="charaNum">キャラクター番号</param>
	public void DisplayCharaAtSelectedArea(int charaNum) {
		double stageNum = this.variables.GetComponent<Variables>().StageNum;

		if (charaNum != CharaMonsterNoConst.NoneNo) this.selectedAnyChara = true;

        bool[] selectedBtns = new bool[EmptyImageCount];
        for (int i = 0; i < selectedBtns.Length; i++) {
            selectedBtns[i] = this.selectBtnControllers[i].GetComponent<SelectBtnController>().selected;
        }

        // 選択されたボタンを特定
        for (int i = 0; i < selectedBtns.Length; i++) {

            if (selectedBtns[i]) {

                var emptySpriteList = new List<Sprite>();
                foreach (UnityEngine.UI.Image image in emptyImages) {
                    emptySpriteList.Add(image.sprite);
                }

                if (charaNum != CharaMonsterNoConst.NoneNo && emptySpriteList.Contains(this.spriteNumMap[charaNum])) {
                    this.cautionText.GetComponent<Text>().text = "同じキャラクターは選択できません！";
                }
                // 重複のないキャラクターボタンが選択された場合
                else {
                    if (charaNum == CharaMonsterNoConst.NoneNo) {
                        this.emptyImages[i].sprite = emptySprite;
                    }
                    else {
                        this.emptyImages[i].sprite = this.spriteNumMap[charaNum];
                    }
                }

                selectedBtns[i] = false;
            }
        }
		
		//this.sunLight.color = new Color(0, 0, 0, 1);
	}

	/// <summary>
	/// 変数を設定して戦闘画面に遷移する。
	/// </summary>
	public void SetVariablesAndLoadBattleTemp(List<int> charaNoList) {
		double stageNum = this.variables.GetComponent<Variables>().StageNum;

		GlobalObject.LoadLevelWithParams("BattleTemp",
			stageNum.ToString(), this.settingObject.GetComponent<SettingObject>(), charaNoList);
	}
}