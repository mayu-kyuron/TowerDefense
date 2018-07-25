using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 攻撃系キャラのコントローラー
/// </summary>
public abstract class AttackerController : CharaController {

	float rotateCount = 0.5f;

	protected override void AddCharaToMap() {

		// 自分の名前をキーに、HPと攻撃力を登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaHpToMap(this.charaObjectName, this.hp);
		this.currentStatusVariables.AddCharaPowerToMap(this.charaObjectName, this.power);
	}

	protected override void Action() {

		// サポーターによって攻撃力がアップしていた場合、その値を反映する。
		Dictionary<string, float> currentPowerMap = this.currentStatusVariables.CurrentCharaPowerMap;
		this.power = currentPowerMap[this.charaObjectName];

		if (this.isFacingEnemy) {
			this.time += Time.deltaTime;

			//if (this.rotateCount < 31) this.transform.rotation = Quaternion.Euler(0, 0, rotateCount);
			//this.rotateCount += 0.5f;

			// 攻撃する
			if (this.time >= this.timeToAttack) {
				this.time = 0;

				//this.transform.rotation = Quaternion.Euler(0, 0, rotateCount * -2);

				AttackToEnemy();

				//this.transform.rotation = Quaternion.Euler(0, 0, rotateCount);

				//this.rotateCount = 0.5f;
			}
		}
	}

	/// <summary>
	/// 敵を攻撃する。
	/// </summary>
	protected virtual void AttackToEnemy() {

		Debug.Log(this.charaObjectName + " - this.power = " + this.power);

		if (this.monsterKind == MonsterStatusConst.FighterMonsterKind) {
			this.fighterMonsterController.hp -= this.power;
			this.fighterMonsterController.DisplayDamageUI(this.power);

			Debug.Log(this.charaObjectName + " - this.fighterMonsterController.hp = " + this.fighterMonsterController.hp);
		}
		else if (this.monsterKind == MonsterStatusConst.SimpleWitchMonsterKind) {
			this.simpleWitchMonsterController.hp -= this.power;
			this.simpleWitchMonsterController.DisplayDamageUI(this.power);
			
			Debug.Log(this.charaObjectName + " - this.simpleWitchMonsterController.hp = " + this.simpleWitchMonsterController.hp);
		}
		else if (this.monsterKind == MonsterStatusConst.BroadWitchMonsterKind) {
			this.broadWitchMonsterController.hp -= this.power;
			this.broadWitchMonsterController.DisplayDamageUI(this.power);

			Debug.Log(this.charaObjectName + " - this.broadWitchMonsterController.hp = " + this.broadWitchMonsterController.hp);
		}
		else if (this.monsterKind == MonsterStatusConst.SimpleHealerMonsterKind) {
			this.simpleHealerMonsterController.hp -= this.power;
			this.simpleHealerMonsterController.DisplayDamageUI(this.power);

			Debug.Log(this.charaObjectName + " - this.simpleHealerMonsterController.hp = " + this.simpleHealerMonsterController.hp);
		}
	}
}