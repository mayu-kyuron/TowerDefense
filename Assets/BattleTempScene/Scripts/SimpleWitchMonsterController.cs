using UnityEngine;

/// <summary>
/// ウィッチ（遠距離単体攻撃タイプ）モンスターのコントローラー
/// </summary>
public class SimpleWitchMonsterController : AttackerMonsterController {

	protected override void Update() {
		SetCurrentHp();
		GoAhead();
		Disappear();
	}

	// 遠距離攻撃キャラはAttackコントローラーで当たり判定する。
	protected override void OnTriggerStay2D(Collider2D other) {
	}

	// 遠距離攻撃キャラはAttackコントローラーで当たり判定する。
	protected override void OnTriggerExit2D(Collider2D other) {
	}
}
