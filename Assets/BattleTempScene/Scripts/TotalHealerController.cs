using System.Collections.Generic;

/// <summary>
/// ヒーラー（全体回復タイプ）のコントローラー
/// </summary>
public class TotalHealerController : HealerController {

	protected override Dictionary<string, string> GetCharaNameKindMap(Dictionary<string, float> currentHpMap) {
		var charaNameKindMap = new Dictionary<string, string>();

		// キャラ名から種類（遠距離単体攻撃タイプなど）を特定し、マップに格納する。
		foreach (string name in currentHpMap.Keys) {

			if (name == this.gameObject.name) continue;

			for (int i = 0; i < name.Length; i++) {

				if (halfNumRegex.IsMatch(name[i].ToString())) {
					charaNameKindMap.Add(name, name.Substring(0, i));
					break;
				}
			}
		}

		return charaNameKindMap;
	}
}