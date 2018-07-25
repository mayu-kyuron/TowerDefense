using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウィッチ（遠距離単体攻撃タイプ）の攻撃用コントローラー
/// </summary>
public class SimpleWitchAttackController : AttackerController {
	
	private SimpleWitchController simpleWitchController;

	protected override void Awake() {

		// 親のタグ名からキャラを判断し、ステータスを取得する。
		Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[transform.root.gameObject.tag];

		this.power = thisCharaStatusMap[CharaStatusConst.PowerKey];
		this.timeToAttack = thisCharaStatusMap[CharaStatusConst.TimeToAttackKey];
	}

	protected override void Start() {
		base.Start();
		this.simpleWitchController = transform.root.gameObject.GetComponent<SimpleWitchController>();
	}

	protected override void AddCharaToMap() {

		// 自分の名前をキーに、攻撃力を登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaPowerToMap(this.charaObjectName, this.power);
	}

	protected override void Update () {
		Action();
	}

	/// <summary>
	/// 衝突したモンスターを設定する。
	/// </summary>
	/// <typeparam name="T">モンスターコントローラー</typeparam>
	/// <param name="monsterKind">モンスター種類</param>
	/// <param name="other">衝突コライダ</param>
	/// <returns>モンスターコントローラーの子インスタンス</returns>
	protected override T SetFightingMonster<T>(string monsterKind, Collider2D other) {

		this.isFacingEnemy = true;
		this.simpleWitchController.isMoving = false;
		this.monsterKind = monsterKind;

		return other.gameObject.GetComponent<T>();
	}

	protected override void OnTriggerExit2D(Collider2D other){
		this.isFacingEnemy = false;
		this.simpleWitchController.isMoving = true;
	}
}