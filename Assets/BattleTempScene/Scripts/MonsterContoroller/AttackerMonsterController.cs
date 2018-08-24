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

                //GetComponent<AudioSource>().Play();//SEをならす

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
			this.fighterController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.fighterController.hp = " + this.fighterController.hp);
		}
		else if (this.charaKind == CharaStatusConst.SimpleWitchKind) {
			this.simpleWitchController.hp -= this.power;
			this.simpleWitchController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.simpleWitchController.hp = " + this.simpleWitchController.hp);
		}
		else if (this.charaKind == CharaStatusConst.BroadWitchKind) {
			this.broadWitchController.hp -= this.power;
			this.broadWitchController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.broadWitchController.hp = " + this.broadWitchController.hp);
		}
		else if (this.charaKind == CharaStatusConst.SimpleHealerKind) {
			this.simpleHealerController.hp -= this.power;
			this.simpleHealerController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.simpleHealerController.hp = " + this.simpleHealerController.hp);
		}
		else if (this.charaKind == CharaStatusConst.TotalHealerKind) {
			this.totalHealerController.hp -= this.power;
			this.totalHealerController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.totalHealerController.hp = " + this.totalHealerController.hp);
		}
		else if (this.charaKind == CharaStatusConst.BroadHealerKind) {
			this.broadHealerController.hp -= this.power;
			this.broadHealerController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.broadHealerController.hp = " + this.broadHealerController.hp);
		}
		else if (this.charaKind == CharaStatusConst.PowerSupporterKind) {
			this.powerSupporterController.hp -= this.power;
			this.powerSupporterController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.powerSupporterController.hp = " + this.powerSupporterController.hp);
		}
		else if (this.charaKind == CharaStatusConst.HpSupporterKind) {
			this.hpSupporterController.hp -= this.power;
			this.hpSupporterController.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.hpSupporterController.hp = " + this.hpSupporterController.hp);
		}
		else if (this.charaKind == CharaStatusConst.ShipTag) {
			this.shipSc.hp -= this.power;
			this.shipSc.Damage(this.power);

			Debug.Log(this.monsterObjectName + " - this.shipSc.hp = " + this.shipSc.hp);
		}
	}
}
