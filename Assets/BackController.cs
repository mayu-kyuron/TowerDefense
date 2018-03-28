using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour {

    private double stageNum;

    // Use this for initialization
    void Start () {

        //this.stageNum = 1;
        stageNum = double.Parse(GlobalObject.getInstance().StringParam);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnClick()
    {
        GlobalObject.LoadLevelWithString("Map", this.stageNum.ToString());
    }
}
