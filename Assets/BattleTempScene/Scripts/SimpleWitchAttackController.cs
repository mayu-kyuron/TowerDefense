using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウィッチ（遠距離単体攻撃タイプ）コントローラー
/// </summary>
public class SimpleWitchAttackController : AttackerController {
	
	private SimpleWitchController simpleWitchController;

	protected override void Awake() {

		// 親のタグ名からキャラを判断し、ステータスを取得する。
		Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[transform.root.gameObject.tag];

		this.power = thisCharaStatusMap[CharaStatusConst.PowerKey];
		this.timeToAttack = thisCharaStatusMap[CharaStatusConst.TimeToAttackKey];
	}

	protected override void Start (){
		this.simpleWitchController = transform.root.gameObject.GetComponent<SimpleWitchController>();
	}
	
	protected override void Update () {
		Action();
	}

	protected override void OnTriggerStay2D(Collider2D other){

		// 前進していたとき、敵と衝突したら攻撃に移る
		if (!this.isFacingEnemy){

			// 遠距離攻撃キャラの攻撃用コライダは、ぶつかってもスル―
			if (other.gameObject.tag == CharaStatusConst.AttackTag) return;

			if (other.gameObject.tag == MonsterStatusConst.SlimeTag){
				this.isFacingEnemy = true;
				this.simpleWitchController.isMoving = false;
				this.enemyFighterController = other.gameObject.GetComponent<EnemyFighterController>();
				this.monsterType = CharaMonsterNoConst.SlimeNo;
			}
			else if(other.gameObject.tag == MonsterStatusConst.GaitherTag) {
				this.isFacingEnemy = true;
				this.simpleWitchController.isMoving = false;
				this.gaitherSc = other.gameObject.GetComponent<GaitherSc>();
				this.monsterType = CharaMonsterNoConst.GaitherNo;
			}
		}
	}

	protected override void OnTriggerExit2D(Collider2D other){
		this.isFacingEnemy = false;
		this.simpleWitchController.isMoving = true;
	}
}