using UnityEngine;

/// <summary>
/// ファイターボタンのコントローラー
/// </summary>
public class FighterBtnController : MonoBehaviour {
    
    private GameObject statusGenerator;
    private GameObject characterSetter;
	
    void Start() {
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.characterSetter = GameObject.Find("CharacterSetter");
    }
	
    void Update() {

    }

	public void OnClick() {
        int charaNum;

        double stageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().StageNum;

        // キャラクターの人数判断
        if (stageNum < StatusSceneConst.Fighter2peopleStageNum) {
            charaNum = 1;
        }
        else if (stageNum < StatusSceneConst.Fighter3peopleStageNum) {
            charaNum = 2;
        }
		else {
			charaNum = 3;
		}

		this.characterSetter.GetComponent<CharacterSetter>().SetFighterA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(1);
    }
}