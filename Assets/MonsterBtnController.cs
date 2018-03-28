﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBtnController : MonoBehaviour {

    public Sprite monsterASprite;

    private double stageNum;
    private GameObject charaPrefab;
    private GameObject explanationPrefab;
    private GameObject statusPrefab;
    private GameObject pageNumPrefab;
    private GameObject statusGenerator;

    // Use this for initialization
    void Start()
    {
        //this.stageNum = 9;
        this.stageNum = double.Parse(GlobalObject.getInstance().StringParam);
        this.charaPrefab = GameObject.Find("charaPrefab(Clone)");
        this.explanationPrefab = GameObject.Find("explanationPrefab(Clone)");
        this.statusPrefab = GameObject.Find("statusPrefab(Clone)");
        this.pageNumPrefab = GameObject.Find("pageNumPrefab(Clone)");
        this.statusGenerator = GameObject.Find("StatusGenerator");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnClick()
    {
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaTypeNum(6);
        this.statusGenerator.GetComponent<StatusGenerator>().variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        charaPrefab.GetComponent<Image>().sprite = monsterASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.MonsterAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.MonsterAStatus;

        //if (this.stageNum < Consts.Healer2peopleStageNum)
        //{
        //    this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText;
        //}
        //else if (this.stageNum < Consts.Healer3peopleStageNum)
        //{
        //    this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText;
        //}
        //else
        //{
        //    this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText;
        //}
    }
}
