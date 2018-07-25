using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ヒーラー（単体回復タイプ）のコントローラー
/// </summary>
public class SimpleHealerController : HealerController {

	protected override Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap) {

		// 登場キャラ中で最もHPの減っているオブジェクト名を取得する。
		var lowHpObjectName = "";
		bool isFirst = true;
		foreach (string objectName in currentHpMap.Keys) {

			if (isFirst) {
				lowHpObjectName = objectName;
				isFirst = false;
			}
			else {
				if (currentHpMap[objectName] < currentHpMap[lowHpObjectName]) {
					float maxHp = this.charaStatusConst.CharaStatusMap[GameObject.Find(objectName).tag][CharaStatusConst.HpKey];
					if (currentHpMap[objectName] != maxHp) lowHpObjectName = objectName;
				}
			}
		}
		
		string lowHpCharaName = GetCharaMonsterName(lowHpObjectName);

		return new Dictionary<string, string>() { { lowHpObjectName, lowHpCharaName } };
	}
}