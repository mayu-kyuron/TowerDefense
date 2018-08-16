using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// キャラクターコントローラー
/// </summary>
public abstract class CharaController : MonoBehaviour {

	//ステータス
	[HideInInspector]
	public float hp;
	[HideInInspector]
	public float maxHp;
	protected int energyNeeded;
	protected float power;
	protected float speedToMove;
	protected float timeToAttack;

	//フラッグ
	[HideInInspector]
	public bool isMoving = true;
	protected bool isFacingEnemy = false;
	protected string monsterKind;

	public GameObject damageUI;
	public GameObject cureUI;

	// 各モンスターコントローラー
	protected FighterMonsterController fighterMonsterController;
	protected SimpleWitchMonsterController simpleWitchMonsterController;
	protected BroadWitchMonsterController broadWitchMonsterController;
	protected SimpleHealerMonsterController simpleHealerMonsterController;

	protected CurrentStatusVariables currentStatusVariables;
	protected CharaStatusConst charaStatusConst = new CharaStatusConst();
	protected MonsterStatusConst monsterStatusConst = new MonsterStatusConst();
	protected float time = 0;
	protected string charaObjectName;

	// 半角数字の正規表現
	protected Regex halfNumRegex = new Regex(@"\d");

	protected virtual void Awake() {

		// オブジェクトのタグ名からキャラを判断し、ステータスを取得する。
		Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[this.gameObject.tag];

		this.hp = thisCharaStatusMap[CharaStatusConst.HpKey];
		this.maxHp = thisCharaStatusMap[CharaStatusConst.HpKey];
		this.power = thisCharaStatusMap[CharaStatusConst.PowerKey];
		this.speedToMove = thisCharaStatusMap[CharaStatusConst.SpeedToMoveKey];
		this.timeToAttack = thisCharaStatusMap[CharaStatusConst.TimeToAttackKey];
		this.energyNeeded = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
	}

	protected virtual void Start() {
		this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();

		// キャラクターオブジェクト名を取得する。
		this.charaObjectName = this.gameObject.name;
		if (this.gameObject.tag == CharaStatusConst.AttackTag) this.charaObjectName = transform.root.gameObject.name;

		AddCharaToMap();
	}

	/// <summary>
	/// 登場キャラクターマップにHPや攻撃力を登録する。
	/// </summary>
	protected abstract void AddCharaToMap();

	protected virtual void Update() {

		// 範囲攻撃や能力アップを受けていた場合のHPを反映する。
		SetCurrentHpAndMaxHp();

		// 前進する（真ん中辺りでストップ）
		GoAhead();

		// 攻撃や回復などを行う
		Action();

		// 敗北、消滅する
		Disappear();
	}

	/// <summary>
	/// 最新の自分のHPと最大HPを取得し、設定する。
	/// </summary>
	protected virtual void SetCurrentHpAndMaxHp() {
		Dictionary<string, float> currentHpMap = this.currentStatusVariables.CurrentCharaHpMap;
		Dictionary<string, float> currentMaxHpMap = this.currentStatusVariables.CurrentCharaMaxHpMap;

		this.hp = currentHpMap[this.charaObjectName];
		this.maxHp = currentMaxHpMap[this.charaObjectName];
	}

	/// <summary>
	/// キャラを前進させる。
	/// </summary>
	protected virtual void GoAhead() {
		if (this.isMoving && this.transform.position.x < 0) this.transform.Translate(this.speedToMove, 0, 0);
	}

	/// <summary>
	/// キャラに攻撃や回復をさせる。
	/// </summary>
	protected abstract void Action();

	/// <summary>
	/// キャラを消滅させる。
	/// </summary>
	protected virtual void Disappear() {

		if (this.hp <= 0) {

			// 登場キャラのHP・攻撃力・最大HPマップから自分を削除する。
			this.currentStatusVariables.RemoveCharaHpFromMap(this.charaObjectName);
			this.currentStatusVariables.RemoveCharaPowerFromMap(this.charaObjectName);
			this.currentStatusVariables.RemoveCharaMaxHpFromMap(this.charaObjectName);

			Debug.Log(this.charaObjectName + " - Disappear.");

			Destroy(this.gameObject);
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D other) {

		// 前進していたとき、敵と衝突したら攻撃に移る
		if (!this.isFacingEnemy) {

			// 遠距離攻撃キャラの攻撃用コライダは、ぶつかってもスル―
			if (other.gameObject.tag == MonsterStatusConst.AttackTag) return;

			RamifySettingFightingMonster(other);
		}
	}

	protected virtual void OnTriggerExit2D(Collider2D other) {
		this.isFacingEnemy = false;
		this.isMoving = true;
	}

	/// <summary>
	/// 衝突モンスター設定処理を分岐させる。
	/// </summary>
	/// <param name="other">衝突コライダ</param>
	protected void RamifySettingFightingMonster(Collider2D other) {

		string monsterName = GetCharaMonsterName(other.name);

		if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.FighterMonsterKind].Contains(monsterName)) {
			this.fighterMonsterController = SetFightingMonster<FighterMonsterController>(MonsterStatusConst.FighterMonsterKind, other);
		}
		else if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.SimpleWitchMonsterKind].Contains(monsterName)) {
			this.simpleWitchMonsterController = SetFightingMonster<SimpleWitchMonsterController>(MonsterStatusConst.SimpleWitchMonsterKind, other);
		}
		else if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.BroadWitchMonsterKind].Contains(monsterName)) {
			this.broadWitchMonsterController = SetFightingMonster<BroadWitchMonsterController>(MonsterStatusConst.BroadWitchMonsterKind, other);
		}
		else if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.SimpleHealerMonsterKind].Contains(monsterName)) {
			this.simpleHealerMonsterController = SetFightingMonster<SimpleHealerMonsterController>(MonsterStatusConst.SimpleHealerMonsterKind, other);
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
	/// 衝突したモンスターを設定する。
	/// </summary>
	/// <typeparam name="T">モンスターコントローラー</typeparam>
	/// <param name="monsterKind">モンスター種類</param>
	/// <param name="other">衝突コライダ</param>
	/// <returns>モンスターコントローラーの子インスタンス</returns>
	protected virtual T SetFightingMonster<T>(string monsterKind, Collider2D other)
		where T : MonsterController {

		this.isFacingEnemy = true;
		this.isMoving = false;
		this.monsterKind = monsterKind;

		return other.gameObject.GetComponent<T>();
	}

	/// <summary>
	/// 自分の受けたダメージを表示し、HPを更新する。
	/// </summary>
	/// <param name="damage">ダメージ量</param>
	public void Damage(float damage) {

        DisplayDamageUI(damage);
		
		// 登場キャラマップのHPを更新する。
		this.currentStatusVariables.UpdateCharaHpOfMap(this.charaObjectName, this.hp);
	}
    /// <summary>
    /// 自分の受けたダメージを表示する。
    /// </summary>
    /// <param name="dammage"></param>
    public void DisplayDamageUI(float damage)
    {
        var damageUISc = this.damageUI.GetComponent<damageUIScript>();
        GameObject damageText = Instantiate(this.damageUI) as GameObject;

        damageUISc.damage = damage;
        damageText.transform.position = new Vector2(
            this.transform.position.x - 0.3f, this.transform.position.y + 1.3f);
    }

    /// <summary>
    /// 自分の受けた回復量を表示する。
    /// </summary>
    /// <param name="cure">回復量</param>
    public void DisplayCureUI(float cure) {
		var cureUIController = this.cureUI.GetComponent<CureUIController>();
		GameObject cureText = Instantiate(this.cureUI) as GameObject;

		cureUIController.cure = cure;
		cureText.transform.position = new Vector2(
			this.transform.position.x - 0.3f, this.transform.position.y + 1.3f);

		// 登場キャラマップのHPを更新する。
		this.currentStatusVariables.UpdateCharaHpOfMap(this.charaObjectName, this.hp);
	}

	/// <summary>
	///	必要エネルギーを取得する。
	/// </summary>
	public int EnergyNeeded {
		get { return this.energyNeeded; }
	}
}