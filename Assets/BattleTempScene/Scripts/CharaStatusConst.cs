using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class CharaStatusConst {

	// ステータスを取得するためのキー
	public const string HpKey = "Hp";
	public const string PowerKey = "Power";
	public const string SpeedToMoveKey = "SpeedToMove";
	public const string TimeToAttackKey = "TimeToAttack";
	public const string EnergyNeededKey = "EnergyNeeded";

	// キャラクターのタグ名
	public const string FighterATag = "Fighter1";
	public const string WitchATag = "Witch1";
	public const string HealerATag = "Healer1";
	public const string HealerBTag = "Healer2";
	public const string HealerCTag = "Healer3";
	public const string AttackTag = "Attack";
	public const string ShipTag = "Ship";

	// キャラクターの種類名
	public const string FighterKindName = "Fighter";
	public const string SimpleWitchKindName = "SimpleWitch";
	public const string SimpleHealerKindName = "SimpleHealer";
	public const string TotalHealerKindName = "TotalHealer";
	public const string BroadHealerKindName = "BroadHealer";

	// 種類ごとの各キャラクター名の配列
	static readonly List<string> fighterNameList = new List<string> { "FighterA" };
	static readonly List<string> SimpleWitchNameList = new List<string> { "WitchA" };
	static readonly List<string> SimpleHealerNameList = new List<string> { "HealerA" };
	static readonly List<string> TotalHealerNameList = new List<string> { "HealerB" };
	static readonly List<string> BroadHealerNameList = new List<string> { "HealerC" };

	/// <summary>
	/// 全キャラクターステータスのマップ（キー：タグ名）
	/// </summary>
	readonly Dictionary<string, Dictionary<string, float>> charaStatusMap 
		= new Dictionary<string, Dictionary<string, float>>() {

		{ FighterATag, FighterAStatusMap },
		{ WitchATag, WitchAStatusMap },
		{ HealerATag, HealerAStatusMap },
		{ HealerBTag, HealerBStatusMap },
		{ HealerCTag, HealerCStatusMap },
	};

	/// <summary>
	/// 種類ごとのキャラクター名の配列のリスト
	/// </summary>
	readonly Dictionary<string, List<string>> charaNamesList = new Dictionary<string, List<string>>() {

		{ FighterKindName, fighterNameList },
		{ SimpleWitchKindName, SimpleWitchNameList },
		{ SimpleHealerKindName, SimpleHealerNameList },
		{ TotalHealerKindName, TotalHealerNameList },
		{ BroadHealerKindName, BroadHealerNameList },
	};

	/// <summary>
	/// 全キャラクターステータスのマップ（キー：タグ名）を取得する。
	/// </summary>
	public Dictionary<string, Dictionary<string, float>> CharaStatusMap
	{
		get { return this.charaStatusMap; }
	}

	/// <summary>
	/// 種類ごとのキャラクター名の配列を取得する。
	/// </summary>
	public Dictionary<string, List<string>> CharaNamesList
	{
		get { return this.charaNamesList; }
	}

	/// <summary>
	/// ファイターAのステータス
	/// </summary>
	static readonly Dictionary<string, float> FighterAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 20 },
		{ PowerKey, 10 },
		{ SpeedToMoveKey, 0.05f },
		{ TimeToAttackKey, 4.0f },
		{ EnergyNeededKey, 10 }
	};

	/// <summary>
	/// ウィッチAのステータス
	/// </summary>
	static readonly Dictionary<string, float> WitchAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10 },
		{ PowerKey, 10.0f },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 2.0f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ヒーラーAのステータス
	/// </summary>
	static readonly Dictionary<string, float> HealerAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 15 },
		{ PowerKey, 5 },
		{ SpeedToMoveKey, 0.015f },
		{ TimeToAttackKey, 3.0f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ヒーラーBのステータス
	/// </summary>
	static readonly Dictionary<string, float> HealerBStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10 },
		{ PowerKey, 2 },
		{ SpeedToMoveKey, 0.01f },
		{ TimeToAttackKey, 3.0f },
		{ EnergyNeededKey, 20 }
	};

	/// <summary>
	/// ヒーラーCのステータス
	/// </summary>
	static readonly Dictionary<string, float> HealerCStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10 },
		{ PowerKey, 5 },
		{ SpeedToMoveKey, 0.015f },
		{ TimeToAttackKey, 5.0f },
		{ EnergyNeededKey, 20 }
	};
}