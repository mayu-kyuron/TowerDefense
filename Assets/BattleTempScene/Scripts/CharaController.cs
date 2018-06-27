using UnityEngine;
using System.Collections.Generic;

public abstract class CharaController : MonoBehaviour {

	//ステータス
	[HideInInspector]
	public float hp;
	protected int energyNeeded;
	protected float power;
	protected float speedToMove;
	protected float timeToAttack;

	//フラッグ
	[HideInInspector]
	public bool isMoving = true;
	protected bool isFacingEnemy = false;
	protected int monsterType = 0;

	public GameObject damageUI;
	public GameObject cureUI;

	protected EnemyFighterController enemyFighterController;
	protected GaitherSc gaitherSc;
	protected CurrentStatusVariables currentStatusVariables;
	protected float time = 0;

	protected virtual void Awake() {

		// オブジェクトのタグ名からキャラを判断し、ステータスを取得する。
		Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[this.gameObject.tag];

		this.hp = thisCharaStatusMap[CharaStatusConst.HpKey];
		this.power = thisCharaStatusMap[CharaStatusConst.PowerKey];
		this.speedToMove = thisCharaStatusMap[CharaStatusConst.SpeedToMoveKey];
		this.timeToAttack = thisCharaStatusMap[CharaStatusConst.TimeToAttackKey];
		this.energyNeeded = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
	}

	protected virtual void Start() {
		this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();

		// 自分の名前とHPを、登場キャラマップに登録する。
		Dictionary<string, float> currentHpMap = this.currentStatusVariables.CurrentHpMap;
		currentHpMap.Add(this.gameObject.name, this.hp);
		this.currentStatusVariables.SetCurrentHpMap(currentHpMap);
	}

	protected virtual void Update() {
		// 前進する（真ん中辺りでストップ）
		GoAhead();

		// 攻撃や回復などを行う
		Action();

		// 敗北、消滅する
		Disappear();
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

			// 登場キャラマップから自分を削除する。
			Dictionary<string, float> currentHpMap = this.currentStatusVariables.CurrentHpMap;
			currentHpMap.Remove(this.gameObject.name);
			this.currentStatusVariables.SetCurrentHpMap(currentHpMap);

			Destroy(this.gameObject);
		}
	}

	protected virtual void OnTriggerStay2D(Collider2D other) {

		// 前進していたとき、敵と衝突したら攻撃に移る
		if (!this.isFacingEnemy) {

			// 遠距離攻撃キャラの攻撃用コライダは、ぶつかってもスル―
			if (other.gameObject.tag == CharaStatusConst.AttackTag) return;

			if (other.gameObject.tag == MonsterStatusConst.SlimeTag) {
				this.isFacingEnemy = true;
				this.isMoving = false;
				this.enemyFighterController = other.gameObject.GetComponent<EnemyFighterController>();
				this.monsterType = CharaMonsterNoConst.SlimeNo;
			}
			else if (other.gameObject.tag == MonsterStatusConst.GaitherTag) {
				this.isFacingEnemy = true;
				this.isMoving = false;
				this.gaitherSc = other.gameObject.GetComponent<GaitherSc>();
				this.monsterType = CharaMonsterNoConst.GaitherNo;
			}
		}
	}

	protected virtual void OnTriggerExit2D(Collider2D other) {
		this.isFacingEnemy = false;
		this.isMoving = true;
	}

	/// <summary>
	/// 自分の受けたダメージを表示する。
	/// </summary>
	/// <param name="damage">ダメージ量</param>
	public void DisplayDamageUI(float damage) {
		damageUIScript damageUISc = this.damageUI.GetComponent<damageUIScript>();
		GameObject damageText = Instantiate(this.damageUI) as GameObject;

		damageUISc.damage = damage;
		damageText.transform.position = new Vector2(
			this.transform.position.x - 0.3f, this.transform.position.y + 1.3f);

		// 登場キャラマップのHPを更新する。
		Dictionary<string, float> currentHpMap = this.currentStatusVariables.CurrentHpMap;
		currentHpMap[this.gameObject.name] = this.hp;
		this.currentStatusVariables.SetCurrentHpMap(currentHpMap);
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
		Dictionary<string, float> currentHpMap = this.currentStatusVariables.CurrentHpMap;
		currentHpMap[this.gameObject.name] = this.hp;
		this.currentStatusVariables.SetCurrentHpMap(currentHpMap);
	}

	/// <summary>
	///	必要エネルギーを取得する。
	/// </summary>
	public int EnergyNeeded {
		get { return this.energyNeeded; }
	}
}