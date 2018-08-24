using System.Collections.Generic;

/// <summary>
/// ヒーラー（全体回復タイプ）のコントローラー
/// </summary>
public class TotalHealerController : HealerController {

	protected override Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap) {
		var charaNameKindMap = new Dictionary<string, string>();

		// キャラ名から種類（遠距離単体攻撃タイプなど）を特定し、マップに格納する。
		foreach (string objectName in currentHpMap.Keys) {

			if (objectName == this.gameObject.name) continue;

			string charaName = GetCharaMonsterName(objectName);

			charaNameKindMap.Add(objectName, charaName);
		}

		return charaNameKindMap;
	}
}