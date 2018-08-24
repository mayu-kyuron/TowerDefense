using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// サポーターキャラのコントローラー
/// </summary>
public abstract class SupporterController : CharaController {

	// すでに能力を上昇させたプレイヤー名リスト
	private List<string> supportedCharaList = new List<string>();

	protected override void AddCharaToMap() {

		// 自分の名前をキーに、HPと最大HPを登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaHpToMap(this.gameObject.name, this.hp);
		this.currentStatusVariables.AddCharaMaxHpToMap(this.charaObjectName, this.maxHp);
	}

	protected override void GoAhead() {
		if (this.isMoving && this.transform.position.x < 4.5) this.transform.Translate(this.speedToMove, 0, 0);
	}

	protected override void Action() {
		this.time += Time.deltaTime;
		
		if (this.time >= 1) {
			this.time = 0;
			Dictionary<string, float> charaStatusMap = GetCurrentCharaStatusMap();

			// ループ中にマップの値を変えるため、キーのみをリストに取り出して回す。
			List<string> charaNameList = new List<string>(charaStatusMap.Keys);

			List<string> skipCharaNameList = GetSkipCharaNameList();

			// まだ能力上昇していないキャラのみ、能力を上昇させる。
			foreach (string charaName in charaNameList) {

				if (skipCharaNameList != null && skipCharaNameList.Contains(charaName)) continue;
				
				if (!this.supportedCharaList.Contains(charaName)) {

                    int seNum = 3;
                    //int seNum = settingObject.GetComponent<SettingObject>().SeNum;
                    this.audioSource.volume = 0.2f * seNum;//音量
                    GetComponent<AudioSource>().Play();//SEをならす

                    charaStatusMap[charaName] += this.power;
					this.supportedCharaList.Add(charaName);

					var target = (this.charaObjectName.StartsWith("SupporterA")) ? "power" : "maxHp";
					Debug.Log(String.Format("{0} - {1}.{2} = {3}", this.charaObjectName, charaName, target, charaStatusMap[charaName]));
				}
			}

			// 更新した登場キャラステータスマップを設定する。
			SetCurrentCharaStatusMap(charaStatusMap);
		}
	}

	/// <summary>
	/// 能力アップの対象となる登場キャラステータスマップを取得する。
	/// </summary>
	/// <returns></returns>
	protected abstract Dictionary<string, float> GetCurrentCharaStatusMap();

	/// <summary>
	/// 能力アップ処理をスキップするキャラ名リストを取得する。
	/// ※スキップキャラなしの場合はnullを返すこと。
	/// </summary>
	/// <returns></returns>
	protected abstract List<string> GetSkipCharaNameList();

	/// <summary>
	/// 更新した登場キャラステータスマップを設定する。
	/// </summary>
	protected abstract void SetCurrentCharaStatusMap(Dictionary<string, float> charaStatusMap);
}