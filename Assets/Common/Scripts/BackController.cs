using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackController : MonoBehaviour {
    
    private GameObject statusGenerator;
    private GameObject settingGenerator;

    // Use this for initialization
    void Start () {
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.settingGenerator = GameObject.Find("SettingGenerator");
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnClick()
    {
        double stageNum = 0;
        GameObject settingObject = null;
        if (this.statusGenerator != null)
        {
            stageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().StageNum;
            settingObject = this.statusGenerator.GetComponent<StatusGenerator>().settingObject;
        }
        else if (this.settingGenerator != null)
        {
            stageNum = this.settingGenerator.GetComponent<SettingGenerator>()
            .variables.GetComponent<Variables>().StageNum;
            settingObject = this.settingGenerator.GetComponent<SettingGenerator>().settingObject;
        }

        // 引数に①ステージ番号と②SettingObjectインスタンスを渡してシーン遷移
        GlobalObject.LoadLevelWithParams("Map",
            stageNum.ToString() + " from StatusSetting",
            (settingObject == null ? null : settingObject.GetComponent<SettingObject>()));
    }
}
