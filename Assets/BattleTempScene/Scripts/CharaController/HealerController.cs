using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 回復系キャラのコントローラー
/// </summary>
public abstract class HealerController : CharaController {

	protected override void AddCharaToMap() {

		// 自分の名前をキーに、HPと最大HPを登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaHpToMap(this.charaObjectName, this.hp);
		this.currentStatusVariables.AddCharaMaxHpToMap(this.charaObjectName, this.maxHp);
	}

	protected override void GoAhead() {
		if (this.isMoving && this.transform.position.x < 5.5) this.transform.Translate(this.speedToMove, 0, 0);
	}

	protected override void Action() {
		this.time += Time.deltaTime;

		// 回復する
		if (this.time >= this.timeToAttack) {

            GetComponent<AudioSource>().Play();

            this.time = 0;
			Dictionary<string, string> charaNameKindMap = GetCharaNameKindMap(this.currentStatusVariables.CurrentCharaHpMap);

			RamifyControllers(charaNameKindMap);
		}
	}

	protected abstract Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap);

	/// <summary>
	/// 回復対象キャラのコントローラーごとに処理を分岐させる。
	/// </summary>
	/// <param name="charaNameKindMap">回復対象キャラマップ（キー：名前、値：種類）</param>
	protected void RamifyControllers(Dictionary<string, string> charaNameKindMap) {

		foreach (string objectName in charaNameKindMap.Keys) {

			string charaName = charaNameKindMap[objectName];

			if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.FighterKind].Contains(charaName)) {
				CureChara<FighterController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.SimpleWitchKind].Contains(charaName)) {
				CureChara<SimpleWitchController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.BroadWitchKind].Contains(charaName)) {
				CureChara<BroadWitchController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.SimpleHealerKind].Contains(charaName)) {
				CureChara<SimpleHealerController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.TotalHealerKind].Contains(charaName)) {
				CureChara<TotalHealerController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.BroadHealerKind].Contains(charaName)) {
				CureChara<BroadHealerController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.PowerSupporterKind].Contains(charaName)) {
				CureChara<PowerSupporterController>(objectName);
			}
			else if (this.charaStatusConst.CharaNameListMap[CharaStatusConst.HpSupporterKind].Contains(charaName)) {
				CureChara<HpSupporterController>(objectName);
			}
		}
	}

	/// <summary>
	/// キャラのHPを回復する。
	/// </summary>
	/// <typeparam name="T">キャラコントローラー</typeparam>
	/// <param name="charaName">回復対象キャラの名前</param>
	protected void CureChara<T>(string charaName)
		where T : CharaController {

		GameObject lowHpChara = GameObject.Find(charaName);
		var charaController = lowHpChara.GetComponent<T>();

		Debug.Log("HealerController - " + charaName + ".hp = " + charaController.hp);
		Debug.Log("HealerController - " + charaName + ".maxHp = " + charaController.maxHp);

		// HPが満タンだったら、何もせずにリターン
		if (charaController.hp == charaController.maxHp) return;

		// HPがMAXを超えないよう、パワーを調節して回復する。
		if (charaController.hp > charaController.maxHp - this.power) {
			float power = charaController.maxHp - charaController.hp;
			charaController.hp += power;
			charaController.DisplayCureUI(power);
		}
		else {
			charaController.hp += this.power;
			charaController.DisplayCureUI(this.power);
		}

		Debug.Log("HealerController - " + charaName + ".hp = " + charaController.hp);
		Debug.Log("HealerController - " + charaName + ".maxHp = " + charaController.maxHp);
	}

    // nameListの中身をTag名で調べており本来はよくない。が、今回はそのままにしている。
    protected override void RamifySettingFightingMonster(Collider2D other)
    {
        //Debug.Log(CharaStatusConst.ShipTag);
        base.RamifySettingFightingMonster(other);
        if (!this.charaStatusConst.CharaNameListMap[CharaStatusConst.HealerKind].Contains(other.gameObject.tag))
        {
            this.isMoving = false;
            // Debug.Log("b");
        }
    }
}