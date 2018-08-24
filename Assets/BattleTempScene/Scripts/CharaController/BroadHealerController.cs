using System.Collections.Generic;

/// <summary>
/// ヒーラー（範囲回復タイプ）のコントローラー
/// </summary>
public class BroadHealerController : HealerController {

	protected override Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap) {
		var charaNameKindMap = new Dictionary<string, string>();

		// キャラ名から種類（遠距離単体攻撃タイプなど）を特定し、マップに格納する。
		foreach (string objectName in currentHpMap.Keys) {

			// 回復するのは3体まで
			if (charaNameKindMap.Count > 2) break;

			if (objectName == this.gameObject.name) continue;

			string charaName = GetCharaMonsterName(objectName);

			charaNameKindMap.Add(objectName, charaName);
		}

		return charaNameKindMap;
	}
}