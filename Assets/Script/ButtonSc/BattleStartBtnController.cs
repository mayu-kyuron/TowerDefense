using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 戦闘開始ボタンコントローラー
/// </summary>
public class BattleStartBtnController : MonoBehaviour {

    public GameObject charaHyozi;

    private GameObject cautionText;
    private Charahyozi charaHyoziScript;
	private AudioSource audioSource;
	private AudioSource cautionAudioSource;

	void Start() {
        this.cautionText = GameObject.Find("CautionText");
        this.charaHyoziScript = charaHyozi.GetComponent<Charahyozi>();
		this.audioSource = this.gameObject.GetComponent<AudioSource>();
		this.cautionAudioSource = this.cautionText.GetComponent<AudioSource>();

		int seNum = this.charaHyozi.GetComponent<Charahyozi>().settingObject.GetComponent<SettingObject>().SeNum;
		this.audioSource.volume = seNum * 0.2f;
		this.cautionAudioSource.volume = seNum * 0.2f;
	}
	
    void Update() {

    }

    public void OnClick() {

        // キャラクターが選択されているかをチェック
        if (!this.charaHyoziScript.selectedAnyChara) {
			this.cautionAudioSource.PlayOneShot(this.cautionAudioSource.clip);

			this.cautionText.GetComponent<Text>().text = "1人以上のキャラクターを選択してください！";

			return;
        }

        Dictionary<int, Sprite> spriteNumMap = this.charaHyoziScript.spriteNumMap;

        // 選択されたキャラクターの番号（0〜11）をリストに格納
        var charaNumList = new List<int>();
        for (int i = 0; i < this.charaHyoziScript.emptyImages.Length; i++) {
            Sprite emptySprite = this.charaHyoziScript.emptyImages[i].sprite;

            if (spriteNumMap.ContainsValue(emptySprite)) {
                charaNumList.Add(spriteNumMap.First(x => x.Value == emptySprite).Key);
            }
        }

		if(charaNumList.Count == 0) {
			this.cautionAudioSource.PlayOneShot(this.cautionAudioSource.clip);

			this.cautionText.GetComponent<Text>().text = "1人以上のキャラクターを選択してください！";

			return;
		}

		this.audioSource.PlayOneShot(this.audioSource.clip);

		this.cautionText.GetComponent<Text>().text = "";

        foreach (int charaNum in charaNumList) Debug.Log("BattleStartBtnController - charaNum = " + charaNum);

		this.charaHyoziScript.SetVariablesAndLoadBattleTemp(charaNumList);
    }
}