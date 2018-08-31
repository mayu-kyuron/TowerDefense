using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// サポーターキャラのコントローラー
/// </summary>
public abstract class SupporterController : CharaController {

	// すでに能力を上昇させたプレイヤー名リスト
	protected List<string> supportedCharaList = new List<string>();

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

			Dictionary<int, Dictionary<string, float>> charaStatusMaps = GetCurrentCharaStatusMaps();
			List<string> skipCharaNameList = GetSkipCharaNameList();

			foreach (int mapNo in charaStatusMaps.Keys) {

				// ループ中にマップの値を変えるため、キーのみをリストに取り出して回す。
				List<string> charaNameList = new List<string>(charaStatusMaps[mapNo].Keys);

				// まだ能力上昇していないキャラのみ、能力を上昇させる。
				foreach (string charaName in charaNameList) {

					if (skipCharaNameList != null && skipCharaNameList.Contains(charaName)) continue;

					if (!this.supportedCharaList.Contains(charaName + mapNo)) {

						GetComponent<AudioSource>().Play();

						charaStatusMaps[mapNo][charaName] += this.power;
						this.supportedCharaList.Add(charaName + mapNo);

						string target = "";
						if (mapNo == CurrentStatusVariables.CharaHpMapNo) {
							target = "hp";
						}
						else if (mapNo == CurrentStatusVariables.CharaMaxHpMapNo) {
							target = "maxHp";
						}
						else if (mapNo == CurrentStatusVariables.CharaPowerMapNo) {
							target = "power";
						}
						Debug.Log(String.Format("{0} - {1}.{2} = {3}", this.charaObjectName, charaName, target, charaStatusMaps[mapNo][charaName]));
					}
				}

				// 更新した登場キャラステータスマップを設定する。
				SetCurrentCharaStatusMap(mapNo, charaStatusMaps[mapNo]);
			}
		}
	}

	/// <summary>
	/// 能力アップの対象となる登場キャラステータスマップを取得する。
	/// どのステータスマップか判別するため、キーにCurrentStatusVariables定数を指定する。
	/// </summary>
	/// <returns>登場キャラステータスマップ群</returns>
	protected abstract Dictionary<int, Dictionary<string, float>> GetCurrentCharaStatusMaps();

	/// <summary>
	/// 能力アップ処理をスキップするキャラ名リストを取得する。
	/// ※スキップキャラなしの場合はnullを返すこと。
	/// </summary>
	/// <returns>キャラ名リスト</returns>
	protected abstract List<string> GetSkipCharaNameList();

	/// <summary>
	/// 更新した登場キャラステータスマップを設定する。
	/// </summary>
	/// <param name="mapNo">ステータスマップ番号</param>
	/// <param name="charaStatusMap">登場キャラステータスマップ</param>
	protected abstract void SetCurrentCharaStatusMap(int mapNo, Dictionary<string, float> charaStatusMap);
}