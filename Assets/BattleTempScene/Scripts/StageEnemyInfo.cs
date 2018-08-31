using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージモンスターの詳細登録クラス
/// </summary>
public class StageEnemyInfo : MonoBehaviour {

	/// <summary>
	/// ステージごとのモンスターと登場番号のマップ（キー：ステージ番号）を取得する。
	/// </summary>
	public Dictionary<int, Dictionary<int, List<int>>> StageMonsterComingNumMap {
		get { return stageMonsterComingNumMap; }
	}

	/// <summary>
	/// ステージごとのモンスター登場ペースのマップ（キー：ステージ番号）を取得する。
	/// </summary>
	public Dictionary<int, Dictionary<int, double>> StageMonsterComingPaceMap {
		get { return stageMonsterComingPaceMap; }
	}

	/// <summary>
	/// ステージごとのモンスターと登場番号のマップ（キー：ステージ番号）
	/// </summary>
	readonly Dictionary<int, Dictionary<int, List<int>>> stageMonsterComingNumMap = new Dictionary<int, Dictionary<int, List<int>>>() {

		{ 1, firstMonsterMap },
		{ 2, secondMonsterMap },
		{ 3, thirdMonsterMap },
		{ 4, fourthMonsterMap },
		{ 5, fifthMonsterMap },
		{ 6, sixthMonsterMap },
		{ 7, seventhMonsterMap },
		{ 8, eighthMonsterMap },
		{ 9, ninthMonsterMap },
		{ 10, tenthMonsterMap },
		{ 11, eleventhMonsterMap },
		{ 12, twelfthMonsterMap },
	};

	/// <summary>
	/// ステージごとのモンスター登場ペースのマップ（キー：ステージ番号）
	/// </summary>
	readonly Dictionary<int, Dictionary<int, double>> stageMonsterComingPaceMap = new Dictionary<int, Dictionary<int, double>>() {

		{ 1, firstPaceMap },
		{ 2, secondPaceMap },
		{ 3, thirdPaceMap },
		{ 4, fourthPaceMap },
		{ 5, fifthPaceMap },
		{ 6, sixthPaceMap },
		{ 7, seventhPaceMap },
		{ 8, eighthPaceMap },
		{ 9, ninthPaceMap },
		{ 10, tenthPaceMap },
		{ 11, eleventhPaceMap },
		{ 12, twelfthPaceMap },
	};

	////////////////////////////////////////////////
	// ↓ここから、モンスターと登場番号のマップ↓ //
	////////////////////////////////////////////////

	/// <summary>
	/// ステージ1のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> firstMonsterMap = new Dictionary<int, List<int>>() {
		{ CharaMonsterNoConst.SlimeNo, new List<int>(){ 1, 2, 3, 5, 6,  8, 9, 11, 13, 15, 16, 17, 18, 19 } },
		{ CharaMonsterNoConst.GaitherNo, new List<int>(){ 4, 7, 10, 12, 14, 20 } },
	};

	/// <summary>
	/// ステージ2のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> secondMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.SlimeNo, new List<int>(){ 1, 4, 5, 8, 9, 12, 13, 15, 16 } },
        { CharaMonsterNoConst.ZonbieWhiteNo, new List<int>(){ 2, 7, 11, 18, 19 } },
        { CharaMonsterNoConst.GaitherNo, new List<int>(){ 3, 6, 10, 14, 17, 20 } },
    };

	/// <summary>
	/// ステージ3のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> thirdMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.ZonbieWhiteNo, new List<int>(){ 1, 3, 5, 8, 9, 12, 14, 15, 17, 18, 19 } },
        { CharaMonsterNoConst.GaitherNo, new List<int>(){ 2, 6, 7, 10, 13, 20 } },
        { CharaMonsterNoConst.YetiWhiteNo, new List<int>(){ 4, 11, 16} },
    };

	/// <summary>
	/// ステージ4のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> fourthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.SlimeNo, new List<int>(){ 3, 7, 8, 12, 16, 20, 21, 23} },
        { CharaMonsterNoConst.ZonbieWhiteNo, new List<int>(){ 2, 5, 9, 13, 18, 19, 22, 25 } },
        { CharaMonsterNoConst.GaitherNo, new List<int>(){ 6, 10, 11, 14, 17 } },
        { CharaMonsterNoConst.YetiWhiteNo, new List<int>(){ 4, 15, 24  } },
        { CharaMonsterNoConst.BossSlimeNo, new List<int>(){ 1, } },
    };

	/// <summary>
	/// ステージ5のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> fifthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.GoblinGreenNo, new List<int>(){ 1, 2, 5, 7, 11, 14, 15, 22, 24} },
        { CharaMonsterNoConst.ChimeraRedNo, new List<int>(){ 3, 9, 10, 12, 17, 19, 20} },
        { CharaMonsterNoConst.YetiWhiteNo, new List<int>(){ 4, 8, 13, 18, 23, 25 } },
        { CharaMonsterNoConst.FairyPurpleNo, new List<int>(){ 6, 16, 21} },
    };

	/// <summary>
	/// ステージ6のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> sixthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.CarbuncleNo, new List<int>(){ 2, 3, 4, 5, 6, 7, 8, 12, 15, 16, 18, 20, 21, 23, 26, 27, 29, 30, 31} },
        { CharaMonsterNoConst.AlrauneNo, new List<int>(){  9, 10, 13, 16, 17, 19, 22, 24, 28, 33 } },
        { CharaMonsterNoConst.UnicornWhiteNo, new List<int>(){ 11, 14, 25, 32,} },
        { CharaMonsterNoConst.GolemNo, new List<int>(){ 1 } },
    };

	/// <summary>
	/// ステージ7のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> seventhMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.ChimeraRedNo, new List<int>(){ 1, 2, 5, 7, 11, 17, 18} },
        { CharaMonsterNoConst.CentaurBrownNo, new List<int>(){ 6, 8, 13, 16} },
        { CharaMonsterNoConst.OgreGreenNo, new List<int>(){ 4, 9, 12, 19, 20} },
        { CharaMonsterNoConst.FairyPurpleNo, new List<int>(){ 3, 10, 14, 15} },
    };

	/// <summary>
	/// ステージ8のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> eighthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.SlimeRedNo, new List<int>(){ 2, 3, 9, 12, 17, 21, 24 } },
        { CharaMonsterNoConst.ZonbieGreenNo, new List<int>(){ 5, 6, 7, 13, 18, 22} },
        { CharaMonsterNoConst.CentaurBrownNo, new List<int>(){ 4, 10, 16, 19, 25} },
        { CharaMonsterNoConst.OgreGreenNo, new List<int>(){ 8, 11, 14, 15, 20, 23} },
        { CharaMonsterNoConst.BossHealerNo, new List<int>(){1} },
    };

	/// <summary>
	/// ステージ9のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> ninthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.SlimeRedNo, new List<int>(){ 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 26,   } },
        { CharaMonsterNoConst.ZonbieGreenNo, new List<int>(){ 1, 2, 5, 7 ,10, 25, 27, } },
        { CharaMonsterNoConst.GaitherWhiteNo, new List<int>(){ 3, 6, 8, 22, 23, 28 } },
        { CharaMonsterNoConst.FairyYerrowNo, new List<int>(){ 4, 9, 21, 24} },
    };

	/// <summary>
	/// ステージ10のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> tenthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.GoblinBlackNo, new List<int>(){ 1, 5, 6, 8, 9, 13, 17, 18, 20 ,23, 25,} },
        { CharaMonsterNoConst.GaitherWhiteNo, new List<int>(){ 2, 10, 11, 14, 21, 26,} },
        { CharaMonsterNoConst.YetiGreenNo, new List<int>(){ 3, 7, 15, 19, 22} },
        { CharaMonsterNoConst.FairyYerrowNo, new List<int>(){ 4, 12, 16, 24} },
    };

	/// <summary>
	/// ステージ11のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> eleventhMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.ChimeraPurpleNo, new List<int>(){ 2, 3, 5, 9, 11, 12, 13, 14, 18, 21, 22, 25, 27 } },
		{ CharaMonsterNoConst.GoblinBlackNo, new List<int>(){ 4, 10, 17, 24, 26, 28} },
        { CharaMonsterNoConst.YetiGreenNo, new List<int>(){ 6, 7, 15, 20, 23} },
        { CharaMonsterNoConst.UnicornBlackNo, new List<int>(){ 8, 16, 19, 27  } },
        { CharaMonsterNoConst.IfreetGreenNo, new List<int>(){ 1 } },
    };

	/// <summary>
	/// ステージ12のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> twelfthMonsterMap = new Dictionary<int, List<int>>() {
        { CharaMonsterNoConst.ChimeraPurpleNo, new List<int>(){2, 4, 7, 8, 10, 13, 14, 17, 18, 19, 23, 24, 25, 26, 29, 30, 36, 38 } },
        { CharaMonsterNoConst.OgreOrangeNo, new List<int>(){ 5, 9, 15, 16, 20, 28, 31, 32, 35, 37, 39  } },
        { CharaMonsterNoConst.CentaurBlackNo, new List<int>(){ 6, 11, 21 ,27, 34, 40 } },
        { CharaMonsterNoConst.UnicornBlackNo, new List<int>(){ 3, 12, 22, 33 } },
        { CharaMonsterNoConst.IfreetRedNo, new List<int>(){ 1 } },
    };

	////////////////////////////////////////////////
	// ↓ここから、モンスター登場ペースのマップ↓ //
	////////////////////////////////////////////////

	/// <summary>
	/// ステージ1のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> firstPaceMap = new Dictionary<int, double>() {
		{ 1, 2 }, { 2, 3 }, { 3, 5 }, { 4, 6 }, { 5, 5 }, { 6, 4 }, { 7, 4 }, { 8, 5 }, { 9, 4 }, { 10, 4 },
		{ 11, 3 }, { 12, 4 }, { 13, 3 }, { 14, 4 }, { 15, 2 }, { 16, 3 }, { 17, 3 }, { 18, 2 }, { 19, 2 }, { 20, 1 },
	};

	/// <summary>
	/// ステージ2のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> secondPaceMap = new Dictionary<int, double>() {
        { 1, 2 }, { 2, 4 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 6, 5 }, { 7, 6 }, { 8, 3 }, { 9, 4 }, { 10, 3 },
        { 11, 5 }, { 12, 2 }, { 13, 3 }, { 14, 2 }, { 15, 5 }, { 16, 4 }, { 17, 2 }, { 18, 4 }, { 19, 4 }, { 20, 3 },
    };

    /// <summary>
    /// ステージ3のペースマップ
    /// </summary>
    static readonly Dictionary<int, double> thirdPaceMap = new Dictionary<int, double>() {
        { 1, 2 }, { 2, 4 }, { 3, 4 }, { 4, 6 }, { 5, 4 }, { 6, 5 }, { 7, 5 }, { 8, 5 }, { 9, 4 }, { 10, 4 },
        { 11, 6 }, { 12, 4 }, { 13, 4 }, { 14, 4 }, { 15, 4 }, { 16, 6 }, { 17, 3 }, { 18, 3 }, { 19, 3}, { 20, 2 },
    };

	/// <summary>
	/// ステージ4のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> fourthPaceMap = new Dictionary<int, double>() {
        { 1, 3 }, { 2, 4 }, { 3, 6 }, { 4, 4 }, { 5, 6 }, { 6, 4 }, { 7, 5 }, { 8, 5 }, { 9, 5 }, { 10, 4 },
        { 11, 4 }, { 12, 5 }, { 13, 5 }, { 14, 4 }, { 15, 4 }, { 16, 6 }, { 17, 4 }, { 18, 4 }, { 19, 5}, { 20, 4 },
        { 21, 3 }, { 22, 4 }, { 23, 3 }, { 24, 4 }, { 25, 3 },
    };

	/// <summary>
	/// ステージ5のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> fifthPaceMap = new Dictionary<int, double>() {
        { 1, 3 }, { 2, 4 }, { 3, 5 }, { 4, 6 }, { 5, 5 }, { 6, 6 }, { 7, 5}, { 8, 6 }, { 9, 5 }, { 10, 5 },
        { 11, 4 }, { 12, 6 }, { 13, 6 }, { 14, 5 }, { 15, 5 }, { 16, 6 }, { 17, 4 }, { 18, 3 }, { 19, 3}, { 20, 2 },
        { 21, 2 }, { 22, 2 }, { 23, 1 }, { 24, 2 }, { 25, 1 }
    };

	/// <summary>
	/// ステージ6のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> sixthPaceMap = new Dictionary<int, double>() {
        { 1, 4 }, { 2, 2 }, { 3, 2 }, { 4, 2 }, { 5, 2 }, { 6, 2 }, { 7, 2 }, { 8, 2 }, { 9, 5 }, { 10, 5 },
        { 11, 5 }, { 12, 2 }, { 13, 5 }, { 14, 4 }, { 15, 4 }, { 16, 2 }, { 17, 4 }, { 18, 4 }, { 19, 2 }, { 20, 4 },
        { 21, 5 }, { 22, 5}, { 23, 5 }, { 24, 5 }, { 25, 5 }, { 26, 4 }, { 27, 3 }, { 28, 3 }, { 29, 3 }, { 30, 3 },
		{ 31, 5 }, { 32, 5 }, { 33, 3 }
	};

	/// <summary>
	/// ステージ7のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> seventhPaceMap = new Dictionary<int, double>() {
		{ 1, 4 }, { 2, 4 }, { 3, 2 }, { 4, 4 }, { 5, 3 }, { 6, 3 }, { 7, 3 }, { 8, 2 }, { 9, 3 }, { 10, 2 },
		{ 11, 3 }, { 12, 2 }, { 13, 2 }, { 14, 3 }, { 15, 3 },{ 16, 2 },{ 17, 3 },{ 18, 2 },{ 19, 3 },{ 20, 2 },
	};

	/// <summary>
	/// ステージ8のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> eighthPaceMap = new Dictionary<int, double>() {
        { 1, 1 }, { 2, 1 }, { 3, 3 }, { 4, 4 }, { 5, 6 }, { 6, 5 }, { 7, 6 }, { 8, 5 }, { 9, 5 }, { 10, 4 },
        { 11, 4 }, { 12, 5 }, { 13, 4 }, { 14, 5 }, { 15, 4 }, { 16, 5 }, { 17, 4 }, { 18, 4 }, { 19, 3}, { 20, 2 }, 
		{ 21, 3 }, { 22, 2 }, { 23, 3 }, { 24, 2 }, { 25, 2 },
	};

	/// <summary>
	/// ステージ9のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> ninthPaceMap = new Dictionary<int, double>() {
        { 1, 2 }, { 2, 4 }, { 3, 5 }, { 4, 4 }, { 5, 5 }, { 6, 5 }, { 7, 4 }, { 8, 4 }, { 9, 5 }, { 10, 4 },
        { 11, 4 }, { 12, 2 }, { 13, 3 }, { 14, 2 }, { 15, 3 },{ 16, 2 },{ 17, 2 },{ 18, 3 },{ 19, 2 },{ 20, 3 },
        { 21, 3 },{ 22, 4 },{ 23, 3},{ 24, 3 },{ 25, 3 },{ 26, 2 },{ 27, 3 },{ 28, 2 },
    };

	/// <summary>
	/// ステージ10のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> tenthPaceMap = new Dictionary<int, double>() {
        { 1, 3 }, { 2, 4 }, { 3, 6 }, { 4, 5 }, { 5, 6 }, { 6, 6 }, { 7, 6 }, { 8, 6 }, { 9, 6 }, { 10, 5 },
        { 11, 5 }, { 12, 4 }, { 13, 5 }, { 14, 4 }, { 15, 5 },{ 16, 4 },{ 17, 5 },{ 18, 5 },{ 19, 5 },{ 20, 5 },
        { 21, 4 },{ 22, 4 },{ 23, 3},{ 24, 4 },{ 25, 4 },{ 26, 4 },
    };

	/// <summary>
	/// ステージ11のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> eleventhPaceMap = new Dictionary<int, double>() {
        { 1, 3 }, { 2, 5 }, { 3, 5 }, { 4, 6 }, { 5, 6 }, { 6, 7 }, { 7, 7 }, { 8, 5 }, { 9, 5 }, { 10, 6 },
        { 11, 5 }, { 12, 5 }, { 13, 5 }, { 14, 5 }, { 15, 7 },{ 16, 5 },{ 17, 6 },{ 18, 5 },{ 19, 5 },{ 20, 6 },
        { 21, 5 },{ 22, 4 },{ 23, 6}, { 24, 7}, { 25, 5}, { 26, 7}, { 27, 5}, { 28, 7},
	};

	/// <summary>
	/// ステージ12のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> twelfthPaceMap = new Dictionary<int, double>() {
        { 1, 3 }, { 2, 4 }, { 3, 2 }, { 4, 6 }, { 5, 7 }, { 6, 4 }, { 7, 6 }, { 8, 6 }, { 9, 7 }, { 10, 5 },
        { 11, 6 }, { 12, 7 }, { 13, 5 }, { 14, 5 }, { 15, 6 },{ 16, 5 },{ 17, 6 },{ 18, 5 },{ 19, 5 },{ 20, 6 },
        { 21, 5 },{ 22, 6 },{ 23, 5},{ 24, 6 },{ 25, 4 },{ 26, 5 },{ 27, 4 },{ 28, 6 },{ 29, 4 },{ 30, 3 },
        { 31, 4 },{ 32, 5 },{ 33, 5 },{ 34, 4 }, { 35, 5 }, { 36, 5 }, { 37, 5 }, { 38, 4 }, { 39, 3 }, { 40, 2 }
	};
}