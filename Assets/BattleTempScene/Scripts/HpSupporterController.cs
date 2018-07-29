using System.Collections.Generic;

/// <summary>
/// HPアップサポーターコントローラー
/// </summary>
public class HpSupporterController : SupporterController {

	protected override Dictionary<string, float> GetCurrentCharaStatusMap() {
		return this.currentStatusVariables.CurrentCharaMaxHpMap;
	}

	protected override List<string> GetSkipCharaNameList() {
		return new List<string>() { this.charaObjectName };
	}

	protected override void SetCurrentCharaStatusMap(Dictionary<string, float> charaStatusMap) {
		this.currentStatusVariables.SetCurrentCharaMaxHpMap(charaStatusMap);
	}
}