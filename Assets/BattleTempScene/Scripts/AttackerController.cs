using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// 攻撃系キャラのコントローラー
/// </summary>
public class AttackerController : CharaController {

	float rotateCount = 0.5f;

	protected override void Action() {

		if (this.isFacingEnemy) {
			this.time += Time.deltaTime;

			//if (this.rotateCount < 31) this.transform.rotation = Quaternion.Euler(0, 0, rotateCount);
			//this.rotateCount += 0.5f;

			// 攻撃する
			if (this.time >= this.timeToAttack) {
				this.time = 0;

				//this.transform.rotation = Quaternion.Euler(0, 0, rotateCount * -2);

				if (this.monsterType == CharaMonsterNoConst.SlimeNo) {
					this.enemyFighterController.hp -= this.power;
					this.enemyFighterController.DisplayDamageUI(this.power);

					Debug.Log("AttackerController - this.slimeController.hp = " + this.enemyFighterController.hp);
				}
				else if (this.monsterType == CharaMonsterNoConst.GaitherNo) {
					this.gaitherSc.hp -= this.power;
					this.gaitherSc.DamageUI(this.power);
				}

				//this.transform.rotation = Quaternion.Euler(0, 0, rotateCount);

				//this.rotateCount = 0.5f;
			}
		}
	}
}