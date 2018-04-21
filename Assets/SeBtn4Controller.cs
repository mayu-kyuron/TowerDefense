using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeBtn4Controller : MonoBehaviour {

    private bool firstValueChanged = true;

    // Use this for initialization
    void Start () {
        var toggle = this.GetComponent<Toggle>();

        if ((object[])GlobalObject.getInstance().Params != null
            && (object)GlobalObject.getInstance().Params[1] != null)
        {
            SettingObject settingObjectFromOthers = (SettingObject)GlobalObject.getInstance().Params[1];
            if (settingObjectFromOthers.SeNum == 4)
            {
                toggle.isOn = true;
            }
        }
        toggle.onValueChanged.AddListener(this.OnValueChanged);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged(bool value)
    {
        if (firstValueChanged)
        {
            firstValueChanged = false;
        }
        else
        {
            if (value)
            {
                GameObject settingGenerator = GameObject.Find("SettingGenerator");
                GameObject settingObject = settingGenerator.GetComponent<SettingGenerator>().settingObject;

                AudioSource seSource = Camera.main.GetComponents<AudioSource>()[1];
                seSource.volume = 0.8f;
                settingObject.GetComponent<SettingObject>().SetSeNum(4);

                seSource.Play();
            }
        }
    }
}
