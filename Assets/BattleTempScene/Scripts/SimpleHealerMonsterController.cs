using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ヒーラー（単体回復タイプ）モンスターのコントローラー
/// </summary>
public class SimpleHealerMonsterController : HealerMonsterController {

	protected override Dictionary<string, string> GetMonsterNameKindMap(Dictionary<string, float> currentHpMap) {

		// 登場モンスター中で最もHPの減っているオブジェクト名を取得する。
		var lowHpObjectName = "";
		bool isFirst = true;
		foreach (string objectName in currentHpMap.Keys) {

			if (isFirst) {
				lowHpObjectName = objectName;
				isFirst = false;
			}
			else {
				if (currentHpMap[objectName] < currentHpMap[lowHpObjectName]) {
					float maxHp = this.monsterStatusConst.MonsterStatusMap[GameObject.Find(objectName).tag][MonsterStatusConst.HpKey];
					if (currentHpMap[objectName] != maxHp) lowHpObjectName = objectName;
				}
			}
		}

		string lowHpMonsterName = GetCharaMonsterName(lowHpObjectName);

		return new Dictionary<string, string>() { { lowHpObjectName, lowHpMonsterName } };
	}
}
