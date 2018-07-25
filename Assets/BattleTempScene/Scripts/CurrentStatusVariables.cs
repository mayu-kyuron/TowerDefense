using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// 現ステータス変数保持クラス
/// </summary>
public class CurrentStatusVariables : MonoBehaviour {

	// 戦闘中の全キャラクターのHPマップ
	private Dictionary<string, float> currentCharaHpMap = new Dictionary<string, float>();
	
	// 戦闘中の全モンスターのHPマップ
	private Dictionary<string, float> currentMonsterHpMap = new Dictionary<string, float>();

	// 戦闘中の全キャラクターの攻撃力マップ
	private Dictionary<string, float> currentCharaPowerMap = new Dictionary<string, float>();

	/// <summary>
	/// 戦闘中の全キャラクターのHPマップを取得する。
	/// </summary>
	public Dictionary<string, float> CurrentCharaHpMap {
		get { return this.currentCharaHpMap; }
	}

	/// <summary>
	/// 戦闘中の全キャラクターのHPマップを設定する。
	/// </summary>
	/// <param name="currentCharaHpMap"></param>
	public void SetCurrentCharaHpMap(Dictionary<string, float> currentCharaHpMap) {
		this.currentCharaHpMap = currentCharaHpMap;
	}

	/// <summary>
	/// 戦闘中キャラクターマップに自分のHPを登録する。
	/// すでに同キャラクター名で登録されていた場合は何もしない。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	/// <param name="hp">HP</param>
	public void AddCharaHpToMap(string name, float hp) {
		if (!this.currentCharaHpMap.ContainsKey(name))  this.currentCharaHpMap.Add(name, hp);
	}

	/// <summary>
	/// 戦闘中キャラクターマップの自分のHPを更新する。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	/// <param name="hp">HP</param>
	public void UpdateCharaHpOfMap(string name, float hp) {
		this.currentCharaHpMap[name] = hp;
	}

	/// <summary>
	/// 戦闘中キャラクターマップから自分のHPを削除する。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	public void RemoveCharaHpFromMap(string name) {
		this.currentCharaHpMap.Remove(name);
	}

	/// <summary>
	/// 戦闘中の全モンスターのHPマップを取得する。
	/// </summary>
	public Dictionary<string, float> CurrentMonsterHpMap {
		get { return this.currentMonsterHpMap; }
	}

	/// <summary>
	/// 戦闘中の全モンスターのHPマップを設定する。
	/// </summary>
	/// <param name="currentMonsterHpMap"></param>
	public void SetCurrentMonsterHpMap(Dictionary<string, float> currentMonsterHpMap) {
		this.currentMonsterHpMap = currentMonsterHpMap;
	}

	/// <summary>
	/// 戦闘中モンスターマップに自分のHPを登録する。
	/// すでに同キャラクター名で登録されていた場合は何もしない。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	/// <param name="hp">HP</param>
	public void AddMonsterHpToMap(string name, float hp) {
		if(!this.currentMonsterHpMap.ContainsKey(name)) this.currentMonsterHpMap.Add(name, hp);
	}

	/// <summary>
	/// 戦闘中モンスターマップの自分のHPを更新する。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	/// <param name="hp">HP</param>
	public void UpdateMonsterHpOfMap(string name, float hp) {
		this.currentMonsterHpMap[name] = hp;
	}

	/// <summary>
	/// 戦闘中モンスターマップから自分のHPを削除する。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	public void RemoveMonsterHpFromMap(string name) {
		this.currentMonsterHpMap.Remove(name);
	}

	/// <summary>
	/// 戦闘中の全キャラクターの攻撃力マップを取得する。
	/// </summary>
	public Dictionary<string, float> CurrentCharaPowerMap {
		get { return this.currentCharaPowerMap; }
	}

	/// <summary>
	/// 戦闘中の全キャラクターの攻撃力マップを設定する。
	/// </summary>
	/// <param name="currentCharaPowerMap"></param>
	public void SetCurrentCharaPowerMap(Dictionary<string, float> currentCharaPowerMap) {
		this.currentCharaPowerMap = currentCharaPowerMap;
	}

	/// <summary>
	/// 戦闘中キャラクターマップに自分の攻撃力を登録する。
	/// すでに同キャラクター名で登録されていた場合は何もしない。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	/// <param name="power">攻撃力</param>
	public void AddCharaPowerToMap(string name, float power) {
		if (!this.currentCharaPowerMap.ContainsKey(name)) this.currentCharaPowerMap.Add(name, power);
	}

	/// <summary>
	/// 戦闘中キャラクターマップから自分の攻撃力を削除する。
	/// </summary>
	/// <param name="name">ゲームオブジェクト名</param>
	public void RemoveCharaPowerFromMap(string name) {
		this.currentCharaPowerMap.Remove(name);
	}
}