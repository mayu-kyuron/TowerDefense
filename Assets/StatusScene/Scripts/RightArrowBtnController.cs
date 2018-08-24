using UnityEngine;

/// <summary>
/// 右矢印ボタンコントローラー
/// </summary>
public class RightArrowBtnController : MonoBehaviour {
    
    private GameObject statusGenerator;
    private GameObject characterSetter;
	
    void Start () {
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.characterSetter = GameObject.Find("CharacterSetter");
    }
	
    void Update () {
		
	}

	public void OnClick() {
        int judgeCharaTypeNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().JudgeCharaTypeNum;

        int judgeCharaPageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().JudgeCharaPageNum;

        double stageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().StageNum;

        // ファイターページのとき
        if (judgeCharaTypeNum == 1) {
            ChangeFighterPage(judgeCharaPageNum, stageNum);
        }
        // ウィッチページのとき
        else if (judgeCharaTypeNum == 2) {
            ChangeWitchPage(judgeCharaPageNum, stageNum);
        }
        // ヒーラーページのとき
        else if (judgeCharaTypeNum == 3) {
            ChangeHealerPage(judgeCharaPageNum, stageNum);
        }
        // ガーディアンページのとき
        //else if (judgeCharaTypeNum == 4)
        //{
        //    ChangeGuardianPage(judgeCharaPageNum, stageNum);
        //}
        // サポーターページのとき
        else if (judgeCharaTypeNum == 5) {
            ChangeSupporterPage(judgeCharaPageNum, stageNum);
        }
        // モンスターページのとき
        //else if (judgeCharaTypeNum == 6)
        //{
        //    ChangeMonsterPage(judgeCharaPageNum, stageNum);
        //}
    }

    /// <summary>
    /// ページ表示ファイターキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    /// <param name="stageNum">ステージ番号</param>
    private void ChangeFighterPage(int judgeCharaPageNum, double stageNum) {
        int charaNum;

        // キャラクターの人数判断       
        if (stageNum < StatusSceneConst.Fighter2peopleStageNum) {
            charaNum = 1;
        }
		else if (stageNum < StatusSceneConst.Fighter3peopleStageNum) {
            charaNum = 2;
		}
        else {
			charaNum = 3;
		}

		// キャラクター2人のとき
		if (charaNum == 2) {
            if (judgeCharaPageNum == 1) {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterB(charaNum);
            }
            else if (judgeCharaPageNum == 2) {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterA(charaNum);
            }
        }
		// キャラクター3人のとき
		else if (charaNum == 3) {
			if (judgeCharaPageNum == 1) {
				this.characterSetter.GetComponent<CharacterSetter>().SetFighterB(charaNum);
			}
			else if (judgeCharaPageNum == 2) {
				this.characterSetter.GetComponent<CharacterSetter>().SetFighterC();
			}
			else if (judgeCharaPageNum == 3) {
				this.characterSetter.GetComponent<CharacterSetter>().SetFighterA(charaNum);
			}
		}
	}

    /// <summary>
    /// ページ表示ウィッチキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    /// <param name="stageNum">ステージ番号</param>
    private void ChangeWitchPage(int judgeCharaPageNum, double stageNum) {
        int charaNum;

        // キャラクターの人数判断       
        if (stageNum < StatusSceneConst.Witch2peopleStageNum) {
            charaNum = 1;
        }
        else {
            charaNum = 2;
        }

        // キャラクター2人のとき
        if (charaNum == 2) {
            if (judgeCharaPageNum == 1) {
                this.characterSetter.GetComponent<CharacterSetter>().SetWitchB(charaNum);
            }
            else if (judgeCharaPageNum == 2) {
                this.characterSetter.GetComponent<CharacterSetter>().SetWitchA(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示ヒーラーキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    /// <param name="stageNum">ステージ番号</param>
    private void ChangeHealerPage(int judgeCharaPageNum, double stageNum) {
        int charaNum;

        // キャラクターの人数判断       
        if (stageNum < StatusSceneConst.Healer2peopleStageNum) {
            charaNum = 1;
        }
		//else if (stageNum < StatusSceneConst.Healer3peopleStageNum)
		else {
            charaNum = 2;
        }
        //else {
        //    charaNum = 3;
        //}

        // キャラクター2人のとき
        if (charaNum == 2) {
            if (judgeCharaPageNum == 1) {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerC(charaNum);
            }
            else if (judgeCharaPageNum == 2) {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerA(charaNum);
            }
        }
        // キャラクター3人のとき
        //else if (charaNum == 3) {
        //    if (judgeCharaPageNum == 1) {
        //        this.characterSetter.GetComponent<CharacterSetter>().SetHealerB(charaNum);
        //    }
        //    else if (judgeCharaPageNum == 2) {
        //        this.characterSetter.GetComponent<CharacterSetter>().SetHealerC();
        //    }
        //    else if (judgeCharaPageNum == 3) {
        //        this.characterSetter.GetComponent<CharacterSetter>().SetHealerA(charaNum);
        //    }
        //}
    }

    /// <summary>
    /// ページ表示ガーディアンキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    /// <param name="stageNum">ステージ番号</param>
    //private void ChangeGuardianPage(int judgeCharaPageNum, double stageNum) {
    //    int charaNum;

    //    // キャラクターの人数判断       
    //    if (stageNum < Consts.Guardian2peopleStageNum) {
    //        charaNum = 1;
    //    }
    //    else {
    //        charaNum = 2;
    //    }

    //    // キャラクター2人のとき
    //    if (charaNum == 2) {
    //        if (judgeCharaPageNum == 1) {
    //            this.characterSetter.GetComponent<CharacterSetter>().SetGuardianB(charaNum);
    //        }
    //        else if (judgeCharaPageNum == 2) {
    //            this.characterSetter.GetComponent<CharacterSetter>().SetGuardianA(charaNum);
    //        }
    //    }
    //}

    /// <summary>
    /// ページ表示サポーターキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    /// <param name="stageNum">ステージ番号</param>
    private void ChangeSupporterPage(int judgeCharaPageNum, double stageNum) {
        int charaNum;

        // キャラクターの人数判断       
        if (stageNum < StatusSceneConst.Supporter2peopleStageNum) {
            charaNum = 1;
        }
        else {
            charaNum = 2;
        }

        // キャラクター2人のとき
        if (charaNum == 2) {
            if (judgeCharaPageNum == 1) {
                this.characterSetter.GetComponent<CharacterSetter>().SetSupporterB(charaNum);
            }
            else if (judgeCharaPageNum == 2) {
                this.characterSetter.GetComponent<CharacterSetter>().SetSupporterA(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示モンスターキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    /// <param name="stageNum">ステージ番号</param>
    //private void ChangeMonsterPage(int judgeCharaPageNum, double stageNum) {

    //}
}