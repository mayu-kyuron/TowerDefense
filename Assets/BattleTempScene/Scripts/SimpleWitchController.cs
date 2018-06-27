using UnityEngine;

/// <summary>
/// ウィッチ（遠距離単体攻撃タイプ）のコントローラー
/// </summary>
public class SimpleWitchController : AttackerController {

	protected override void Update() {
		GoAhead();
		Disappear();
	}

	// 遠距離攻撃キャラはAttackコントローラーで当たり判定する。
	protected override void OnTriggerStay2D(Collider2D other){
	}

	// 遠距離攻撃キャラはAttackコントローラーで当たり判定する。
	protected override void OnTriggerExit2D(Collider2D other){
	}

	protected override void GoAhead() {
		if (this.isMoving && this.transform.position.x < -1) this.transform.Translate(this.speedToMove, 0, 0);
	}
}