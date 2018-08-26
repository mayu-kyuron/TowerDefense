﻿using Novel;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 仮バトルシーンのジェネレーター
/// →そのまま本番用として利用することに。
/// </summary>
public class BattleTempGenerator : MonoBehaviour {

	// 全ステージ数
	private const double AllStageNum = 12;
	// マップ前にジョーカースクリプト（後ストーリー）に飛ぶステージ
	private readonly double[] StageNumsPlusHalf = { 2, 3, 4, 6, 8, 10 };
	// クリアの文字がフェードインする速さ
	private const float SpeedClearFadein = 1.5f;

	// キャラのプレファブ
	public GameObject fighter1Pre;
	public GameObject fighter2Pre;
    public GameObject fighter3Pre;
    public GameObject witch1Pre;
	public GameObject witch2Pre;
	public GameObject healer1Pre;
	//public GameObject healer2Pre;
	public GameObject healer3Pre;
	public GameObject supporter1Pre;
	public GameObject supporter2Pre;

	// モンスターのプレファブ
	public GameObject slimePre;
	public GameObject gaitherPre;
	public GameObject slimeRedPre;
	public GameObject gaitherWhitePre;
	public GameObject zonbieWhitePre;
	public GameObject zonbieGreenPre;
	public GameObject goblinGreenPre;
	public GameObject goblinBlackPre;
	public GameObject yetiWhitePre;
	public GameObject yetiGreenPre;
	public GameObject ifreetRedPre;
	public GameObject ifreetGreenPre;
	public GameObject centaurBrownPre;
	public GameObject centaurBlackPre;
	public GameObject unicornWhitePre;
	public GameObject unicornBlackPre;
	public GameObject ogreOrangePre;
	public GameObject ogreGreenPre;
	public GameObject chimeraPurplePre;
	public GameObject chimeraRedPre;
	public GameObject fairyYerrowPre;
	public GameObject fairyPurplePre;
	public GameObject carbunclePre;
	public GameObject golemPre;
	public GameObject alraunePre;
    public GameObject bossSlimePre;
    public GameObject bossHealerPre;

    public GameObject backImgPrefab;
	public GameObject summonBtnPrefab;
    public GameObject variables;
	public GameObject settingObject;
	public GameObject hiddenClearImageUI;

	// キャラの画像
	public Sprite fighterASprite;
	public Sprite fighterBSprite;
    public Sprite fighterCSprite;
    public Sprite witchASprite;
	public Sprite witchBSprite;
	public Sprite healerASprite;
	//public Sprite healerBSprite;
	public Sprite healerCSprite;
	public Sprite supporterASprite;
	public Sprite supporterBSprite;

	// ステージごとの背景画像
	public Sprite stage1Back;
	public Sprite stage2Back;
	public Sprite stage3Back;
	public Sprite stage4Back;
	public Sprite stage5Back;
	public Sprite stage6Back;
	public Sprite stage7Back;
	public Sprite stage8Back;
	public Sprite stage9Back;
	public Sprite stage10Back;
	public Sprite stage11Back;
	public Sprite stage12Back;

    //ステージごとのBGM
    public AudioClip stage1BGM;
    public AudioClip stage2BGM;
    public AudioClip stage3BGM;
    public AudioClip stage4BGM;
    public AudioClip stage5BGM;
    public AudioClip stage6BGM;
    public AudioClip stage7BGM;
    public AudioClip stage8BGM;
    public AudioClip stage9BGM;
    public AudioClip stage10BGM;
    public AudioClip stage11BGM;
    public AudioClip stage12BGM;

    private Canvas canvas;
	private CurrentStatusVariables currentStatusVariables;
	private StageEnemyInfo stageEnemyInfo = new StageEnemyInfo();
	private UnityEngine.UI.Image hiddenClearImage;
	private Text clearText;
	private float time = 0;
	private float clearness = 0.0f;
	private int monsterNum = 0;
    private int deadMonsterNum = 0;
	private Dictionary<int, int> charaNoMap = new Dictionary<int, int>();
	private Dictionary<int, int> monsterNoMap = new Dictionary<int, int>();
	private Dictionary<int, List<int>> monsterMap;
	private Dictionary<int, double> paceMap;
	private Dictionary<int, MonsterObject> monsterPrefabMap;
	private Dictionary<int, Sprite> stageBackgroundMap;
	private Dictionary<int, Sprite> charaNoSpriteMap;
    private Dictionary<int, AudioClip> stageBGMMap;
    public AudioSource audioSource;

	private void Awake() {
		//double stageNum = 6;
		double stageNum = double.Parse(GlobalObject.getInstance().Params[0].ToString());

		// ステージ番号の設定
		this.variables.GetComponent<Variables>().SetStageNum(stageNum);
	}

	void Start () {
		this.canvas = GameObject.FindObjectOfType<Canvas>();
		this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();
		this.hiddenClearImage = this.hiddenClearImageUI.GetComponent<UnityEngine.UI.Image>();
		this.clearText = this.hiddenClearImageUI.GetComponentInChildren<Text>();
        this.audioSource = gameObject.GetComponent<AudioSource>();

		double stageNum = this.variables.GetComponent<Variables>().StageNum;
		var charaNoList = (List<int>)GlobalObject.getInstance().Params[2];
		//var charaNoList = new List<int> {
		//	1, 2, 3, 5, 8
		//};

		// 背景の設定
		this.stageBackgroundMap = new Dictionary<int, Sprite> {
			{ 1, stage1Back }, { 2, stage2Back }, { 3, stage3Back }, { 4, stage4Back }, { 5, stage5Back }, { 6, stage6Back },
			{ 7, stage7Back }, { 8, stage8Back }, { 9, stage9Back }, { 10, stage10Back }, { 11, stage11Back }, { 12, stage12Back },
		};

		//BGMの設定
		this.stageBGMMap = new Dictionary<int, AudioClip> {
			{ 1, stage1BGM }, { 2, stage2BGM }, { 3, stage3BGM }, { 4, stage4BGM }, { 5, stage5BGM }, { 6, stage6BGM },
			{ 7, stage7BGM }, { 8, stage8BGM }, { 9, stage9BGM }, { 10, stage10BGM }, { 11, stage11BGM }, { 12, stage12BGM },
		};

		// 前回ユーザ設定の設定
		if ((object[])GlobalObject.getInstance().Params != null
			&& (object)GlobalObject.getInstance().Params[1] != null) {
			SetLastSettings();
		}
		// ユーザ設定がnullの場合。本来はあり得ない（デバッグ用）。
		//else {
		//	this.settingObject.GetComponent<SettingObject>().SetBgmNum(3);
		//	this.settingObject.GetComponent<SettingObject>().SetSeNum(3);

		//	this.audioSource.clip = this.stageBGMMap[(int)stageNum];
		//	this.audioSource.volume = 0.6f;
		//	this.audioSource.Play();
		//}

		// プレイヤー選択キャラの設定
		this.variables.GetComponent<Variables>().SetCharaNoList(charaNoList);

		// シーン間引き継ぎ変数の初期化（ジョーカースクリプトからの遷移かを判断するため）
		GlobalObject.getInstance().SetStringParam(null);
		GlobalObject.getInstance().SetParam(null);
		GlobalObject.getInstance().SetParams(null);

		for (int i = 0; i < charaNoList.Count; i++) {
			this.charaNoMap.Add(charaNoList[i], 0);
		}

		//ステージの詳細を取得
		this.monsterMap = this.stageEnemyInfo.StageMonsterComingNumMap[(int)stageNum];
		this.paceMap = this.stageEnemyInfo.StageMonsterComingPaceMap[(int)stageNum];

		// キャラの召喚ボタン画像設定
		this.charaNoSpriteMap = new Dictionary<int, Sprite> {
			{ CharaMonsterNoConst.FighterANo, this.fighterASprite },
			{ CharaMonsterNoConst.FighterBNo, this.fighterBSprite },
            { CharaMonsterNoConst.FighterCNo, this.fighterCSprite },
            { CharaMonsterNoConst.WitchANo, this.witchASprite },
			{ CharaMonsterNoConst.WitchBNo, this.witchBSprite },
			{ CharaMonsterNoConst.HealerANo, this.healerASprite },
			{ CharaMonsterNoConst.HealerCNo, this.healerCSprite },
			{ CharaMonsterNoConst.SupporterANo, this.supporterASprite },
			{ CharaMonsterNoConst.SupporterBNo, this.supporterBSprite },
		};

		// モンスターのオブジェクト情報を番号別にマップに設定
		this.monsterPrefabMap = new Dictionary<int, MonsterObject> {
			{ CharaMonsterNoConst.SlimeNo, new MonsterObject(slimePre, MonsterStatusConst.SlimeName) },
			{ CharaMonsterNoConst.GaitherNo, new MonsterObject(gaitherPre, MonsterStatusConst.GaitherName) },
			{ CharaMonsterNoConst.SlimeRedNo, new MonsterObject(slimeRedPre, MonsterStatusConst.SlimeRedName) },
			{ CharaMonsterNoConst.GaitherWhiteNo, new MonsterObject(gaitherWhitePre, MonsterStatusConst.GaitherWhiteName) },
			{ CharaMonsterNoConst.ZonbieWhiteNo, new MonsterObject(zonbieWhitePre, MonsterStatusConst.ZonbieWhiteName) },
			{ CharaMonsterNoConst.ZonbieGreenNo, new MonsterObject(zonbieGreenPre, MonsterStatusConst.ZonbieGreenName) },
			{ CharaMonsterNoConst.GoblinGreenNo, new MonsterObject(goblinGreenPre, MonsterStatusConst.GoblinGreenName) },
			{ CharaMonsterNoConst.GoblinBlackNo, new MonsterObject(goblinBlackPre, MonsterStatusConst.GoblinBlackName) },
			{ CharaMonsterNoConst.YetiWhiteNo, new MonsterObject(yetiWhitePre, MonsterStatusConst.YetiWhiteName) },
			{ CharaMonsterNoConst.YetiGreenNo, new MonsterObject(yetiGreenPre, MonsterStatusConst.YetiGreenName) },
			{ CharaMonsterNoConst.IfreetRedNo, new MonsterObject(ifreetRedPre, MonsterStatusConst.IfritRedName) },
			{ CharaMonsterNoConst.IfreetGreenNo, new MonsterObject(ifreetGreenPre, MonsterStatusConst.IfritGreenName) },
			{ CharaMonsterNoConst.CentaurBrownNo, new MonsterObject(centaurBrownPre, MonsterStatusConst.CentaurBrownName) },
			{ CharaMonsterNoConst.CentaurBlackNo, new MonsterObject(centaurBlackPre, MonsterStatusConst.CentaurBlackName) },
			{ CharaMonsterNoConst.UnicornWhiteNo, new MonsterObject(unicornWhitePre, MonsterStatusConst.UnicornWhiteName) },
			{ CharaMonsterNoConst.UnicornBlackNo, new MonsterObject(unicornBlackPre, MonsterStatusConst.UnicornBlackName) },
			{ CharaMonsterNoConst.OgreOrangeNo, new MonsterObject(ogreOrangePre, MonsterStatusConst.OrgeOrangeName) },
			{ CharaMonsterNoConst.OgreGreenNo, new MonsterObject(ogreGreenPre, MonsterStatusConst.OrgeGreenName) },
			{ CharaMonsterNoConst.ChimeraPurpleNo, new MonsterObject(chimeraPurplePre, MonsterStatusConst.ChimeraPurpleName) },
			{ CharaMonsterNoConst.ChimeraRedNo, new MonsterObject(chimeraRedPre, MonsterStatusConst.ChimeraRedName) },
			{ CharaMonsterNoConst.FairyYerrowNo, new MonsterObject(fairyYerrowPre, MonsterStatusConst.FairyYellowName) },
			{ CharaMonsterNoConst.FairyPurpleNo, new MonsterObject(fairyPurplePre, MonsterStatusConst.FairyPurpleName) },
			{ CharaMonsterNoConst.CarbuncleNo, new MonsterObject(carbunclePre, MonsterStatusConst.CarbuncleName) },
			{ CharaMonsterNoConst.GolemNo, new MonsterObject(golemPre, MonsterStatusConst.GolemName) },
			{ CharaMonsterNoConst.AlrauneNo, new MonsterObject(alraunePre, MonsterStatusConst.AlrauneName) },
            { CharaMonsterNoConst.BossSlimeNo, new MonsterObject(bossSlimePre, MonsterStatusConst.BossSlimeName) },
            { CharaMonsterNoConst.BossHealerNo, new MonsterObject(bossHealerPre, MonsterStatusConst.BossHealerName) },
        };

		// 各モンスターの名前につける番号のマップを設定
		foreach(int monsterNo in this.monsterMap.Keys) {
			this.monsterNoMap.Add(monsterNo, 0);
		}

		GameObject backImgInstance = Instantiate(this.backImgPrefab) as GameObject;
		backImgInstance.transform.position = new Vector3(0, 0, 0);
		backImgInstance.GetComponent<UnityEngine.UI.Image>().sprite = this.stageBackgroundMap[(int)stageNum];
		backImgInstance.transform.SetParent(canvas.transform, false);
		backImgInstance.transform.SetAsFirstSibling();
		backImgInstance.name = "backImgInstance";

		// 召喚ボタンの設定
		SetSummonButtons();
	}
	
	void Update () {
		this.time += Time.deltaTime;

		// ペースマップ通りの時間経過後、数がMAXでなければモンスター投下
		if(this.monsterNum < this.paceMap.Count && this.time >= this.paceMap[this.monsterNum + 1]) {
			this.time = 0;
            GameObject monsterGo = new GameObject();

			// どのモンスターを投下するかを判断
			foreach (int monsterNo in this.monsterMap.Keys) {
				if (monsterMap[monsterNo].Contains(this.monsterNum + 1)) {

					// 投下するモンスター情報を設定
					this.monsterNoMap[monsterNo] = this.monsterNoMap[monsterNo] + 1;
					monsterGo = Instantiate(this.monsterPrefabMap[monsterNo].prefab) as GameObject;
					monsterGo.name = this.monsterPrefabMap[monsterNo].objectName + this.monsterNoMap[monsterNo];

					break;
				}
			}

			monsterGo.transform.position = new Vector2(7, -1);

			this.monsterNum++;
		}

		// 全モンスターを倒したらシーン遷移
		if (this.deadMonsterNum == this.paceMap.Count) {

			if (this.clearness <= 1.0f) {

				if (this.clearness == 0.0f) {
					this.canvas.sortingOrder = 5;
					this.hiddenClearImageUI.GetComponent<AudioSource>().Play();
				}
                this.audioSource.Stop();
                this.clearness += SpeedClearFadein * Time.deltaTime;
				this.hiddenClearImage.color = new Color(0.1843f, 0.3098f, 0.3098f, this.clearness);
				this.clearText.color = new Color(1, 1, 1, this.clearness);

				return;
			}
			else {
				if (Input.GetMouseButtonDown(0)) LoadNextScene();
			}
		}
	}

	/// <summary>
	/// 前回の設定を反映する。
	/// </summary>
	private void SetLastSettings() {
		SettingObject settingObjectFromOthers = (SettingObject)GlobalObject.getInstance().Params[1];
		this.settingObject.GetComponent<SettingObject>().SetIsSetBefore(settingObjectFromOthers.IsSetBefore);
		this.settingObject.GetComponent<SettingObject>().SetBgmNum(settingObjectFromOthers.BgmNum);
		this.settingObject.GetComponent<SettingObject>().SetSeNum(settingObjectFromOthers.SeNum);
		this.settingObject.GetComponent<SettingObject>().SetEffectNum(settingObjectFromOthers.EffectNum);
		this.settingObject.GetComponent<SettingObject>().SetDamageNum(settingObjectFromOthers.DamageNum);

		// BGM音声ファイルの設定
		double stageNum = this.variables.GetComponent<Variables>().StageNum;
		this.audioSource.clip = this.stageBGMMap[(int)stageNum];
		
		this.audioSource.volume = settingObjectFromOthers.BgmNum * 0.2f;

		this.audioSource.Play();
	}

	/// <summary>
	/// 召喚ボタンを設定する。
	/// </summary>
	private void SetSummonButtons() {
		float xZahyouLeft = -240;
		float xZayouMargin = 120;
		float yZahyou = -180;

		List<int> charaNoList = this.variables.GetComponent<Variables>().CharaNoList;

		for (int i = 0; i < this.charaNoMap.Count; i++) {
			GameObject summonBtnInstance = Instantiate(this.summonBtnPrefab) as GameObject;
			summonBtnInstance.transform.position = new Vector3(xZahyouLeft, yZahyou, 0);
			summonBtnInstance.transform.FindChild("Image").GetComponent<UnityEngine.UI.Image>().sprite
				= this.charaNoSpriteMap[charaNoList[i]];
			summonBtnInstance.transform.SetParent(this.canvas.transform, false);
			summonBtnInstance.name = "SummonButton" + (i + 1);

			xZahyouLeft += xZayouMargin;
		}
	}

	/// <summary>
	/// ステージごとに適切なシーンに遷移する。
	/// </summary>
	/// <param name="isGameOver">ゲームオーバーかどうか</param>
	public void LoadNextScene(bool isGameOver = false) {
		double stageNum = this.variables.GetComponent<Variables>().StageNum;

		if (isGameOver) {
			SetVariablesAndCallJoker(stageNum, isGameOver);
			return;
		}

		// 後ストーリーのあるものはジョーカースクリプトへ
		if (Array.IndexOf(StageNumsPlusHalf, stageNum) >= 0) {
			stageNum += 0.5;

			SetVariablesAndCallJoker(stageNum);
		}
		// 最終ステージだったらエンディングへ
		else if (stageNum == AllStageNum) {
			stageNum = -1;

			SetVariablesAndCallJoker(stageNum);
		}
		// それ以外はマップへ
		else {
			stageNum++;

			SetVariablesAndLoadMap(stageNum);
		}
	}

	/// <summary>
	/// 変数を設定してジョーカースクリプトに遷移する。
	/// </summary>
	/// <param name="stageNum">ステージ番号</param>
	private void SetVariablesAndCallJoker(double stageNum, bool isGameOver = false) {

		bool isSetBefore = this.settingObject.GetComponent<SettingObject>().IsSetBefore;
		int bgmNum = this.settingObject.GetComponent<SettingObject>().BgmNum;
		int seNum = this.settingObject.GetComponent<SettingObject>().SeNum;
		int effectNum = this.settingObject.GetComponent<SettingObject>().EffectNum;
		int damageNum = this.settingObject.GetComponent<SettingObject>().DamageNum;

		StatusManager.variable.set("stage.number", stageNum.ToString());
		StatusManager.variable.set("is.setBefore", isSetBefore.ToString());
		StatusManager.variable.set("bgm.number", bgmNum.ToString());
		StatusManager.variable.set("se.number", seNum.ToString());
		StatusManager.variable.set("effect.number", effectNum.ToString());
		StatusManager.variable.set("damage.number", damageNum.ToString());

		string fileName = "material";
		if (isGameOver) fileName = "title";

		NovelSingleton.StatusManager.callJoker(String.Format("wide/{0}", fileName), "");
	}

	/// <summary>
	/// 変数を設定してマップ画面に遷移する。
	/// </summary>
	/// <param name="stageNum">ステージ番号</param>
	private void SetVariablesAndLoadMap(double stageNum) {

		GlobalObject.LoadLevelWithParams("Map", stageNum.ToString(), this.settingObject.GetComponent<SettingObject>());
	}

	/// <summary>
	/// キャラクターを生成する。
	/// </summary>
	/// <param name="charaNo">キャラクター番号</param>
	public void GenerateChara(int charaNo) {
		GameObject chara = null;
		float positionX = -7;
		float positionY = -1;

		this.charaNoMap[charaNo] = this.charaNoMap[charaNo] + 1;
		
		if (charaNo == CharaMonsterNoConst.FighterANo) {
			chara = Instantiate(this.fighter1Pre) as GameObject;
			chara.name = string.Format("FighterA{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.FighterBNo) {
			chara = Instantiate(this.fighter2Pre) as GameObject;
			chara.name = string.Format("FighterB{0}", this.charaNoMap[charaNo]);
		}
        else if (charaNo == CharaMonsterNoConst.FighterCNo)
        {
            chara = Instantiate(this.fighter3Pre) as GameObject;
            chara.name = string.Format("FighterC{0}", this.charaNoMap[charaNo]);
			positionY = -0.8f;
		}
        else if(charaNo == CharaMonsterNoConst.WitchANo) {
			chara = Instantiate(this.witch1Pre) as GameObject;
			chara.name = string.Format("WitchA{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.WitchBNo) {
			chara = Instantiate(this.witch2Pre) as GameObject;
			chara.name = string.Format("WitchB{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.HealerANo) {
			chara = Instantiate(this.healer1Pre) as GameObject;
			chara.name = string.Format("HealerA{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.HealerCNo) {
			chara = Instantiate(this.healer3Pre) as GameObject;
			chara.name = string.Format("HealerC{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.SupporterANo) {
			chara = Instantiate(this.supporter1Pre) as GameObject;
			chara.name = string.Format("SupporterA{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.SupporterBNo) {
			chara = Instantiate(this.supporter2Pre) as GameObject;
			chara.name = string.Format("SupporterB{0}", this.charaNoMap[charaNo]);
		}

		chara.transform.position = new Vector2(positionX, positionY);
	}
	
    /// <summary>
    /// 倒したモンスターの数をカウントする。
    /// </summary>
	public void CountDeadMonster() {
		this.deadMonsterNum++;
	}
}