using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウィッチ（遠距離範囲攻撃タイプ）、ファイター複数攻撃の攻撃用コントローラー
/// </summary>
public class BroadWitchAttackController : AttackerController {

    private Dictionary<string, float> monsterHpMap = new Dictionary<string, float>();
	private BroadWitchController broadWitchController;
    private MonsterController monsterController;

    // 攻撃対象モンスターリスト
    private List<string> attackedMonsterList = new List<string>();

	protected override void Awake() {

        double stageNum = 12;
        //double stageNum = double.Parse(GlobalObject.getInstance().Params[0].ToString());//ステージ番号の取得

        Dictionary<string, float> thisCharaStatusMap = new Dictionary<string, float>();

        //オブジェクトのタグ名からキャラを判断し、ステータスを取得する。
        //ステージが7以降はパワーアップ
        if (stageNum <= CharaStatusConst.ChangeNum)
        {
            thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[transform.root.gameObject.tag];
        }
        else
        {
            thisCharaStatusMap = this.charaStatusConst.CharaStatusMap[transform.root.gameObject.tag + CharaStatusConst.SuperTag];
        }

        this.power = thisCharaStatusMap[CharaStatusConst.PowerKey];
		this.timeToAttack = thisCharaStatusMap[CharaStatusConst.TimeToAttackKey];
	}

	protected override void Start() {
		base.Start();
		this.broadWitchController = transform.root.gameObject.GetComponent<BroadWitchController>();
	}

	protected override void AddCharaToMap() {

		// 自分の名前をキーに、攻撃力を登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaPowerToMap(this.charaObjectName, this.power);
	}

	protected override void Update() {

		// モンスターたちの最新HPを取得する。
		this.monsterHpMap = this.currentStatusVariables.CurrentMonsterHpMap;

		Action();
    }

	protected override void AttackToEnemy() {

		// ループ中にマップの値を変えるため、キーのみをリストに取り出して回す。
		List<string> monsterNameList = new List<string>(this.monsterHpMap.Keys);

		// 攻撃範囲内にいるモンスター全員を攻撃する。
		foreach (string monsterName in monsterNameList) {

			if (this.attackedMonsterList.Contains(monsterName)) {
				this.monsterHpMap[monsterName] -= this.power;
                monsterController = GameObject.Find(monsterName).GetComponent<MonsterController>();
                this.monsterController.DisplayDamageUI(this.power);

                Debug.Log(String.Format("{0} - {1}.hp = {2}", this.charaObjectName, monsterName, this.monsterHpMap[monsterName]));
			}
		}

		// 更新した登場モンスターHPマップを設定する。
		this.currentStatusVariables.SetCurrentMonsterHpMap(this.monsterHpMap);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == MonsterStatusConst.AttackTag) return;

        // 攻撃対象のモンスター名を登録
        this.attackedMonsterList.Add(other.name);
    }

	protected override void OnTriggerStay2D(Collider2D other) {

		// 相手がモンスターなら攻撃態勢に入る。
		if (this.monsterStatusConst.MonsterTagList.Contains(other.tag)) {
			this.isFacingEnemy = true;
			this.broadWitchController.isMoving = false;
        }
    }

	protected override void OnTriggerExit2D(Collider2D other) {
		this.isFacingEnemy = false;
		this.broadWitchController.isMoving = true;

		// 攻撃対象リストからモンスター消去
		this.attackedMonsterList.Remove(other.name);
    }
}