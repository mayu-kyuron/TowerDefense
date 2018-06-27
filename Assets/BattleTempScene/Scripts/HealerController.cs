using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// 回復系キャラのコントローラー
/// </summary>
public abstract class HealerController : CharaController {

	// 半角数字の正規表現
	protected Regex halfNumRegex = new Regex(@"\d");

	protected override void GoAhead() {
		if (this.isMoving && this.transform.position.x < -2) this.transform.Translate(this.speedToMove, 0, 0);
	}

	protected override void Action() {
		this.time += Time.deltaTime;

		// 回復する
		if (this.time >= this.timeToAttack) {
			this.time = 0;
			Dictionary<string, string> charaNameKindMap = GetCharaNameKindMap(this.currentStatusVariables.CurrentHpMap);

			RamifyControllers(charaNameKindMap);
		}
	}

	protected abstract Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap);

	/// <summary>
	/// 回復対象キャラのコントローラーごとに処理を分岐させる。
	/// </summary>
	/// <param name="charaNameKindMap">回復対象キャラマップ（キー：名前、値：種類）</param>
	protected void RamifyControllers(Dictionary<string, string> charaNameKindMap) {
		Dictionary<string, List<string>> allCharaNamesMap = new CharaStatusConst().CharaNamesList;

		foreach (string charaName in charaNameKindMap.Keys) {

			if (allCharaNamesMap[CharaStatusConst.FighterKindName].Contains(charaNameKindMap[charaName])) {
				CureChara<FighterController>(charaName);
			}
			else if (allCharaNamesMap[CharaStatusConst.SimpleWitchKindName].Contains(charaNameKindMap[charaName])) {
				CureChara<SimpleWitchController>(charaName);
			}
			else if (allCharaNamesMap[CharaStatusConst.SimpleHealerKindName].Contains(charaNameKindMap[charaName])) {
				CureChara<SimpleHealerController>(charaName);
			}
			else if (allCharaNamesMap[CharaStatusConst.TotalHealerKindName].Contains(charaNameKindMap[charaName])) {
				CureChara<TotalHealerController>(charaName);
			}
			else if (allCharaNamesMap[CharaStatusConst.BroadHealerKindName].Contains(charaNameKindMap[charaName])) {
				CureChara<BroadHealerController>(charaName);
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
		Dictionary<string, float> charaStatusMap = new CharaStatusConst().CharaStatusMap[charaController.tag];

		Debug.Log("HealerController - " + charaName + ".hp = " + charaController.hp);

		// HPが満タンだったら、何もせずにリターン
		if (charaController.hp == charaStatusMap[CharaStatusConst.HpKey]) return;

		// HPがMAXを超えないよう、パワーを調節して回復する。
		if (charaController.hp > charaStatusMap[CharaStatusConst.HpKey] - this.power) {
			float power = charaStatusMap[CharaStatusConst.HpKey] - charaController.hp;
			charaController.hp += power;
			charaController.DisplayCureUI(power);
		}
		else {
			charaController.hp += this.power;
			charaController.DisplayCureUI(this.power);
		}

		Debug.Log("HealerController - " + charaName + ".hp = " + charaController.hp);
	}
}