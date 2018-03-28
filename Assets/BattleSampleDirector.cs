using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;
using System;

public class BattleSampleDirector : MonoBehaviour {

    // 全ステージ数
    private const double AllStageNum = 12;
    // マップ前にジョーカースクリプト（後ストーリー）に飛ぶステージ
    private readonly double[] StageNumsPlusHalf = { 2, 3, 4, 6, 8, 10 };

    private double stageNum;

    // Use this for initialization
    void Start () {

        // ジョーカースクリプト（前ストーリー）からステージナンバーを受け取る
        this.stageNum = double.Parse(StatusManager.variable.get("stage.number"));

        // 後ストーリーのあるものはジョーカースクリプトへ
        if (Array.IndexOf(StageNumsPlusHalf, this.stageNum) >= 0)
        {
            this.stageNum += 0.5;

            StatusManager.variable.set("stage.number", this.stageNum.ToString());
            NovelSingleton.StatusManager.callJoker("wide/material", "");
        }
        // 最終ステージだったらエンディングへ
        else if (this.stageNum == AllStageNum)
        {
            this.stageNum = -1;

            StatusManager.variable.set("stage.number", this.stageNum.ToString());
            NovelSingleton.StatusManager.callJoker("wide/material", "");
        }
        // それ以外はマップへ
        else
        {
            this.stageNum++;
            GlobalObject.LoadLevelWithString("Map", this.stageNum.ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
