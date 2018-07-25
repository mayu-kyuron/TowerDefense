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

		// 自分の名前をキーに、HPを登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaHpToMap(this.gameObject.name, this.hp);
	}

	protected override void GoAhead() {
		if (this.isMoving && this.transform.position.x < -3) this.transform.Translate(this.speedToMove, 0, 0);
	}

	protected override void Action() {
		this.time += Time.deltaTime;
		
		if (this.time >= 1) {
			this.time = 0;
			Dictionary<string, float> charaPowerMap = this.currentStatusVariables.CurrentCharaPowerMap;

			// ループ中にマップの値を変えるため、キーのみをリストに取り出して回す。
			List<string> charaNameList = new List<string>(charaPowerMap.Keys);

			// まだ能力上昇していないキャラのみ、能力を上昇させる。
			foreach (string charaName in charaNameList) {
				
				if (!this.supportedCharaList.Contains(charaName)) {
					charaPowerMap[charaName] += this.power;
					this.supportedCharaList.Add(charaName);

					Debug.Log(String.Format("{0} - {1}.power = {2}", this.charaObjectName, charaName, charaPowerMap[charaName]));
				}
			}
			
			// 更新した登場キャラ攻撃力マップを設定する。
			this.currentStatusVariables.SetCurrentCharaPowerMap(charaPowerMap);
		}
	}
}