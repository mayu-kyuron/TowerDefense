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
		{ CharaMonsterNoConst.SlimeNo, new List<int>(){ 1, 2, 3, 5, 8, 9, 13, 15, 17, 18, 19 } },
		{ CharaMonsterNoConst.GaitherNo, new List<int>(){ 4, 6, 7, 10, 11, 12, 14, 16, 20 } },
	};

	/// <summary>
	/// ステージ2のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> secondMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ3のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> thirdMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ4のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> fourthMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ5のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> fifthMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ6のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> sixthMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ7のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> seventhMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ8のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> eighthMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ9のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> ninthMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ10のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> tenthMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ11のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> eleventhMonsterMap = new Dictionary<int, List<int>>() {

	};

	/// <summary>
	/// ステージ12のモンスターマップ
	/// </summary>
	static readonly Dictionary<int, List<int>> twelfthMonsterMap = new Dictionary<int, List<int>>() {

	};

	////////////////////////////////////////////////
	// ↓ここから、モンスター登場ペースのマップ↓ //
	////////////////////////////////////////////////

	/// <summary>
	/// ステージ1のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> firstPaceMap = new Dictionary<int, double>() {
		{ 1, 0 }, { 2, 1 }, { 3, 1 }, { 4, 2 }, { 5, 1 }, { 6, 1 }, { 7, 3 }, { 8, 2 }, { 9, 1 }, { 10, 1 },
		{ 11, 2 }, { 12, 2 }, { 13, 3 }, { 14, 2 }, { 15, 1 }, { 16, 3 }, { 17, 2 }, { 18, 2 }, { 19, 2 }, { 20, 3 },
	};

	/// <summary>
	/// ステージ2のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> secondPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ3のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> thirdPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ4のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> fourthPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ5のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> fifthPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ6のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> sixthPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ7のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> seventhPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ8のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> eighthPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ9のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> ninthPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ10のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> tenthPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ11のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> eleventhPaceMap = new Dictionary<int, double>() {

	};

	/// <summary>
	/// ステージ12のペースマップ
	/// </summary>
	static readonly Dictionary<int, double> twelfthPaceMap = new Dictionary<int, double>() {

	};
}