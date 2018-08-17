using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 召喚ボタンUIのコントローラー
/// </summary>
public class SummonButtonController : MonoBehaviour {

	private const int BtnNameLetterNum = 12; // "SummonButton1"など。最後の数字は除く。

	//オブジェクトの登録
    public GameObject callUI;
    public GameObject notCall;
	
	private List<int> charaNumList;
	private int charaNum;
	private int charaEnergy;
	private EnergyNumController energyNumController;
	private CharaStatusConst charaStatusConst = new CharaStatusConst();
	private int energyNumTheRest;

	void Start () {
		this.energyNumController = GameObject.Find("EnergyNumText").GetComponent<EnergyNumController>();

		int buttonNum = int.Parse(this.gameObject.name.Substring(BtnNameLetterNum));
        // 仮にプレイヤー選択キャラを設定
        this.charaNumList = new List<int>() { 1, 11, 5, 6, 12 };
        this.charaNum = this.charaNumList[buttonNum - 1];

		RamifySetEnergy();
	}

	void Update () {
		// 残りエネルギーを取得
		if(this.charaNum != 0) this.energyNumTheRest = this.energyNumController.EnergyNum;
	}

	public void OnClick() {

		if (this.charaNum == 0){
			GameObject notCallIns = Instantiate(this.notCall) as GameObject;
		}
		else{
			if(this.energyNumTheRest < this.charaEnergy){
				GameObject callUIIns = Instantiate(this.callUI) as GameObject;
			}
            // 残エネルギーがあったら、キャラクターを出す
            else if (this.energyNumTheRest >= this.charaEnergy){
				BattleTempGenerator battleTempGenerator
					= GameObject.Find("BattleTempGenerator").GetComponent<BattleTempGenerator>();

                battleTempGenerator.GenerateChara(this.charaNum);
                this.energyNumController.DecreaseEnergy(this.charaEnergy);
			}
		}
	}

	/// <summary>
	/// 召喚エネルギーの設定処理を分岐させる。
	/// </summary>
	private void RamifySetEnergy() {
		
		if (this.charaNum == CharaMonsterNoConst.FighterANo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.FighterATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.WitchANo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.WitchATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.WitchBNo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.WitchBTag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.HealerANo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.HealerATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.HealerBNo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.HealerBTag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.HealerCNo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.HealerCTag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.SupporterANo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.SupporterATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		else if (this.charaNum == CharaMonsterNoConst.SupporterBNo) {
			Dictionary<string, float> thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[CharaStatusConst.SupporterBTag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
	}
}