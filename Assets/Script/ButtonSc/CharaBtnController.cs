using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラボタンコントローラー
/// </summary>
public class CharaBtnController : MonoBehaviour {

    private GameObject cautionText;
    private Charahyozi charaHyozi;
    private SelectBtnController[] selectBtnControllers = new SelectBtnController[5];
	private AudioSource audioSource;
	private AudioSource cautionAudioSource;
	private bool selected = false;

	private Dictionary<int, int> btnNoCharaNoMap;
	
	void Start () {
        this.cautionText = GameObject.Find("CautionText");
		this.charaHyozi = GameObject.Find("Charahyozi").GetComponent<Charahyozi>();
		this.audioSource = this.gameObject.GetComponent<AudioSource>();
		this.cautionAudioSource = this.cautionText.GetComponent<AudioSource>();

		double stageNum = this.charaHyozi.GetComponent<Charahyozi>().variables.GetComponent<Variables>().StageNum;

		this.btnNoCharaNoMap = new Dictionary<int, int> {
			{ 1, CharaMonsterNoConst.FighterANo },
			{ 2, CharaMonsterNoConst.WitchANo },
			{ 3, CharaMonsterNoConst.SupporterANo },
			{ 4, CharaMonsterNoConst.HealerANo },
			{ 5, CharaMonsterNoConst.FighterBNo },
			{ 6, CharaMonsterNoConst.SupporterBNo },
			{ 7, CharaMonsterNoConst.WitchBNo },
			{ 8, CharaMonsterNoConst.FighterCNo },
			{ 9, CharaMonsterNoConst.HealerCNo },
			{ 10, CharaMonsterNoConst.NoneNo },
		};

		int seNum = this.charaHyozi.GetComponent<Charahyozi>().settingObject.GetComponent<SettingObject>().SeNum;
		this.audioSource.volume = seNum * 0.2f;
		this.cautionAudioSource.volume = seNum * 0.2f;
	}
	
	void Update () {
		
	}

    /// <summary>
    /// 選択ボタンのスクリプトをフィールドに設定する。
    /// </summary>
    public void SetSelectBtnControllers() {

        for (int i = 0; i < this.selectBtnControllers.Length; i++) {
            var instanceName = String.Format("selectBtnInstance{0}", i + 1);
            this.selectBtnControllers[i] = GameObject.Find(instanceName).GetComponent<SelectBtnController>();
        }
    }

    public void OnClick() {

        // 選択ボタンが押されているかをチェック
        foreach (SelectBtnController selectBtnController in this.selectBtnControllers) {
            if (selectBtnController.selected) {
                this.selected = true;
                break;
            }
        }
		
		if(this.selected) {
			double stageNum = this.charaHyozi.GetComponent<Charahyozi>().variables.GetComponent<Variables>().StageNum;

			// どのキャラクターが選択されたか特定
			for (int i = 1; i <= this.charaHyozi.stageNumAllCharaNumMap[(int)stageNum]; i++) {

				if(this.gameObject.name == "charaBtnInstance10") {
					charaHyozi.DisplayCharaAtSelectedArea(this.btnNoCharaNoMap[10], this.audioSource);
					break;
				}

				if (this.gameObject.name == String.Format("charaBtnInstance{0}", i)) {
                    charaHyozi.DisplayCharaAtSelectedArea(this.btnNoCharaNoMap[i], this.audioSource);
                    break;
                }
            }
		}
        // 選択ボタン未選択
        else {
			this.cautionAudioSource.PlayOneShot(this.cautionAudioSource.clip);

			this.cautionText.GetComponent<Text>().text = "選択ボタンを押してください！";
        }

        this.selected = false;
	}
}