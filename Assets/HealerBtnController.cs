using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealerBtnController : MonoBehaviour {
    
    private GameObject statusGenerator;
    private GameObject characterSetter;

    // Use this for initialization
    void Start()
    {
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.characterSetter = GameObject.Find("CharacterSetter");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnClick()
    {
        int charaNum;

        double stageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().StageNum;

        // キャラクターの人数判断
        if (stageNum < Consts.Healer2peopleStageNum)
        {
            charaNum = 1;
        }
        else if (stageNum < Consts.Healer3peopleStageNum)
        {
            charaNum = 2;
        }
        else
        {
            charaNum = 3;
        }

        this.characterSetter.GetComponent<CharacterSetter>().SetHealerA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(3);
    }
}
