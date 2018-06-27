using System.Collections.Generic;
using UnityEngine;

public class SummonButtonController : MonoBehaviour {

	private const int BtnNameLetterNum = 12; // "SummonButton1"など。最後の数字は除く。

	//オブジェクトの登録
    public GameObject callUI;
    public GameObject notCall;
	
	private List<int> charaNumList;
	private int charaNum;
	private int charaEnergy;
	private EnergyNumController energyNumController;
	private int energyNumTheRest;

	void Start () {
		this.energyNumController = GameObject.Find("EnergyNumText").GetComponent<EnergyNumController>();

        int buttonNum = int.Parse(this.gameObject.name.Substring(BtnNameLetterNum));
        // 仮にプレイヤー選択キャラを設定
        this.charaNumList = new List<int>() { 1, 4, 6, 7, 8 };
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

		//ファイター1
		if (this.charaNum == CharaMonsterNoConst.FighterANo) {
			Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[CharaStatusConst.FighterATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		//ウィッチ1
		else if (this.charaNum == CharaMonsterNoConst.WitchANo) {
			Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[CharaStatusConst.WitchATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		//ヒーラー1
		else if (this.charaNum == CharaMonsterNoConst.HealerANo) {
			Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[CharaStatusConst.HealerATag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		//ヒーラー2
		else if (this.charaNum == CharaMonsterNoConst.HealerBNo) {
			Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[CharaStatusConst.HealerBTag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
		//ヒーラー3
		else if (this.charaNum == CharaMonsterNoConst.HealerCNo) {
			Dictionary<string, float> thisCharaStatusMap = new CharaStatusConst().CharaStatusMap[CharaStatusConst.HealerCTag];
			this.charaEnergy = (int)thisCharaStatusMap[CharaStatusConst.EnergyNeededKey];
		}
	}
}