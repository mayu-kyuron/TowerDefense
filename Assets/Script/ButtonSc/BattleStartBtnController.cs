using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleStartBtnController : MonoBehaviour
{
    public GameObject charaHyozi;

    private GameObject cautionText;
    private Charahyozi charaHyoziScript;

    // Use this for initialization
    void Start()
    {
        this.cautionText = GameObject.Find("CautionText");
        this.charaHyoziScript = charaHyozi.GetComponent<Charahyozi>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // キャラクターが選択されているかをチェック
        if (!this.charaHyoziScript.selectedAnyChara)
        {
            this.cautionText.GetComponent<Text>().text = "1人以上のキャラクターを選択してください！";
            return;
        }

        Dictionary<int, Sprite> spriteNumMap = this.charaHyoziScript.spriteNumMap;

        // 選択されたキャラクターの番号（0〜11）をリストに格納
        var charaNumList = new List<int>();
        for (int i = 0; i < this.charaHyoziScript.emptyImages.Length; i++)
        {
            Sprite emptySprite = this.charaHyoziScript.emptyImages[i].sprite;

            if (spriteNumMap.ContainsValue(emptySprite))
            {
                charaNumList.Add(spriteNumMap.First(x => x.Value == emptySprite).Key);
            }
        }

        foreach (int charaNum in charaNumList) Debug.Log("BattleStartBtnController - charaNum = " + charaNum);

        // 引数に①ステージ番号と②SettingObjectインスタンスを渡してシーン遷移
        //GlobalObject.LoadLevelWithParams("Map",
        //    stageNum.ToString() + " from StatusSetting",
        //    (settingObject == null ? null : settingObject.GetComponent<SettingObject>()));
    }
}