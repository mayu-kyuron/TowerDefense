using Novel;
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
	public GameObject witch1Pre;
	public GameObject witch2Pre;
	public GameObject healer1Pre;
	public GameObject healer2Pre;
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

	public GameObject summonBtnPrefab;
    public GameObject variables;
	public GameObject settingObject;
	public GameObject hiddenClearImageUI;

	private Canvas canvas;
	private CurrentStatusVariables currentStatusVariables;
	private StageEnemyInfo stageEnemyInfo = new StageEnemyInfo();
	private UnityEngine.UI.Image hiddenClearImage;
	private Text clearText;
	private float time = 0;
	private float clearness = 0.0f;
	private int monsterNum = 0;
    private int deadMonsterNum = 0;
	private Dictionary<int, int> charaNoMap;
	private Dictionary<int, int> monsterNoMap = new Dictionary<int, int>();
	private Dictionary<int, List<int>> monsterMap;
	private Dictionary<int, double> paceMap;
	private Dictionary<int, MonsterObject> monsterPrefabMap;
	
	void Start () {
		this.canvas = GameObject.FindObjectOfType<Canvas>();
		this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();
		this.hiddenClearImage = this.hiddenClearImageUI.GetComponent<UnityEngine.UI.Image>();
		this.clearText = this.hiddenClearImageUI.GetComponentInChildren<Text>();

		//double stageNum = 1;
		double stageNum = double.Parse(GlobalObject.getInstance().Params[0].ToString());

		// ステージ番号の設定
		this.variables.GetComponent<Variables>().SetStageNum(stageNum);

		// 前回ユーザ設定の設定
		if ((object[])GlobalObject.getInstance().Params != null
			&& (object)GlobalObject.getInstance().Params[1] != null) {
			SetLastSettings();
		}

		//ステージの詳細を取得
		this.monsterMap = this.stageEnemyInfo.StageMonsterComingNumMap[(int)stageNum];
		this.paceMap = this.stageEnemyInfo.StageMonsterComingPaceMap[(int)stageNum];

		// 仮にプレイヤー選択キャラを設定
		var charaNumList = new List<int>() { 1, 11, 5, 6, 12 };
		this.charaNoMap = new Dictionary<int, int> {
			{ charaNumList[0], 0 },
			{ charaNumList[1], 0 },
			{ charaNumList[2], 0 },
			{ charaNumList[3], 0 },
			{ charaNumList[4], 0 },
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
		};

		// 各モンスターの名前につける番号のマップを設定
		foreach(int monsterNo in this.monsterMap.Keys) {
			this.monsterNoMap.Add(monsterNo, 0);
		}

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

			monsterGo.transform.position = new Vector2(7, -2);

			this.monsterNum++;
		}

		// 全モンスターを倒したらシーン遷移
		if (this.deadMonsterNum == this.paceMap.Count) {

			if (this.clearness <= 1.0f) {
				if (this.clearness == 0.0f) this.hiddenClearImageUI.GetComponent<AudioSource>().Play();

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
	}

	/// <summary>
	/// 召喚ボタンを設定する。
	/// </summary>
	private void SetSummonButtons() {
		float xZahyouLeft = -240;
		float xZayouMargin = 120;
		float yZahyou = -180;

		for (int i = 0; i < 5; i++) {
			GameObject summonBtnInstance = Instantiate(this.summonBtnPrefab) as GameObject;
			summonBtnInstance.transform.position = new Vector3(xZahyouLeft, yZahyou, 0);
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
		float positionY = -2;

		this.charaNoMap[charaNo] = this.charaNoMap[charaNo] + 1;
		
		if (charaNo == CharaMonsterNoConst.FighterANo) {
			chara = Instantiate(this.fighter1Pre) as GameObject;
			chara.name = string.Format("FighterA{0}", this.charaNoMap[charaNo]);
		}
		else if (charaNo == CharaMonsterNoConst.FighterBNo) {
			chara = Instantiate(this.fighter2Pre) as GameObject;
			chara.name = string.Format("FighterB{0}", this.charaNoMap[charaNo]);
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
		else if (charaNo == CharaMonsterNoConst.HealerBNo) {
			chara = Instantiate(this.healer2Pre) as GameObject;
			chara.name = string.Format("HealerB{0}", this.charaNoMap[charaNo]);
			positionY = -1.75f;
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