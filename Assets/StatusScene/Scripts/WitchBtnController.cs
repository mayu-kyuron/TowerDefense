using UnityEngine;

/// <summary>
/// ウィッチボタンのコントローラー
/// </summary>
public class WitchBtnController : MonoBehaviour {
    
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
        if (stageNum < StatusSceneConst.Witch2peopleStageNum) {
            charaNum = 1;
        }
        else {
            charaNum = 2;
        }

        this.characterSetter.GetComponent<CharacterSetter>().SetWitchA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(2);
    }
}