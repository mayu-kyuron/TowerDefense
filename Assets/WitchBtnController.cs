﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchBtnController : MonoBehaviour {
    
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
        if (stageNum < Consts.Witch2peopleStageNum)
        {
            charaNum = 1;
        }
        else
        {
            charaNum = 2;
        }

        this.characterSetter.GetComponent<CharacterSetter>().SetWitchA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(2);
    }
}
