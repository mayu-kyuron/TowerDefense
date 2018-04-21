using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageBtn1Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var toggle = this.GetComponent<Toggle>();

        if ((object[])GlobalObject.getInstance().Params == null)
        {
            toggle.isOn = true;
        }
        else
        {
            if ((object)GlobalObject.getInstance().Params[1] == null)
            {
                toggle.isOn = true;
            }
            else
            {
                SettingObject settingObjectFromOthers = (SettingObject)GlobalObject.getInstance().Params[1];
                if (settingObjectFromOthers.DamageNum == 1)
                {
                    toggle.isOn = true;
                }
            }
        }
        toggle.onValueChanged.AddListener(this.OnValueChanged);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged(bool value)
    {
        if (value)
        {
            GameObject settingGenerator = GameObject.Find("SettingGenerator");
            GameObject settingObject = settingGenerator.GetComponent<SettingGenerator>().settingObject;
            
            settingObject.GetComponent<SettingObject>().SetDamageNum(1);
        }
    }
}
