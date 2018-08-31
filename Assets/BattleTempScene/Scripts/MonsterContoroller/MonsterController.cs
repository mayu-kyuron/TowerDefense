using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// モンスターコントローラー
/// </summary>
public abstract class MonsterController : MonoBehaviour {
	
	//ステータス
	[HideInInspector]
	public float hp;
	protected float power;
	protected float speedToMove;
	protected float timeToAttack;

	//フラッグ
	[HideInInspector]
	public bool isMoving = true;
	protected bool isFacingEnemy = false;
	protected string charaKind;

    public GameObject damageUI;
	public GameObject cureUI;

	// 各キャラコントローラー
	protected FighterController fighterController;
	protected SimpleWitchController simpleWitchController;
	protected BroadWitchController broadWitchController;
	protected SimpleHealerController simpleHealerController;
	protected TotalHealerController totalHealerController;
	protected BroadHealerController broadHealerController;
	protected PowerSupporterController powerSupporterController;
	protected HpSupporterController hpSupporterController;
	protected ShipSc shipSc;

	protected BattleTempGenerator battleTempGenerator;
	protected CurrentStatusVariables currentStatusVariables;
	protected CharaStatusConst charaStatusConst = new CharaStatusConst();
	protected MonsterStatusConst monsterStatusConst = new MonsterStatusConst();

	protected float time = 0;
	protected string monsterObjectName;

	// 半角数字の正規表現
	protected Regex halfNumRegex = new Regex(@"\d");

	protected virtual void Awake() {

		// オブジェクトのタグ名からモンスターを判断し、ステータスを取得する。
		Dictionary<string, float> thisMonsterStatusMap = this.monsterStatusConst.MonsterStatusMap[this.gameObject.tag];

		this.hp = thisMonsterStatusMap[MonsterStatusConst.HpKey];
		this.power = thisMonsterStatusMap[MonsterStatusConst.PowerKey];
		this.speedToMove = thisMonsterStatusMap[MonsterStatusConst.SpeedToMoveKey];
		this.timeToAttack = thisMonsterStatusMap[MonsterStatusConst.TimeToAttackKey];
        //Debug.Log("Awake" + hp);
	}

	protected virtual void Start () {
		this.battleTempGenerator = GameObject.Find("BattleTempGenerator").GetComponent<BattleTempGenerator>();
		this.shipSc = GameObject.Find("Ship").GetComponent<ShipSc>();
		this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();

		// モンスターオブジェクト名を取得する。
		this.monsterObjectName = this.gameObject.name;
		if (this.gameObject.tag == CharaStatusConst.AttackTag) this.monsterObjectName = transform.root.gameObject.name;

        // 自分の名前をキーに、HPを登場モンスターマップに登録する。
        //Debug.Log("登録前の渡す値" + this.hp);
        this.currentStatusVariables.AddMonsterHpToMap(this.monsterObjectName, this.hp);
	}

	protected virtual void Update () {

		// 範囲攻撃を受けていた場合のHPを反映する。
		SetCurrentHp();

		// 前進する。
		GoAhead();

		// 攻撃や回復などを行う（動きはストップ）。
		Action();

		// 敗北、消滅する。
		Disappear();
	}

	/// <summary>
	/// 最新の自分のHPを取得し、設定する。
	/// </summary>
	protected virtual void SetCurrentHp() {
		Dictionary<string, float> currentHpMap = this.currentStatusVariables.CurrentMonsterHpMap;
		this.hp = currentHpMap[this.monsterObjectName];
	}

	/// <summary>
	/// モンスターを前進させる。
	/// </summary>
	protected virtual void GoAhead() {
		if (this.isMoving) this.transform.Translate(this.speedToMove, 0, 0);
	}

	/// <summary>
	/// モンスターに攻撃や回復をさせる。
	/// </summary>
	protected abstract void Action();

	/// <summary>
	/// モンスターを消滅させる。
	/// </summary>
	protected virtual void Disappear() {

		if (this.hp <= 0) {
			this.battleTempGenerator.CountDeadMonster();

			// 登場モンスターのHPマップから自分を削除する。
			this.currentStatusVariables.RemoveMonsterHpFromMap(this.monsterObjectName);

			Debug.Log(this.monsterObjectName + " - Disappear.");

			Destroy(this.gameObject);
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D other){

		// 前進していたとき、敵と衝突したら攻撃に移る。
		if (!this.isFacingEnemy){

			// 遠距離攻撃キャラの攻撃用コライダは、ぶつかってもスル―
			if (other.gameObject.tag == CharaStatusConst.AttackTag) return;
			
			RamifySettingFightingChara(other);
		}
	}

	protected virtual void OnTriggerExit2D(Collider2D other){
        this.isFacingEnemy = false;
        this.isMoving = true;
	}

	/// <summary>
	/// 衝突キャラ設定処理を分岐させる。
	/// </summary>
	/// <param name="other">衝突コライダ</param>
	protected virtual void RamifySettingFightingChara(Collider2D other) {

		string charaName = GetCharaMonsterName(other.name);

		if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.FighterKind].Contains(charaName)) {
			this.fighterController = SetFightingChara<FighterController>(CharaStatusConst.FighterKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.SimpleWitchKind].Contains(charaName)) {
			this.simpleWitchController = SetFightingChara<SimpleWitchController>(CharaStatusConst.SimpleWitchKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.BroadWitchKind].Contains(charaName)) {
			this.broadWitchController = SetFightingChara<BroadWitchController>(CharaStatusConst.BroadWitchKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.SimpleHealerKind].Contains(charaName)) {
			this.simpleHealerController = SetFightingChara<SimpleHealerController>(CharaStatusConst.SimpleHealerKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.TotalHealerKind].Contains(charaName)) {
			this.totalHealerController = SetFightingChara<TotalHealerController>(CharaStatusConst.TotalHealerKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.BroadHealerKind].Contains(charaName)) {
			this.broadHealerController = SetFightingChara<BroadHealerController>(CharaStatusConst.BroadHealerKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.PowerSupporterKind].Contains(charaName)) {
			this.powerSupporterController = SetFightingChara<PowerSupporterController>(CharaStatusConst.PowerSupporterKind, other);
		}
		else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.HpSupporterKind].Contains(charaName)) {
			this.hpSupporterController = SetFightingChara<HpSupporterController>(CharaStatusConst.HpSupporterKind, other);
		}
		else if (other.gameObject.tag == CharaStatusConst.ShipTag) {
			SetFightingChara<CharaController>(CharaStatusConst.ShipTag, other);
		}
	}

	/// <summary>
	/// キャラ・モンスター名を取得する。
	/// </summary>
	/// <param name="objectName">オブジェクト名</param>
	/// <returns>キャラ・モンスター名</returns>
	protected string GetCharaMonsterName(string objectName) {
		string charaName = null;

		int numIndex = -1;
		for (int i = 0; i < objectName.Length; i++) {

			if (halfNumRegex.IsMatch(objectName[i].ToString())) {
				numIndex = i;
				break;
			}
		}

		if (numIndex != -1) charaName = objectName.Substring(0, numIndex);

		return charaName;
	}

	/// <summary>
	/// 衝突したキャラを設定する。
	/// </summary>
	/// <typeparam name="T">キャラコントローラー</typeparam>
	/// <param name="charaKind">キャラ種類</param>
	/// <param name="other">衝突コライダ</param>
	/// <returns>キャラコントローラーの子インスタンス</returns>
	protected virtual T SetFightingChara<T>(string charaKind, Collider2D other)
		where T : CharaController {

		this.isFacingEnemy = true;
		this.isMoving = false;
		this.charaKind = charaKind;

		return other.gameObject.GetComponent<T>();
	}

	/// <summary>
	/// 自分の受けたダメージを表示し、HPを更新する。
	/// </summary>
	/// <param name="damage">ダメージ量</param>
	public void Damage(float damage) {

		DisplayDamageUI(damage);

		// 登場モンスターマップのHPを更新する。
		this.currentStatusVariables.UpdateMonsterHpOfMap(this.monsterObjectName, this.hp);
	}

	/// <summary>
	/// 自分の受けたダメージを表示する。
	/// </summary>
	/// <param name="damage">ダメージ量</param>
	public void DisplayDamageUI(float damage){
		this.damageUI.GetComponent<damageUIScript>().damage = damage;

		GameObject damageText = Instantiate(this.damageUI) as GameObject;
		damageText.transform.position = new Vector2(
            this.transform.position.x - 0.3f, this.transform.position.y + 1.3f);
	}

	/// <summary>
	/// 自分の受けた回復量を表示する。
	/// </summary>
	/// <param name="cure">回復量</param>
	public void DisplayCureUI(float cure) {
		this.cureUI.GetComponent<CureUIController>().cure = cure;

		GameObject cureText = Instantiate(this.cureUI) as GameObject;
		cureText.transform.position = new Vector2(
			this.transform.position.x - 0.3f, this.transform.position.y + 1.3f);

		// 登場モンスターマップのHPを更新する。
		this.currentStatusVariables.UpdateMonsterHpOfMap(this.monsterObjectName, this.hp);
	}
}