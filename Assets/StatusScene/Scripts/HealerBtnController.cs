using UnityEngine;

/// <summary>
/// ヒーラーボタンのコントローラー
/// </summary>
public class HealerBtnController : MonoBehaviour {
    
    private GameObject statusGenerator;
    private GameObject characterSetter;

    // Use this for initialization
    void Start() {
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.characterSetter = GameObject.Find("CharacterSetter");
    }

    // Update is called once per frame
    void Update() {

    }

	public void OnClick() {
        int charaNum;

        double stageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().StageNum;

        // キャラクターの人数判断
        if (stageNum < StatusSceneConst.Healer2peopleStageNum) {
            charaNum = 1;
        }
        //else if (stageNum < StatusSceneConst.Healer3peopleStageNum)
		else {
            charaNum = 2;
        }
        //else {
        //    charaNum = 3;
        //}

        this.characterSetter.GetComponent<CharacterSetter>().SetHealerA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(3);
    }
}