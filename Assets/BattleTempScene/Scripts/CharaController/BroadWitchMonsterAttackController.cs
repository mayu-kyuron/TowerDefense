﻿using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// ウィッチ（遠距離範囲攻撃タイプ）ファイター(複数攻撃)モンスターの攻撃用コントローラー
/// </summary>
public class BroadWitchMonsterAttackController : AttackerMonsterController {

	private Dictionary<string, float> charaHpMap = new Dictionary<string, float>();
	private BroadWitchMonsterController broadWitchMonsterController;
    private CharaController charaController;

	// 攻撃対象キャラクターリスト
	private List<string> attackedCharaList = new List<string>();

	protected override void Awake() {

		// 親のタグ名からモンスターを判断し、ステータスを取得する。
		Dictionary<string, float> thisMonsterStatusMap = this.monsterStatusConst.MonsterStatusMap[transform.root.gameObject.tag];

		this.power = thisMonsterStatusMap[MonsterStatusConst.PowerKey];
		this.timeToAttack = thisMonsterStatusMap[MonsterStatusConst.TimeToAttackKey];
	}

	protected override void Start() {
        this.battleTempGenerator = GameObject.Find("BattleTempGenerator").GetComponent<BattleTempGenerator>();
        this.shipSc = GameObject.Find("Ship").GetComponent<ShipSc>();
        this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();

        // モンスターオブジェクト名を取得する。
        this.monsterObjectName = this.gameObject.name;
        if (this.gameObject.tag == CharaStatusConst.AttackTag) this.monsterObjectName = transform.root.gameObject.name;

        this.broadWitchMonsterController = transform.root.gameObject.GetComponent<BroadWitchMonsterController>();
	}

	protected override void Update() {

		// キャラクターたちの最新HPを取得する。
		this.charaHpMap = this.currentStatusVariables.CurrentCharaHpMap;

		Action();
	}

	protected override void AttackToEnemy() {

		// ループ中にマップの値を変えるため、キーのみをリストに取り出して回す。
		List<string> charaNameList = new List<string>(this.charaHpMap.Keys);

		// 攻撃範囲内にいるキャラクター全員を攻撃する。
		foreach (string charaName in charaNameList) {

			if (this.attackedCharaList.Contains(charaName)) {
				this.charaHpMap[charaName] -= this.power;
                charaController = GameObject.Find(charaName).GetComponent<CharaController>();

                if(charaController == null)
                {
                    shipSc.DisplayDamageUI(this.power);
                }
                else
                {
                    this.charaController.DisplayDamageUI(this.power);
                }
                Debug.Log(String.Format("{0} - {1}.hp = {2}", this.monsterObjectName, charaName, this.charaHpMap[charaName]));
			}
		}

		// 更新した登場キャラクターHPマップを設定する。
		this.currentStatusVariables.SetCurrentCharaHpMap(this.charaHpMap);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == CharaStatusConst.AttackTag) return;

		// 攻撃対象のキャラクター名を登録
		this.attackedCharaList.Add(other.name);
        //Debug.Log(attackedCharaList[0]);
	}

	protected override void OnTriggerStay2D(Collider2D other) {

		// 相手がキャラクターなら攻撃態勢に入る。
		if (this.charaStatusConst.CharaTagList.Contains(other.tag) || other.gameObject.tag == CharaStatusConst.ShipTag) {
			this.isFacingEnemy = true;
			this.broadWitchMonsterController.isMoving = false;
		}
	}

	protected override void OnTriggerExit2D(Collider2D other) {
		this.isFacingEnemy = false;
		this.broadWitchMonsterController.isMoving = true;

		// 攻撃対象リストからキャラクター消去
		this.attackedCharaList.Remove(other.name);
	}
}