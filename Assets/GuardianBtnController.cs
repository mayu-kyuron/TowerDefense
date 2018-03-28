using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardianBtnController : MonoBehaviour {

    private double stageNum;
    private GameObject statusGenerator;
    private GameObject characterSetter;

    // Use this for initialization
    void Start()
    {
        //this.stageNum = 9;
        this.stageNum = double.Parse(GlobalObject.getInstance().StringParam);
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

        // キャラクターの人数判断
        if (this.stageNum < Consts.Guardian2peopleStageNum)
        {
            charaNum = 1;
        }
        else
        {
            charaNum = 2;
        }

        this.characterSetter.GetComponent<CharacterSetter>().SetGuardianA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(4);
    }
}
