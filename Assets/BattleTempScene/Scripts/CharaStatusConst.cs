using System.Collections.Generic;

/// <summary>
/// キャラクターステータス関連の定数
/// </summary>
public class CharaStatusConst {

	// ステータスを取得するためのキー
	public const string HpKey = "Hp";
	public const string PowerKey = "Power";
	public const string SpeedToMoveKey = "SpeedToMove";
	public const string TimeToAttackKey = "TimeToAttack";
	public const string EnergyNeededKey = "EnergyNeeded";

	// キャラクターのタグ名
	// ※キャラクターを増やすごとに追加
	public const string FighterATag = "Fighter1";
    public const string FighterBTag = "Fighter2";
    public const string WitchATag = "Witch1";
	public const string WitchBTag = "Witch2";
	public const string HealerATag = "Healer1";
	public const string HealerBTag = "Healer2";
	public const string HealerCTag = "Healer3";
	public const string SupporterATag = "Supporter1";
	public const string SupporterBTag = "Supporter2";
	public const string AttackTag = "Attack";
	public const string ShipTag = "Ship";

	// キャラクターの種類名
	public const string FighterKind = "Fighter";
	public const string SimpleWitchKind = "SimpleWitch";
	public const string BroadWitchKind = "BroadWitch";
	public const string SimpleHealerKind = "SimpleHealer";
	public const string TotalHealerKind = "TotalHealer";
	public const string BroadHealerKind = "BroadHealer";
	public const string PowerSupporterKind = "PowerSupporter";
	public const string HpSupporterKind = "HpSupporter";

	// 種類ごとの各キャラクター名リスト
	// ※キャラクターを増やすごとに追加
	static readonly List<string> fighterNameList = new List<string> { "FighterA" };
    static readonly List<string> fighterBNameList = new List<string> { "FighterB" };
    static readonly List<string> simpleWitchNameList = new List<string> { "WitchA" };
	static readonly List<string> broadWitchNameList = new List<string> { "WitchB" };
	static readonly List<string> simpleHealerNameList = new List<string> { "HealerA" };
	static readonly List<string> totalHealerNameList = new List<string> { "HealerB" };
	static readonly List<string> broadHealerNameList = new List<string> { "HealerC" };
	static readonly List<string> powerSupporterNameList = new List<string> { "SupporterA" };
	static readonly List<string> hpSupporterNameList = new List<string> { "SupporterB" };

	// 全キャラクターのタグリスト
	// ※キャラクターを増やすごとに追加
	readonly List<string> charaTagList = new List<string> {
		FighterATag,
        FighterBTag,
		WitchATag,
		WitchBTag,
		HealerATag,
		HealerBTag,
		HealerCTag,
		SupporterATag,
		SupporterBTag,
	};

	/// <summary>
	/// 全キャラクターステータスのマップ（キー：タグ名）
	/// ※キャラクターを増やすごとに追加
	/// </summary>
	readonly Dictionary<string, Dictionary<string, float>> charaStatusMap 
		= new Dictionary<string, Dictionary<string, float>>() {

		{ FighterATag, fighterAStatusMap },
        { FighterBTag, fighterBStatusMap },
        { WitchATag, witchAStatusMap },
		{ WitchBTag, witchBStatusMap },
		{ HealerATag, healerAStatusMap },
		{ HealerBTag, healerBStatusMap },
		{ HealerCTag, healerCStatusMap },
		{ SupporterATag, supporterAStatusMap },
		{ SupporterBTag, supporterBStatusMap },
	};

	/// <summary>
	/// 種類ごとの全キャラクター名リストのマップ（キー：種類名）
	/// </summary>
	readonly Dictionary<string, List<string>> charaNameListMap = new Dictionary<string, List<string>>() {

		{ FighterKind, fighterNameList },
		{ SimpleWitchKind, simpleWitchNameList },
		{ BroadWitchKind, broadWitchNameList },
		{ SimpleHealerKind, simpleHealerNameList },
		{ TotalHealerKind, totalHealerNameList },
		{ BroadHealerKind, broadHealerNameList },
		{ PowerSupporterKind, powerSupporterNameList },
		{ HpSupporterKind, hpSupporterNameList }
	};

	/// <summary>
	/// 全キャラクターのタグリストを取得する。
	/// </summary>
	public List<string> CharaTagList
	{
		get { return charaTagList; }
	}

	/// <summary>
	/// 全キャラクターステータスのマップ（キー：タグ名）を取得する。
	/// </summary>
	public Dictionary<string, Dictionary<string, float>> CharaStatusMap
	{
		get { return charaStatusMap; }
	}

	/// <summary>
	/// 種類ごとの全キャラクター名リストのマップ（キー：種類名）を取得する。
	/// </summary>
	public Dictionary<string, List<string>> CharaNameListMap
	{
		get { return charaNameListMap; }
	}

	////////////////////////////////////////////
	// ↓ここから、キャラクターのステータス↓ //
	// ※キャラクターを増やすごとに追加       //
	////////////////////////////////////////////

	/// <summary>
	/// ファイターAのステータス
	/// </summary>
	static readonly Dictionary<string, float> fighterAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 100 },
		{ PowerKey, 10 },
		{ SpeedToMoveKey, 0.05f },
		{ TimeToAttackKey, 4.0f },
		{ EnergyNeededKey, 10 }
	};

    /// <summary>
	/// ファイターBのステータス
	/// </summary>
	static readonly Dictionary<string, float> fighterBStatusMap = new Dictionary<string, float>() {
        { HpKey, 100 },
        { PowerKey, 20 },
        { SpeedToMoveKey, 0.05f },
        { TimeToAttackKey, 2.0f },
        { EnergyNeededKey, 10 }
    };

    /// <summary>
    /// ウィッチAのステータス
    /// </summary>
    static readonly Dictionary<string, float> witchAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10 },
		{ PowerKey, 10.0f },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 2.0f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ウィッチBのステータス
	/// </summary>
	static readonly Dictionary<string, float> witchBStatusMap = new Dictionary<string, float>() {
		{ HpKey, 15 },
		{ PowerKey, 10.0f },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 3.0f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ヒーラーAのステータス
	/// </summary>
	static readonly Dictionary<string, float> healerAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 15 },
		{ PowerKey, 5 },
		{ SpeedToMoveKey, 0.015f },
		{ TimeToAttackKey, 3.0f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ヒーラーBのステータス
	/// </summary>
	static readonly Dictionary<string, float> healerBStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10 },
		{ PowerKey, 2 },
		{ SpeedToMoveKey, 0.01f },
		{ TimeToAttackKey, 3.0f },
		{ EnergyNeededKey, 20 }
	};

	/// <summary>
	/// ヒーラーCのステータス
	/// </summary>
	static readonly Dictionary<string, float> healerCStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10 },
		{ PowerKey, 5 },
		{ SpeedToMoveKey, 0.015f },
		{ TimeToAttackKey, 5.0f },
		{ EnergyNeededKey, 20 }
	};

	/// <summary>
	/// サポーターAのステータス
	/// </summary>
	static readonly Dictionary<string, float> supporterAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 15 },
		{ PowerKey, 5 },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 0 },
		{ EnergyNeededKey, 20 }
	};

	/// <summary>
	/// サポーターBのステータス
	/// </summary>
	static readonly Dictionary<string, float> supporterBStatusMap = new Dictionary<string, float>() {
		{ HpKey, 15 },
		{ PowerKey, 5 },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 0 },
		{ EnergyNeededKey, 20 }
	};
}