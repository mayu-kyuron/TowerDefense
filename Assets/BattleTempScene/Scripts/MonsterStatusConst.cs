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

	// モンスターのオブジェクト名
	// ※モンスターを増やすごとに追加
	public const string SlimeName = "Slime";
	public const string SlimeRedName = "SlimeRed";
	public const string GaitherName = "Gaither";
	public const string GaitherWhiteName = "GaitherWhite";
	public const string OrgeOrangeName = "OrgeOrange";
	public const string OrgeGreenName = "OrgeGreen";
	public const string ChimeraRedName = "ChimeraRed";
	public const string ChimeraPurpleName = "ChimeraPurple";
	public const string CentaurBrownName = "CentaurBrown";
	public const string CentaurBlackName = "CentaurBlack";
	public const string YetiWhiteName = "YetiWhite";
	public const string YetiGreenName = "YetiGreen";
	public const string FairyYellowName = "FairyYellow";
	public const string FairyPurpleName = "FairyPurple";
	public const string UnicornWhiteName = "UnicornWhite";
	public const string UnicornBlackName = "UnicornBlack";
	public const string GoblinGreenName = "GoblinGreen";
	public const string GoblinBlackName = "GoblinBlack";
	public const string GolemName = "Golem";
	public const string IfritGreenName = "IfritGreen";
	public const string IfritRedName = "IfritRed";
	public const string AlrauneName = "Alraune";
	public const string CarbuncleName = "Carbuncle";
	public const string ZonbieWhiteName = "ZonbieWhite";
	public const string ZonbieGreenName = "ZonbieGreen";

	// モンスターのタグ名
	// ※モンスターを増やすごとに追加
	public const string SlimeTag = "Suraimu";
    public const string SlimeRedTag = "SlimeRed";
    public const string GaitherTag = "Gaither";
    public const string GaitherWhiteTag = "GaitherWhite";
    public const string OrgeOrangeTag = "OrgeOrange";
    public const string OrgeGreenTag = "OrgeGreen";
    public const string ChimeraRedTag = "ChimeraRed";
    public const string ChimeraPurpleTag = "ChimeraPurple";
    public const string CentaurBrownTag = "CentaurBrown";
    public const string CentaurBlackTag = "CentaurBlack";
    public const string YetiWhiteTag = "YetiWhite";
    public const string YetiGreenTag = "YetiGreen";
    public const string FairyYellowTag = "FairyYellow";
    public const string FairyPurpleTag = "FairyPurple";
    public const string UnicornWhiteTag = "UnicornWhite";
    public const string UnicornBlackTag = "UnicornBlack";
    public const string GoblinGreenTag = "GoblinGreen";
    public const string GoblinBlackTag = "GoblinBlack";
    public const string GolemTag = "Golem";
    public const string IfritGreenTag = "IfritGreen";
    public const string IfritRedTag = "IfritRed";
    public const string AlrauneTag = "Alraune";
    public const string CarbuncleTag = "Carbuncle";
	public const string ZonbieWhiteTag = "ZonbieWhite";
	public const string ZonbieGreenTag = "ZonbieGreen";
	public const string AttackTag = "Attack";

	// モンスターの種類名
	public const string FighterMonsterKind = "FighterMonster";
	public const string SimpleWitchMonsterKind = "SimpleWitchMonster";
	public const string BroadWitchMonsterKind = "BroadWitchMonster";
	public const string SimpleHealerMonsterKind = "SimpleHealerMonster";

	// 種類ごとの各モンスター名リスト
	// ※モンスターを増やすごとに追加
	static readonly List<string> fighterMonsterNameList = new List<string> { SlimeName, SlimeRedName, OrgeOrangeName, OrgeGreenName, ChimeraRedName, ChimeraPurpleName, CarbuncleName, ZonbieWhiteName, ZonbieGreenName };
	static readonly List<string> simpleWitchMonsterNameList = new List<string> { GaitherName, GaitherWhiteName, AlrauneName };
	static readonly List<string> broadWitchMonsterNameList = new List<string> { CentaurBrownName, CentaurBlackName, YetiWhiteName, YetiGreenName, GoblinGreenName, GoblinBlackName, GolemName, IfritGreenName, IfritRedName };
	static readonly List<string> simpleHealerMonsterNameList = new List<string> { FairyYellowName, FairyPurpleName, UnicornWhiteName, UnicornBlackName };

    // 全モンスターのタグリスト
    // ※モンスターを増やすごとに追加
    readonly List<string> monsterTagList = new List<string> {
        SlimeTag,
        SlimeRedTag,
        OrgeOrangeTag,
        OrgeGreenTag,
        ChimeraRedTag,
        ChimeraPurpleTag,
        CarbuncleTag,
        GaitherTag,
        GaitherWhiteTag,
        CentaurBrownTag,
        CentaurBlackTag,
        YetiWhiteTag,
        YetiGreenTag,
        FairyYellowTag,
        FairyPurpleTag,
        UnicornWhiteTag,
        UnicornBlackTag,
        GoblinGreenTag,
        GoblinBlackTag,
        GolemTag,
        IfritGreenTag,
        IfritRedTag,
        AlrauneTag,
		ZonbieWhiteTag,
		ZonbieGreenTag,
	};

	/// <summary>
	/// 全モンスターステータスのマップ（キー：タグ名）
	/// ※モンスターを増やすごとに追加
	/// </summary>
	readonly Dictionary<string, Dictionary<string, float>> monsterStatusMap
		= new Dictionary<string, Dictionary<string, float>>() {

		{ SlimeTag, slimeStatusMap },
        { SlimeRedTag, slimeRedStatusMap },
        { OrgeOrangeTag, orgeOrangeStatusMap },
        { OrgeGreenTag, orgeGreenStatusMap },
        { ChimeraRedTag, chimeraRedStatusMap },
        { ChimeraPurpleTag, chimeraPurpleStatusMap },
        { CarbuncleTag, carbuncleStatusMap },
        { GaitherTag, gaitherStatusMap },
        { GaitherWhiteTag, gaitherWhiteStatusMap },
        { CentaurBrownTag, centaurBrownStatusMap },
        { CentaurBlackTag, centaurBlackStatusMap },
        { YetiWhiteTag, yetiWhiteStatusMap },
        { YetiGreenTag, yetiGreenStatusMap },
        { FairyYellowTag, fairyYellowStatusMap },
        { FairyPurpleTag, fairyPurpleStatusMap },
        { UnicornBlackTag, unicornBlackStatusMap },
        { UnicornWhiteTag, unicornWhiteStatusMap },
        { GoblinGreenTag, goblinGreenStatusMap },
        { GoblinBlackTag, goblinBlackStatusMap },
        { GolemTag, golemStatusMap },
        { IfritGreenTag, ifritGreenStatusMap },
        { IfritRedTag, ifritRedStatusMap },
        { AlrauneTag, alrauneStatusMap },
		{ ZonbieWhiteTag, zonbieWhiteStatusMap },
		{ ZonbieGreenTag, zonbieGreenStatusMap },
	};

	/// <summary>
	/// 種類ごとの全モンスター名リストのマップ（キー：種類名）
	/// </summary>
	readonly Dictionary<string, List<string>> monsterNameListMap = new Dictionary<string, List<string>>() {

		{ FighterMonsterKind, fighterMonsterNameList },
		{ SimpleWitchMonsterKind, simpleWitchMonsterNameList },
		{ BroadWitchMonsterKind, broadWitchMonsterNameList },
		{ SimpleHealerMonsterKind, simpleHealerMonsterNameList }
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
	/// スライムレッドのステータス
	/// </summary>
	static readonly Dictionary<string, float> slimeRedStatusMap = new Dictionary<string, float>() {
        { HpKey, 60 },
        { PowerKey, 20.0f },
        { SpeedToMoveKey, -0.03f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
	/// オーガグリーンのステータス
	/// </summary>
	static readonly Dictionary<string, float> orgeGreenStatusMap = new Dictionary<string, float>() {
        { HpKey, 100 },
        { PowerKey, 40.0f },
        { SpeedToMoveKey, -0.015f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
	/// オーガオレンジのステータス
	/// </summary>
	static readonly Dictionary<string, float> orgeOrangeStatusMap = new Dictionary<string, float>() {
        { HpKey, 200 },
        { PowerKey, 80.0f },
        { SpeedToMoveKey, -0.015f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
	/// キマイラレッドのステータス
	/// </summary>
	static readonly Dictionary<string, float> chimeraRedStatusMap = new Dictionary<string, float>() {
        { HpKey, 60 },
        { PowerKey, 30.0f },
        { SpeedToMoveKey, -0.05f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
	/// キマイラパープルのステータス
	/// </summary>
	static readonly Dictionary<string, float> chimeraPurpleStatusMap = new Dictionary<string, float>() {
        { HpKey, 120 },
        { PowerKey, 60.0f },
        { SpeedToMoveKey, -0.05f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
	/// カーバンクルのステータス
	/// </summary>
	static readonly Dictionary<string, float> carbuncleStatusMap = new Dictionary<string, float>() {
        { HpKey, 60 },
        { PowerKey, 30.0f },
        { SpeedToMoveKey, -0.06f },
        { TimeToAttackKey, 2.0f }
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

    /// <summary>
	/// ゲイザーホワイトのステータス
	/// </summary>
	static readonly Dictionary<string, float> gaitherWhiteStatusMap = new Dictionary<string, float>() {
        { HpKey, 80 },
        { PowerKey, 40.0f },
        { SpeedToMoveKey, -0.025f },
        { TimeToAttackKey, 3.0f }
    };

    /// <summary>
    /// ケンタウロスブラウンのステータス
    /// </summary>
    static readonly Dictionary<string, float> centaurBrownStatusMap = new Dictionary<string, float>() {
        { HpKey, 80 },
        { PowerKey, 40.0f },
        { SpeedToMoveKey, -0.025f },
        { TimeToAttackKey, 2.0f }
    };

    /// <summary>
    /// ケンタウロスブラックのステータス
    /// </summary>
    static readonly Dictionary<string, float> centaurBlackStatusMap = new Dictionary<string, float>() {
        { HpKey, 160 },
        { PowerKey, 80.0f },
        { SpeedToMoveKey, -0.025f },
        { TimeToAttackKey, 2.0f }
    };

    /// <summary>
    /// イエティホワイトのステータス
    /// </summary>
    static readonly Dictionary<string, float> yetiWhiteStatusMap = new Dictionary<string, float>() {
        { HpKey, 40 },
        { PowerKey, 20.0f },
        { SpeedToMoveKey, -0.025f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// イエティグリーンのステータス
    /// </summary>
    static readonly Dictionary<string, float> yetiGreenStatusMap = new Dictionary<string, float>() {
        { HpKey, 80 },
        { PowerKey, 40.0f },
        { SpeedToMoveKey, -0.025f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// フェアリーイエローのステータス
    /// </summary>
    static readonly Dictionary<string, float> fairyYellowStatusMap = new Dictionary<string, float>() {
        { HpKey, 30 },
        { PowerKey, 20.0f },
        { SpeedToMoveKey, -0.02f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// フェアリーパープルのステータス
    /// </summary>
    static readonly Dictionary<string, float> fairyPurpleStatusMap = new Dictionary<string, float>() {
        { HpKey, 50 },
        { PowerKey, 40.0f },
        { SpeedToMoveKey, -0.02f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// ユニコーンホワイトのステータス
    /// </summary>
    static readonly Dictionary<string, float> unicornWhiteStatusMap = new Dictionary<string, float>() {
        { HpKey, 60 },
        { PowerKey, 40.0f },
        { SpeedToMoveKey, -0.02f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// ユニコーンブラックのステータス
    /// </summary>
    static readonly Dictionary<string, float> unicornBlackStatusMap = new Dictionary<string, float>() {
        { HpKey, 120 },
        { PowerKey, 80.0f },
        { SpeedToMoveKey, -0.02f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// ゴブリングリーンのステータス
    /// </summary>
    static readonly Dictionary<string, float> goblinGreenStatusMap = new Dictionary<string, float>() {
        { HpKey, 80 },
        { PowerKey, 30.0f },
        { SpeedToMoveKey, -0.02f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// ゴブリンブラックのステータス
    /// </summary>
    static readonly Dictionary<string, float> goblinBlackStatusMap = new Dictionary<string, float>() {
        { HpKey, 100 },
        { PowerKey, 30.0f },
        { SpeedToMoveKey, -0.02f },
        { TimeToAttackKey, 5.0f }
    };

    /// <summary>
    /// ゴーレムのステータス
    /// </summary>
    static readonly Dictionary<string, float> golemStatusMap = new Dictionary<string, float>() {
        { HpKey, 200 },
        { PowerKey, 50.0f },
        { SpeedToMoveKey, -0.01f },
        { TimeToAttackKey, 10.0f }
    };

    /// <summary>
    /// イフリートグリーンのステータス
    /// </summary>
    static readonly Dictionary<string, float> ifritGreenStatusMap = new Dictionary<string, float>() {
        { HpKey, 250 },
        { PowerKey, 80.0f },
        { SpeedToMoveKey, -0.01f },
        { TimeToAttackKey, 10.0f }
    };

    /// <summary>
    /// イフリートレッドのステータス
    /// </summary>
    static readonly Dictionary<string, float> ifritRedStatusMap = new Dictionary<string, float>() {
        { HpKey, 500 },
        { PowerKey, 150.0f },
        { SpeedToMoveKey, -0.01f },
        { TimeToAttackKey, 10.0f }
    };

    /// <summary>
    /// アルラウネのステータス
    /// </summary>
    static readonly Dictionary<string, float> alrauneStatusMap = new Dictionary<string, float>() {
        { HpKey, 80 },
        { PowerKey, 50.0f },
        { SpeedToMoveKey, -0.025f },
        { TimeToAttackKey, 3.0f }
    };

	/// <summary>
	/// ゾンビホワイトのステータス
	/// </summary>
	static readonly Dictionary<string, float> zonbieWhiteStatusMap = new Dictionary<string, float>() {
		{ HpKey, 40 },
		{ PowerKey, 15.0f },
		{ SpeedToMoveKey, -0.025f },
		{ TimeToAttackKey, 5.5f }
	};

	/// <summary>
	/// ゾンビグリーンのステータス
	/// </summary>
	static readonly Dictionary<string, float> zonbieGreenStatusMap = new Dictionary<string, float>() {
		{ HpKey, 80 },
		{ PowerKey, 30.0f },
		{ SpeedToMoveKey, -0.025f },
		{ TimeToAttackKey, 5.5f }
	};
}