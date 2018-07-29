using UnityEngine;

/// <summary>
/// ウィッチ（遠距離範囲攻撃タイプ）のコントローラー
/// </summary>
public class BroadWitchController : AttackerController {

	protected override void AddCharaToMap() {

		// 自分の名前をキーに、HPと最大HPを登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaHpToMap(this.charaObjectName, this.hp);
		this.currentStatusVariables.AddCharaMaxHpToMap(this.charaObjectName, this.maxHp);
	}

	protected override void Update() {
		SetCurrentHpAndMaxHp();
		GoAhead();
		Disappear();
	}

	// 遠距離攻撃キャラはAttackコントローラーで当たり判定する。
	protected override void OnTriggerStay2D(Collider2D other) {
	}

	// 遠距離攻撃キャラはAttackコントローラーで当たり判定する。
	protected override void OnTriggerExit2D(Collider2D other) {
	}

	protected override void GoAhead() {
		if (this.isMoving && this.transform.position.x < -1) this.transform.Translate(this.speedToMove, 0, 0);
	}
}