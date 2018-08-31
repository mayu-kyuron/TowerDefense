using System.Collections.Generic;

/// <summary>
/// HPアップサポーターコントローラー
/// </summary>
public class HpSupporterController : SupporterController {

	protected override Dictionary<int, Dictionary<string, float>> GetCurrentCharaStatusMaps() {

		return new Dictionary<int, Dictionary<string, float>> {
			{ CurrentStatusVariables.CharaMaxHpMapNo, this.currentStatusVariables.CurrentCharaMaxHpMap },
			{ CurrentStatusVariables.CharaHpMapNo, this.currentStatusVariables.CurrentCharaHpMap }
		};
	}

	protected override List<string> GetSkipCharaNameList() {
		return new List<string>() { this.charaObjectName, CharaStatusConst.ShipName };
	}

	protected override void SetCurrentCharaStatusMap(int mapNo, Dictionary<string, float> charaStatusMap) {

		if (mapNo == CurrentStatusVariables.CharaMaxHpMapNo) {
			this.currentStatusVariables.SetCurrentCharaMaxHpMap(charaStatusMap);
		}
		else if (mapNo == CurrentStatusVariables.CharaHpMapNo) {
			this.currentStatusVariables.SetCurrentCharaHpMap(charaStatusMap);
		}
	}
}