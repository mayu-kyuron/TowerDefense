using System.Collections.Generic;

/// <summary>
/// 攻撃アップサポーターコントローラー
/// </summary>
public class PowerSupporterController : SupporterController {

	protected override Dictionary<string, float> GetCurrentCharaStatusMap() {
		return this.currentStatusVariables.CurrentCharaPowerMap;
	}

	protected override List<string> GetSkipCharaNameList() {
		return null;
	}

	protected override void SetCurrentCharaStatusMap(Dictionary<string, float> charaStatusMap) {
		this.currentStatusVariables.SetCurrentCharaPowerMap(charaStatusMap);
	}
}