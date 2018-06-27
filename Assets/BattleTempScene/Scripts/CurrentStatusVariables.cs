using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CurrentStatusVariables : MonoBehaviour {

	// 戦闘中の全キャラクターのHPマップ
	private Dictionary<string, float> currentHpMap = new Dictionary<string, float>();

	/// <summary>
	/// 戦闘中の全キャラクターのHPマップを取得する。
	/// </summary>
	public Dictionary<string, float> CurrentHpMap
	{
		get { return this.currentHpMap; }
	}

	/// <summary>
	/// 戦闘中の全キャラクターのHPマップを設定する。
	/// </summary>
	/// <param name="currentHpMap"></param>
	public void SetCurrentHpMap(Dictionary<string, float> currentHpMap)
	{
		this.currentHpMap = currentHpMap;
	}
}