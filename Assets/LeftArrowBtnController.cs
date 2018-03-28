using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrowBtnController : MonoBehaviour {

    private double stageNum;
    private GameObject statusGenerator;
    private GameObject characterSetter;

    // Use this for initialization
    void Start () {
        //this.stageNum = 9;
        this.stageNum = double.Parse(GlobalObject.getInstance().StringParam);
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.characterSetter = GameObject.Find("CharacterSetter");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        int judgeCharaTypeNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().JudgeCharaTypeNum;

        int judgeCharaPageNum = this.statusGenerator.GetComponent<StatusGenerator>()
            .variables.GetComponent<Variables>().JudgeCharaPageNum;

        // ファイターページのとき
        if (judgeCharaTypeNum == 1)
        {
            ChangeFighterPage(judgeCharaPageNum);
        }
        // ウィッチページのとき
        else if (judgeCharaTypeNum == 2)
        {
            ChangeWitchPage(judgeCharaPageNum);
        }
        // ヒーラーページのとき
        else if (judgeCharaTypeNum == 3)
        {
            ChangeHealerPage(judgeCharaPageNum);
        }
        // ガーディアンページのとき
        else if (judgeCharaTypeNum == 4)
        {
            ChangeGuardianPage(judgeCharaPageNum);
        }
        // サポーターページのとき
        else if (judgeCharaTypeNum == 5)
        {
            ChangeSupporterPage(judgeCharaPageNum);
        }
        // モンスターページのとき
        else if (judgeCharaTypeNum == 6)
        {
            ChangeMonsterPage(judgeCharaPageNum);
        }
    }

    /// <summary>
    /// ページ表示ファイターキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    private void ChangeFighterPage(int judgeCharaPageNum)
    {
        int charaNum;

        // キャラクターの人数判断       
        if (this.stageNum < Consts.Fighter2peopleStageNum)
        {
            charaNum = 1;
        }
        else if (this.stageNum < Consts.Fighter3peopleStageNum)
        {
            charaNum = 2;
        }
        else
        {
            charaNum = 3;
        }

        // キャラクター2人のとき
        if (charaNum == 2)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterB(charaNum);
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterA(charaNum);
            }
        }
        // キャラクター3人のとき
        else if (charaNum == 3)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterC();
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterA(charaNum);
            }
            else if (judgeCharaPageNum == 3)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetFighterB(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示ウィッチキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    private void ChangeWitchPage(int judgeCharaPageNum)
    {
        int charaNum;

        // キャラクターの人数判断       
        if (this.stageNum < Consts.Witch2peopleStageNum)
        {
            charaNum = 1;
        }
        else
        {
            charaNum = 2;
        }

        // キャラクター2人のとき
        if (charaNum == 2)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetWitchB(charaNum);
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetWitchA(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示ヒーラーキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    private void ChangeHealerPage(int judgeCharaPageNum)
    {
        int charaNum;

        // キャラクターの人数判断       
        if (this.stageNum < Consts.Healer2peopleStageNum)
        {
            charaNum = 1;
        }
        else if (this.stageNum < Consts.Healer3peopleStageNum)
        {
            charaNum = 2;
        }
        else
        {
            charaNum = 3;
        }

        // キャラクター2人のとき
        if (charaNum == 2)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerB(charaNum);
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerA(charaNum);
            }
        }
        // キャラクター3人のとき
        else if (charaNum == 3)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerC();
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerA(charaNum);
            }
            else if (judgeCharaPageNum == 3)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetHealerB(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示ガーディアンキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    private void ChangeGuardianPage(int judgeCharaPageNum)
    {
        int charaNum;

        // キャラクターの人数判断       
        if (this.stageNum < Consts.Guardian2peopleStageNum)
        {
            charaNum = 1;
        }
        else
        {
            charaNum = 2;
        }

        // キャラクター2人のとき
        if (charaNum == 2)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetGuardianB(charaNum);
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetGuardianA(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示サポーターキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    private void ChangeSupporterPage(int judgeCharaPageNum)
    {
        int charaNum;

        // キャラクターの人数判断       
        if (this.stageNum < Consts.Supporter2peopleStageNum)
        {
            charaNum = 1;
        }
        else
        {
            charaNum = 2;
        }

        // キャラクター2人のとき
        if (charaNum == 2)
        {
            if (judgeCharaPageNum == 1)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetSupporterB(charaNum);
            }
            else if (judgeCharaPageNum == 2)
            {
                this.characterSetter.GetComponent<CharacterSetter>().SetSupporterA(charaNum);
            }
        }
    }

    /// <summary>
    /// ページ表示モンスターキャラを変更する。
    /// </summary>
    /// <param name="judgeCharaPageNum">ページ番号</param>
    private void ChangeMonsterPage(int judgeCharaPageNum)
    {

    }
}
