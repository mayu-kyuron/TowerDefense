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

			if (objectName == CharaStatusConst.ShipTag) continue;

			var maxHp = GameObject.Find(objectName).GetComponent<CharaController>().maxHp;

			if (currentHpMap[objectName] == maxHp) continue;

			if (isFirst) {
				lowHpObjectName = objectName;
				isFirst = false;
			}
			else {
				if (currentHpMap[objectName] < currentHpMap[lowHpObjectName]) lowHpObjectName = objectName;
			}
		}
		
		string lowHpCharaName = GetCharaMonsterName(lowHpObjectName);
		Debug.Log(string.Format("{0} - lowHpObjectName = {1}", this.charaObjectName, lowHpObjectName));

		return new Dictionary<string, string>() { { lowHpObjectName, lowHpCharaName } };
	}
}