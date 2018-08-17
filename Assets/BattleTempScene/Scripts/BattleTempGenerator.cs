using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 仮バトルシーンのジェネレーター
/// </summary>
public class BattleTempGenerator : MonoBehaviour {
	
    private const int MaxMonsterNum = 20;

    //オブジェクトの登録
    public GameObject fighter1Pre;
	public GameObject witch1Pre;
	public GameObject witch2Pre;
	public GameObject healer1Pre;
	public GameObject healer2Pre;
	public GameObject healer3Pre;
	public GameObject supporter1Pre;
	public GameObject supporter2Pre;
	public GameObject slimePre;
	public GameObject gaitherPre;
	public GameObject summonBtnPrefab;
    public GameObject variables;

    //ステージ番号
    private double stageNum = 0;

	private Canvas canvas;
	private CurrentStatusVariables currentStatusVariables;
	private float time = 0;
    private float timeToCall = 0;
    private int monsterNum = 0;
    private int deadMonsterNum = 0;
	private Dictionary<int, int> charaNoMap;
	private Dictionary<int, int> monsterNoMap = new Dictionary<int, int>();

	// Use this for initialization
	void Start () {
		this.canvas = GameObject.FindObjectOfType<Canvas>();
		this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();

        //ステージ番号の取得
        stageNum = this.variables.GetComponent<Variables>().StageNum;

        //ステージの詳細を取得


        // 仮にプレイヤー選択キャラを設定
        var charaNumList = new List<int>() { 1, 11, 5, 6, 12 };
		this.charaNoMap = new Dictionary<int, int> {
			{ charaNumList[0], 0 },
			{ charaNumList[1], 0 },
			{ charaNumList[2], 0 },
			{ charaNumList[3], 0 },
			{ charaNumList[4], 0 },
		};

		// 仮に出現モンスターを設定
		var monsterNumList = new List<int>() { 1, 2 };
		foreach(int monsterNum in monsterNumList) {
			this.monsterNoMap.Add(monsterNum, 0);
		}

		SetSummonButtons();
	}
	
	// Update is called once per frame
	void Update () {
		this.time += Time.deltaTime;

		// ランダムな時間経過後、数がMAXでなければモンスター投下
		if(this.monsterNum < MaxMonsterNum && this.time >= this.timeToCall) {
			this.time = 0;

			int dice = Random.Range(1, 6);
            GameObject monsterGo;

			if(dice <= 3){
				this.monsterNoMap[1] = this.monsterNoMap[1] + 1;
				monsterGo = Instantiate(this.slimePre) as GameObject;
				monsterGo.name = string.Format("Slime{0}", this.monsterNoMap[1]);
			}
            else {
				this.monsterNoMap[2] = this.monsterNoMap[2] + 1;
				monsterGo = Instantiate(this.gaitherPre) as GameObject;
				monsterGo.name = string.Format("Gaither{0}", this.monsterNoMap[2]);
			}

			monsterGo.transform.position = new Vector2(7, -2);

			this.monsterNum++;
			this.timeToCall = Random.Range(1, 7);
		}

		if(this.deadMonsterNum == MaxMonsterNum) {
			Invoke("Clear", 2.0f);
		}
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
	
    /// <summary>
    /// クリアシーンに遷移する。
    /// </summary>
	private void LoadClearScene() {
		SceneManager.LoadScene("Clear");
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
}