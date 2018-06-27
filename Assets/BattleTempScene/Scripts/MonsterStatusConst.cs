using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MonsterStatusConst {

	// ステータスを取得するためのキー
	public const string HpKey = "Hp";
	public const string PowerKey = "Power";
	public const string SpeedToMoveKey = "SpeedToMove";
	public const string TimeToAttackKey = "TimeToAttack";

	// モンスターのタグ名
	public const string SlimeTag = "Suraimu";
	public const string GaitherTag = "Gaither";

	/// <summary>
	/// 全モンスターステータスのマップ（キー：タグ名）
	/// </summary>
	readonly Dictionary<string, Dictionary<string, float>> monsterStatusMap 
		= new Dictionary<string, Dictionary<string, float>>() {

		{ SlimeTag, SlimeStatusMap }
	};

	/// <summary>
	/// 全モンスターステータスのマップ（キー：タグ名）を取得する。
	/// </summary>
	public Dictionary<string, Dictionary<string, float>> MonsterStatusMap
	{
		get { return this.monsterStatusMap; }
	}

	/// <summary>
	/// スライムのステータス
	/// </summary>
	static readonly Dictionary<string, float> SlimeStatusMap = new Dictionary<string, float>() {
		{ HpKey, 30 },
		{ PowerKey, 10.0f },
		{ SpeedToMoveKey, -0.03f },
		{ TimeToAttackKey, 5.0f }
	};
}