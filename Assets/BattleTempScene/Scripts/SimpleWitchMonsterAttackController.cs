using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ウィッチ（遠距離単体攻撃タイプ）モンスターの攻撃用コントローラー
/// </summary>
public class SimpleWitchMonsterAttackController : AttackerMonsterController {

	private SimpleWitchMonsterController simpleWitchMonsterController;

	protected override void Awake() {

		// 親のタグ名からモンスターを判断し、ステータスを取得する。
		Dictionary<string, float> thisMonsterStatusMap = this.monsterStatusConst.MonsterStatusMap[transform.root.gameObject.tag];

		this.power = thisMonsterStatusMap[MonsterStatusConst.PowerKey];
		this.timeToAttack = thisMonsterStatusMap[MonsterStatusConst.TimeToAttackKey];
	}

	protected override void Start() {
		base.Start();
		this.simpleWitchMonsterController = transform.root.gameObject.GetComponent<SimpleWitchMonsterController>();
	}

	protected override void Update() {
		Action();
	}

	/// <summary>
	/// 衝突したキャラを設定する。
	/// </summary>
	/// <typeparam name="T">キャラコントローラー</typeparam>
	/// <param name="charaKind">キャラ種類</param>
	/// <param name="other">衝突コライダ</param>
	/// <returns>キャラコントローラーの子インスタンス</returns>
	protected override T SetFightingChara<T>(string charaKind, Collider2D other) {

		this.isFacingEnemy = true;
		this.simpleWitchMonsterController.isMoving = false;
		this.charaKind = charaKind;

		return other.gameObject.GetComponent<T>();
	}

	protected override void OnTriggerExit2D(Collider2D other) {
		this.isFacingEnemy = false;
		this.simpleWitchMonsterController.isMoving = true;
	}
}