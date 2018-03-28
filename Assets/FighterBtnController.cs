﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterBtnController : MonoBehaviour {

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
        if (this.stageNum < Consts.Fighter2peopleStageNum)
        {
            charaNum = 1;
        }
        else if (this.stageNum < Consts.Fighter3peopleStageNum)
        {
            charaNum = 2;
        }
        else
        {
            charaNum = 3;
        }

        this.characterSetter.GetComponent<CharacterSetter>().SetFighterA(charaNum);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(1);
    }
}
