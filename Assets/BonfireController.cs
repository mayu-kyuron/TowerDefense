using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Novel;

public class BonfireController : MonoBehaviour {
    
    private double stageNum;

    // Use this for initialization
    void Start () {

        //stageNum = 11;
        this.stageNum = double.Parse(StatusManager.variable.get("stage.number"));

        if (MapGenerator.IsDecimal(this.stageNum))
        {
            this.stageNum += 0.5;
        }
        else
        {
            this.stageNum++;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    // クリックされたらジョーカースクリプトへ
    private void OnClick()
    {
        StatusManager.variable.set("stage.number", this.stageNum.ToString());

        NovelSingleton.StatusManager.callJoker("wide/material", "");
    }
}
