using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFighterController : MonoBehaviour {
	
	//ステータス
	[HideInInspector]
	public float hp;
    private float power;
	private float speedToMove;
	private float timeToAttack;

	//フラッグ
	private bool isMoving = true;
	private bool isFacingEnemy = false;
	private int playerType = 0;

    public GameObject damageUI;

	private BattleTempGenerator battleTempGenerator;
	private FighterController fighterController;
	private SimpleWitchController simpleWitchController;
	private SimpleHealerController simpleHealerController;
	private TotalHealerController totalHealerController;
	private BroadHealerController broadHealerController;
	private ShipSc shipSc;
    private float time = 0;

	private void Awake() {

		// オブジェクトのタグ名からモンスターを判断し、ステータスを取得する。
		Dictionary<string, float> thisMonsterStatusMap = new MonsterStatusConst().MonsterStatusMap[this.gameObject.tag];

		this.hp = thisMonsterStatusMap[MonsterStatusConst.HpKey];
		this.power = thisMonsterStatusMap[MonsterStatusConst.PowerKey];
		this.speedToMove = thisMonsterStatusMap[MonsterStatusConst.SpeedToMoveKey];
		this.timeToAttack = thisMonsterStatusMap[MonsterStatusConst.TimeToAttackKey];
	}

	void Start () {
		this.battleTempGenerator = GameObject.Find("BattleTempGenerator").GetComponent<BattleTempGenerator>();
		this.shipSc = GameObject.Find("Ship").GetComponent<ShipSc>();
	}

	void Update () {

		// 前進する
		if (this.isMoving) {
			this.transform.Translate(this.speedToMove, 0, 0);
		}

        // 敵と戦う（動きはストップ）
        if (this.isFacingEnemy){
			this.time += Time.deltaTime;

            // 攻撃する
			if(this.time >= this.timeToAttack){
                this.time = 0;

				RamifyAttacking();
			}
		}

        // 敗北、消滅する
		if(this.hp <= 0){
			this.battleTempGenerator.CountDeadMonster();
			Destroy(this.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other){

		// 前進していたとき、敵と衝突したら攻撃に移る
		if (!this.isFacingEnemy){

			// 遠距離攻撃キャラの攻撃用コライダは、ぶつかってもスル―
			if (other.gameObject.tag == CharaStatusConst.AttackTag) return;

			// 衝突したキャラを設定する
			RamifySettingFightingChara(other);
		}
	}

	void OnTriggerExit2D(Collider2D other){
        this.isFacingEnemy = false;
        this.isMoving = true;
	}

	/// <summary>
	/// 攻撃処理を分岐させる。
	/// </summary>
	private void RamifyAttacking() {

		if (this.playerType == CharaMonsterNoConst.FighterANo) {
			this.fighterController.hp -= this.power;
			this.fighterController.DisplayDamageUI(this.power);

			Debug.Log("SlimeController - this.fighterAController.hp = " + this.fighterController.hp);
		}
		else if (this.playerType == CharaMonsterNoConst.WitchANo) {
			this.simpleWitchController.hp -= this.power;
			this.simpleWitchController.DisplayDamageUI(this.power);

			Debug.Log("SlimeController - this.witchAController.hp = " + this.simpleWitchController.hp);
		}
		else if (this.playerType == CharaMonsterNoConst.HealerANo) {
			this.simpleHealerController.hp -= this.power;
			this.simpleHealerController.DisplayDamageUI(this.power);

			Debug.Log("SlimeController - this.simpleHealerController.hp = " + this.simpleHealerController.hp);
		}
		else if (this.playerType == CharaMonsterNoConst.HealerBNo) {
			this.totalHealerController.hp -= this.power;
			this.totalHealerController.DisplayDamageUI(this.power);

			Debug.Log("SlimeController - this.totalHealerController.hp = " + this.totalHealerController.hp);
		}
		else if (this.playerType == CharaMonsterNoConst.HealerCNo) {
			this.broadHealerController.hp -= this.power;
			this.broadHealerController.DisplayDamageUI(this.power);

			Debug.Log("SlimeController - this.broadHealerController.hp = " + this.broadHealerController.hp);
		}
		else if (this.playerType == CharaMonsterNoConst.ShipNo) {
			this.shipSc.hp -= this.power;
			this.shipSc.DamageUI(this.power);

			Debug.Log("SlimeController - this.shipSc.hp = " + this.shipSc.hp);
		}
	}

	/// <summary>
	/// 衝突したキャラごとに処理を分岐させる。
	/// </summary>
	/// <param name="other">衝突コライダ</param>
	private void RamifySettingFightingChara(Collider2D other) {

		if (other.gameObject.tag == CharaStatusConst.FighterATag) {
			this.fighterController = SetFightingChara<FighterController>(CharaMonsterNoConst.FighterANo, other);
		}
		else if (other.gameObject.tag == CharaStatusConst.WitchATag) {
			this.simpleWitchController = SetFightingChara<SimpleWitchController>(CharaMonsterNoConst.WitchANo, other);
		}
		else if (other.gameObject.tag == CharaStatusConst.HealerATag) {
			this.simpleHealerController = SetFightingChara<SimpleHealerController>(CharaMonsterNoConst.HealerANo, other);
		}
		else if (other.gameObject.tag == CharaStatusConst.HealerBTag) {
			this.totalHealerController = SetFightingChara<TotalHealerController>(CharaMonsterNoConst.HealerBNo, other);
		}
		else if (other.gameObject.tag == CharaStatusConst.HealerCTag) {
			this.broadHealerController = SetFightingChara<BroadHealerController>(CharaMonsterNoConst.HealerCNo, other);
		}
		else if (other.gameObject.tag == CharaStatusConst.ShipTag) {
			SetFightingChara<CharaController>(CharaMonsterNoConst.ShipNo, other);
		}
	}

	/// <summary>
	/// 衝突したキャラを設定する。
	/// </summary>
	/// <typeparam name="T">キャラコントローラー</typeparam>
	/// <param name="playerType">キャラタイプ（番号）</param>
	/// <param name="other">衝突コライダ</param>
	/// <returns>キャラコントローラーの子インスタンス</returns>
	private T SetFightingChara<T>(int playerType, Collider2D other)
		where T : CharaController {

		this.isFacingEnemy = true;
		this.isMoving = false;
		this.playerType = playerType;

		return other.gameObject.GetComponent<T>();
	}
	
    /// <summary>
    /// 自分の受けたダメージを表示する。
    /// </summary>
    /// <param name="damage">ダメージ量</param>
	public void DisplayDamageUI(float damage){
		damageUIScript damageUISc = this.damageUI.GetComponent<damageUIScript>();
        GameObject damageText = Instantiate(this.damageUI) as GameObject;

        damageUISc.damage = damage;
		damageText.transform.position = new Vector2(
            this.transform.position.x - 0.3f, this.transform.position.y + 1.3f);
	}
}