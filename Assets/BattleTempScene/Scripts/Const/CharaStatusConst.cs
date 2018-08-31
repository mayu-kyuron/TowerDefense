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
    public const float ChangeNum = 7; //パワーアップするステージの判別用

    // キャラクターのタグ名
    // ※キャラクターを増やすごとに追加
    public const string FighterATag = "FighterA";
    public const string FighterBTag = "FighterB";
    public const string FighterCTag = "FighterC";
    public const string WitchATag = "WitchA";
	public const string WitchBTag = "WitchB";
	public const string HealerATag = "HealerA";
	//public const string HealerBTag = "HealerB";
	public const string HealerCTag = "HealerC";
	public const string SupporterATag = "SupporterA";
	public const string SupporterBTag = "SupporterB";
	public const string AttackTag = "Attack";
	public const string ShipTag = "Ship";
    public const string SuperTag = "Super";

	// キャラクターの種類名
	public const string FighterKind = "Fighter";
	public const string SimpleWitchKind = "SimpleWitch";
	public const string BroadWitchKind = "BroadWitch";
	public const string SimpleHealerKind = "SimpleHealer";
	public const string TotalHealerKind = "TotalHealer";
	public const string BroadHealerKind = "BroadHealer";
	public const string PowerSupporterKind = "PowerSupporter";
	public const string HpSupporterKind = "HpSupporter";
    public const string HealerKind = "Healer";


    // 種類ごとの各キャラクター名リスト
    // ※キャラクターを増やすごとに追加
    static readonly List<string> fighterNameList = new List<string> { "FighterA", "FighterC" };
    static readonly List<string> simpleWitchNameList = new List<string> { "WitchA" };
	static readonly List<string> broadWitchNameList = new List<string> { "WitchB", "FighterB" };
	static readonly List<string> simpleHealerNameList = new List<string> { "HealerA" };
	static readonly List<string> totalHealerNameList = new List<string> { "HealerB" };
	static readonly List<string> broadHealerNameList = new List<string> { "HealerC" };
    static readonly List<string> powerSupporterNameList = new List<string> { "SupporterA" };
	static readonly List<string> hpSupporterNameList = new List<string> { "SupporterB" };
    static readonly List<string> HealerShipNameList = new List<string> { "HealerA", "HealerC", "Ship" };//ヒーラー同士、船はぶつからず、味方の後ろに滞在する処理
	public const string ShipName = "Ship";

    // 全キャラクターのタグリスト
    // ※キャラクターを増やすごとに追加
    readonly List<string> charaTagList = new List<string> {
		FighterATag,
        FighterBTag,
        FighterCTag,
        WitchATag,
		WitchBTag,
		HealerATag,
		//HealerBTag,
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
        { FighterCTag, fighterCStatusMap },
        { WitchATag, witchAStatusMap },
        { WitchBTag, witchBStatusMap },
        { HealerATag, healerAStatusMap },
        //{ HealerBTag, healerBStatusMap },
        { HealerCTag, healerCStatusMap },
        { SupporterATag, supporterAStatusMap },
        { SupporterBTag, supporterBStatusMap },
        { FighterATag + SuperTag, sFighterAStatusMap },
        { FighterBTag + SuperTag, sFighterBStatusMap },
        { FighterCTag + SuperTag, sFighterCStatusMap },
        { WitchATag + SuperTag, sWitchAStatusMap },
        { WitchBTag + SuperTag, sWitchBStatusMap },
        { HealerATag + SuperTag, sHealerAStatusMap },
        //{ HealerBTag + SuperTag, sHealerBStatusMap },
        { HealerCTag + SuperTag, sHealerCStatusMap },
        { SupporterATag + SuperTag, sSupporterAStatusMap },
        { SupporterBTag + SuperTag, sSupporterBStatusMap },
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
		{ HpSupporterKind, hpSupporterNameList },
        { HealerKind, HealerShipNameList }
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
		{ HpKey, 100f },
		{ PowerKey, 15f },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 3.75f },
		{ EnergyNeededKey, 14}
	};

    /// <summary>
	/// ファイターBのステータス
	/// </summary>
	static readonly Dictionary<string, float> fighterBStatusMap = new Dictionary<string, float>() {
        { HpKey, 50f },
        { PowerKey, 25f },
        { SpeedToMoveKey, 0.03f },
        { TimeToAttackKey, 5.0f },
        { EnergyNeededKey, 20 }
    };

    /// <summary>
    /// ファイターCのステータス
    /// </summary>
    static readonly Dictionary<string, float> fighterCStatusMap = new Dictionary<string, float>() {
        { HpKey, 200f },
        { PowerKey, 5f },
        { SpeedToMoveKey, 0.02f },
        { TimeToAttackKey, 8.0f },
        { EnergyNeededKey, 15}
    };

    /// <summary>
    /// ウィッチAのステータス
    /// </summary>
    static readonly Dictionary<string, float> witchAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 30f },
		{ PowerKey, 10.0f },
		{ SpeedToMoveKey, 0.04f },
		{ TimeToAttackKey, 2.0f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ウィッチBのステータス
	/// </summary>
	static readonly Dictionary<string, float> witchBStatusMap = new Dictionary<string, float>() {
		{ HpKey, 10f },
		{ PowerKey, 20.0f },
		{ SpeedToMoveKey, 0.025f },
		{ TimeToAttackKey, 4.5f },
		{ EnergyNeededKey, 22 }
	};

	/// <summary>
	/// ヒーラーAのステータス
	/// </summary>
	static readonly Dictionary<string, float> healerAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 60 },
		{ PowerKey, 20 },
		{ SpeedToMoveKey, 0.015f },
		{ TimeToAttackKey, 2.5f },
		{ EnergyNeededKey, 15 }
	};

	/// <summary>
	/// ヒーラーCのステータス
	/// </summary>
	static readonly Dictionary<string, float> healerCStatusMap = new Dictionary<string, float>() {
		{ HpKey, 50f },
		{ PowerKey, 10f },
		{ SpeedToMoveKey, 0.015f },
		{ TimeToAttackKey, 3.0f },
		{ EnergyNeededKey, 20 }
	};

	/// <summary>
	/// サポーターAのステータス
	/// </summary>
	static readonly Dictionary<string, float> supporterAStatusMap = new Dictionary<string, float>() {
		{ HpKey, 30f },
		{ PowerKey, 5.0f },
		{ SpeedToMoveKey, 0.03f },
		{ TimeToAttackKey, 0 },
		{ EnergyNeededKey, 18 }
	};

	/// <summary>
	/// サポーターBのステータス
	/// </summary>
	static readonly Dictionary<string, float> supporterBStatusMap = new Dictionary<string, float>() {
		{ HpKey, 40f },
		{ PowerKey, 5.0f },
		{ SpeedToMoveKey, 0.03f },
		{ TimeToAttackKey, 0 },
		{ EnergyNeededKey, 18 }
	};

    /// <summary>
	/// スーパーファイターAのステータス
	/// </summary>
	static readonly Dictionary<string, float> sFighterAStatusMap = new Dictionary<string, float>() {
        { HpKey, 220 },
        { PowerKey, 30f },
        { SpeedToMoveKey, 0.025f },
        { TimeToAttackKey, 3.75f },
        { EnergyNeededKey, 14 }
    };

    /// <summary>
	/// スーパーファイターBのステータス
	/// </summary>
	static readonly Dictionary<string, float> sFighterBStatusMap = new Dictionary<string, float>() {
        { HpKey, 100f },
        { PowerKey, 50f },
        { SpeedToMoveKey, 0.03f },
        { TimeToAttackKey, 5.0f },
        { EnergyNeededKey, 20 }
    };

    /// <summary>
	/// スーパーファイターCのステータス
	/// </summary>
	static readonly Dictionary<string, float> sFighterCStatusMap = new Dictionary<string, float>() {
        { HpKey, 400f },
        { PowerKey, 5.0f },
        { SpeedToMoveKey, 0.02f },
        { TimeToAttackKey, 8.0f },
        { EnergyNeededKey, 15 }
    };

    /// <summary>
	/// スーパーウィッチAのステータス
	/// </summary>
	static readonly Dictionary<string, float> sWitchAStatusMap = new Dictionary<string, float>() {
        { HpKey, 60f },
        { PowerKey, 20.0f },
        { SpeedToMoveKey, 0.04f },
        { TimeToAttackKey, 2.0f },
        { EnergyNeededKey, 15 }
    };

    /// <summary>
	/// スーパーウィッチBのステータス
	/// </summary>
	static readonly Dictionary<string, float> sWitchBStatusMap = new Dictionary<string, float>() {
        { HpKey, 26f },
        { PowerKey, 40f },
        { SpeedToMoveKey, 0.025f },
        { TimeToAttackKey, 4.5f },
        { EnergyNeededKey, 22 }
    };

    /// <summary>
	/// スーパーヒーラーAのステータス
	/// </summary>
	static readonly Dictionary<string, float> sHealerAStatusMap = new Dictionary<string, float>() {
        { HpKey, 120f },
        { PowerKey, 40f },
        { SpeedToMoveKey, 0.015f },
        { TimeToAttackKey, 2.5f },
        { EnergyNeededKey, 15 }
    };

    /// <summary>
	/// スーパーヒーラーCのステータス
	/// </summary>
	static readonly Dictionary<string, float> sHealerCStatusMap = new Dictionary<string, float>() {
        { HpKey, 100f },
        { PowerKey, 20f },
        { SpeedToMoveKey, 0.015f },
        { TimeToAttackKey, 3.0f },
        { EnergyNeededKey, 20 }
    };

    /// <summary>
	/// スーパーサポーターAのステータス
	/// </summary>
	static readonly Dictionary<string, float> sSupporterAStatusMap = new Dictionary<string, float>() {
        { HpKey, 60f },
        { PowerKey, 10.0f },
        { SpeedToMoveKey, 0.03f },
        { TimeToAttackKey, 0f },
        { EnergyNeededKey, 18 }
    };

    /// <summary>
	/// スーパーサポーターBのステータス
	/// </summary>
	static readonly Dictionary<string, float> sSupporterBStatusMap = new Dictionary<string, float>() {
        { HpKey, 80f },
        { PowerKey, 20.0f },
        { SpeedToMoveKey, 0.03f },
        { TimeToAttackKey, 0f },
        { EnergyNeededKey, 18 }
    };
}