using System.Collections.Generic;

/// <summary>
/// 攻撃アップサポーターコントローラー
/// </summary>
public class PowerSupporterController : SupporterController {

	protected override Dictionary<int, Dictionary<string, float>> GetCurrentCharaStatusMaps() {

		return new Dictionary<int, Dictionary<string, float>> {
			{ CurrentStatusVariables.CharaPowerMapNo, this.currentStatusVariables.CurrentCharaPowerMap },
		};
	}

	protected override List<string> GetSkipCharaNameList() {
		return null;
	}

	protected override void SetCurrentCharaStatusMap(int mapNo, Dictionary<string, float> charaStatusMap) {
		this.currentStatusVariables.SetCurrentCharaPowerMap(charaStatusMap);
	}
}