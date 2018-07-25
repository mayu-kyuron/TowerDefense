using UnityEngine;

/// <summary>
/// 攻撃系モンスターのコントローラー
/// </summary>
public abstract class AttackerMonsterController : MonsterController {

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

		Debug.Log(this.monsterObjectName + " - this.power = " + this.power);

		if (this.charaKind == CharaStatusConst.FighterKind) {
			this.fighterController.hp -= this.power;
			this.fighterController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.fighterController.hp = " + this.fighterController.hp);
		}
		else if (this.charaKind == CharaStatusConst.SimpleWitchKind) {
			this.simpleWitchController.hp -= this.power;
			this.simpleWitchController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.simpleWitchController.hp = " + this.simpleWitchController.hp);
		}
		else if (this.charaKind == CharaStatusConst.BroadWitchKind) {
			this.broadWitchController.hp -= this.power;
			this.broadWitchController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.broadWitchController.hp = " + this.broadWitchController.hp);
		}
		else if (this.charaKind == CharaStatusConst.SimpleHealerKind) {
			this.simpleHealerController.hp -= this.power;
			this.simpleHealerController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.simpleHealerController.hp = " + this.simpleHealerController.hp);
		}
		else if (this.charaKind == CharaStatusConst.TotalHealerKind) {
			this.totalHealerController.hp -= this.power;
			this.totalHealerController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.totalHealerController.hp = " + this.totalHealerController.hp);
		}
		else if (this.charaKind == CharaStatusConst.BroadHealerKind) {
			this.broadHealerController.hp -= this.power;
			this.broadHealerController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.broadHealerController.hp = " + this.broadHealerController.hp);
		}
		else if (this.charaKind == CharaStatusConst.PowerSupporterKind) {
			this.powerSupporterController.hp -= this.power;
			this.powerSupporterController.DisplayDamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.powerSupporterController.hp = " + this.powerSupporterController.hp);
		}
		else if (this.charaKind == CharaStatusConst.ShipTag) {
			this.shipSc.hp -= this.power;
			this.shipSc.DamageUI(this.power);

			Debug.Log(this.monsterObjectName + " - this.shipSc.hp = " + this.shipSc.hp);
		}
	}
}
