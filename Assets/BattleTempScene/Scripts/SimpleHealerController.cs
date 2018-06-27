using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ヒーラー（単体回復タイプ）のコントローラー
/// </summary>
public class SimpleHealerController : HealerController {

	protected override Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap) {

		// 登場キャラ中で最もHPの減っているキャラ名を取得する。
		var lowHpCharaName = "";
		bool isFirst = true;
		foreach (string charaName in currentHpMap.Keys) {

			if (isFirst) {
				lowHpCharaName = charaName;
				isFirst = false;
			}
			else {
				if (currentHpMap[charaName] < currentHpMap[lowHpCharaName]) {
					float maxHp = new CharaStatusConst().CharaStatusMap[GameObject.Find(charaName).tag][CharaStatusConst.HpKey];
					if(currentHpMap[charaName] != maxHp) lowHpCharaName = charaName;
				}
			}
		}

		// キャラ名から種類（遠距離単体攻撃タイプなど）を特定する。
		int numIndex = -1;
		for (int i = 0; i < lowHpCharaName.Length; i++) {

			if(halfNumRegex.IsMatch(lowHpCharaName[i].ToString())) {
				numIndex = i;
				break;
			}
		}

		string lowHpCharaKind = null;
		if(numIndex != -1) lowHpCharaKind = lowHpCharaName.Substring(0, numIndex);

		return new Dictionary<string, string>() { { lowHpCharaName, lowHpCharaKind } };
	}
}