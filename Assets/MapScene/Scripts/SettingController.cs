using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour {

    private GameObject mapGenerator;

    // Use this for initialization
    void Start () {
        this.mapGenerator = GameObject.Find("MapGenerator");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        double stageNum = this.mapGenerator.GetComponent<MapGenerator>()
            .variables.GetComponent<Variables>().StageNum;
        GameObject settingObject = this.mapGenerator.GetComponent<MapGenerator>().settingObject;

        GlobalObject.LoadLevelWithParams("Setting",
            stageNum.ToString(),
            (settingObject == null ? null : settingObject.GetComponent<SettingObject>()));
    }
}
