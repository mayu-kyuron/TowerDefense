using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 回復系モンスターのコントローラー
/// </summary>
public abstract class HealerMonsterController : MonsterController {

	protected override void Action() {
		this.time += Time.deltaTime;

		// 回復する
		if (this.time >= this.timeToAttack) {
			this.time = 0;
			Dictionary<string, string> monsterNameKindMap = GetMonsterNameKindMap(this.currentStatusVariables.CurrentMonsterHpMap);

			RamifyControllers(monsterNameKindMap);
		}
	}

	protected abstract Dictionary<string, string> GetMonsterNameKindMap(Dictionary<string, float> currentHpMap);

	/// <summary>
	/// 回復対象モンスターのコントローラーごとに処理を分岐させる。
	/// </summary>
	/// <param name="monsterNameKindMap">回復対象モンスターマップ（キー：名前、値：種類）</param>
	protected void RamifyControllers(Dictionary<string, string> monsterNameKindMap) {

		foreach (string objectName in monsterNameKindMap.Keys) {

			string monsterName = monsterNameKindMap[objectName];

			if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.FighterMonsterKind].Contains(monsterName)) {
				CureMonster<FighterMonsterController>(objectName);
			}
			else if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.SimpleWitchMonsterKind].Contains(monsterName)) {
				CureMonster<SimpleWitchMonsterController>(objectName);
			}
			else if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.BroadWitchMonsterKind].Contains(monsterName)) {
				CureMonster<BroadWitchMonsterController>(objectName);
			}
			else if (this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.SimpleHealerMonsterKind].Contains(monsterName)) {
				CureMonster<SimpleHealerMonsterController>(objectName);
			}
		}
	}

	/// <summary>
	/// モンスターのHPを回復する。
	/// </summary>
	/// <typeparam name="T">モンスターコントローラー</typeparam>
	/// <param name="monsterName">回復対象モンスターの名前</param>
	protected void CureMonster<T>(string monsterName)
		where T : MonsterController {

		GameObject lowHpMonster = GameObject.Find(monsterName);

		var monsterController = lowHpMonster.GetComponent<T>();
		Dictionary<string, float> monsterStatusMap = this.monsterStatusConst.MonsterStatusMap[monsterController.tag];

		Debug.Log("HealerMonsterController - " + monsterName + ".hp = " + monsterController.hp);

		// HPが満タンだったら、何もせずにリターン
		if (monsterController.hp == monsterStatusMap[MonsterStatusConst.HpKey]) return;

		// HPがMAXを超えないよう、パワーを調節して回復する。
		if (monsterController.hp > monsterStatusMap[MonsterStatusConst.HpKey] - this.power) {
			float power = monsterStatusMap[MonsterStatusConst.HpKey] - monsterController.hp;
			monsterController.hp += power;
			monsterController.DisplayCureUI(power);
		}
		else {
			monsterController.hp += this.power;
			monsterController.DisplayCureUI(this.power);
		}

		Debug.Log("HealerMonsterController - " + monsterName + ".hp = " + monsterController.hp);
	}

    protected override void RamifySettingFightingChara(Collider2D other) {
        base.RamifySettingFightingChara(other);
        if(!this.monsterStatusConst.MonsterNameListMap[MonsterStatusConst.SimpleHealerMonsterKind].Contains(other.gameObject.tag)) this.isMoving = false;
    }
}