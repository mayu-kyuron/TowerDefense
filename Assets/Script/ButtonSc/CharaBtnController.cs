using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaBtnController : MonoBehaviour {

    private GameObject cautionText;
    private Charahyozi charaHyozi;
    private SelectBtnController[] selectBtnControllers = new SelectBtnController[5];
	private bool selected = false;
	
	// Use this for initialization
	void Start () {
        this.cautionText = GameObject.Find("CautionText");
		this.charaHyozi = GameObject.Find("Charahyozi").GetComponent<Charahyozi>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 選択ボタンのスクリプトをフィールドに設定する。
    /// </summary>
    public void SetSelectBtnControllers()
    {
        for (int i = 0; i < this.selectBtnControllers.Length; i++)
        {
            var instanceName = String.Format("selectBtnInstance{0}", i + 1);
            this.selectBtnControllers[i] = GameObject.Find(instanceName).GetComponent<SelectBtnController>();
        }
    }

    public void OnClick()
    {
        // 選択ボタンが押されているかをチェック
        foreach (SelectBtnController selectBtnController in this.selectBtnControllers)
        {
            if (selectBtnController.selected)
            {
                this.selected = true;
                break;
            }
        }
		
		if(this.selected)
        {
            // どのキャラクターが選択されたか特定
            for (int i = 0; i < 13; i++)
            {
                if (this.gameObject.name == String.Format("charaBtnInstance{0}", i + 1))
                {
                    charaHyozi.DisplayCharaAtSelectedArea(i);
                    break;
                }
            }
		}
        // 選択ボタン未選択
        else
        {
            this.cautionText.GetComponent<Text>().text = "選択ボタンを押してください！";
        }

        this.selected = false;
	}
}
