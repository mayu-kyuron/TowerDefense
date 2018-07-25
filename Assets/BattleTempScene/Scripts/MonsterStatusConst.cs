using System.Collections.Generic;

/// <summary>
/// モンスターステータス関連の定数
/// </summary>
public class MonsterStatusConst {

	// ステータスを取得するためのキー
	public const string HpKey = "Hp";
	public const string PowerKey = "Power";
	public const string SpeedToMoveKey = "SpeedToMove";
	public const string TimeToAttackKey = "TimeToAttack";

	// モンスターのタグ名
	// ※モンスターを増やすごとに追加
	public const string SlimeTag = "Suraimu";
	public const string GaitherTag = "Gaither";
	public const string AttackTag = "Attack";

	// モンスターの種類名
	public const string FighterMonsterKind = "FighterMonster";
	public const string SimpleWitchMonsterKind = "SimpleWitchMonster";
	public const string BroadWitchMonsterKind = "BroadWitchMonster";
	public const string SimpleHealerMonsterKind = "SimpleHealerMonster";

	// 種類ごとの各モンスター名リスト
	// ※モンスターを増やすごとに追加
	static readonly List<string> fighterMonsterNameList = new List<string> { "Slime" };
	static readonly List<string> simpleWitchMonsterNameList = new List<string> { "Gaither" };
	static readonly List<string> broadWitchMonsterNameList = new List<string> {  };
	static readonly List<string> simpleHealerMonsterNameList = new List<string> {  };

	// 全モンスターのタグリスト
	// ※モンスターを増やすごとに追加
	readonly List<string> monsterTagList = new List<string> {
		SlimeTag,
		GaitherTag,
	};

	/// <summary>
	/// 全モンスターステータスのマップ（キー：タグ名）
	/// ※モンスターを増やすごとに追加
	/// </summary>
	readonly Dictionary<string, Dictionary<string, float>> monsterStatusMap
		= new Dictionary<string, Dictionary<string, float>>() {

		{ SlimeTag, slimeStatusMap },
		{ GaitherTag, gaitherStatusMap },
	};

	/// <summary>
	/// 種類ごとの全モンスター名リストのマップ（キー：種類名）
	/// </summary>
	readonly Dictionary<string, List<string>> monsterNameListMap = new Dictionary<string, List<string>>() {

		{ FighterMonsterKind, fighterMonsterNameList },
		{ SimpleWitchMonsterKind, simpleWitchMonsterNameList },
		{ BroadWitchMonsterKind, broadWitchMonsterNameList },
		{ SimpleHealerMonsterKind, simpleHealerMonsterNameList },
	};

	/// <summary>
	/// 全モンスターのタグリストを取得する。
	/// </summary>
	public List<string> MonsterTagList
	{
		get { return monsterTagList; }
	}

	/// <summary>
	/// 全モンスターステータスのマップ（キー：タグ名）を取得する。
	/// </summary>
	public Dictionary<string, Dictionary<string, float>> MonsterStatusMap {
		get { return monsterStatusMap; }
	}

	/// <summary>
	/// 種類ごとの全モンスター名リストのマップ（キー：種類名）を取得する。
	/// </summary>
	public Dictionary<string, List<string>> MonsterNameListMap
	{
		get { return monsterNameListMap; }
	}

	//////////////////////////////////////////
	// ↓ここから、モンスターのステータス↓ //
	// ※モンスターを増やすごとに追加       //
	//////////////////////////////////////////

	/// <summary>
	/// スライムのステータス
	/// </summary>
	static readonly Dictionary<string, float> slimeStatusMap = new Dictionary<string, float>() {
		{ HpKey, 30 },
		{ PowerKey, 10.0f },
		{ SpeedToMoveKey, -0.03f },
		{ TimeToAttackKey, 5.0f }
	};

	/// <summary>
	/// ゲイザーのステータス
	/// </summary>
	static readonly Dictionary<string, float> gaitherStatusMap = new Dictionary<string, float>() {
		{ HpKey, 40 },
		{ PowerKey, 5.0f },
		{ SpeedToMoveKey, -0.025f },
		{ TimeToAttackKey, 3.0f }
	};
}