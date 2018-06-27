using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetter : MonoBehaviour {

    public Sprite fighterASprite;
    public Sprite fighterBSprite;
    public Sprite fighterCSprite;
    public Sprite witchASprite;
    public Sprite witchBSprite;
    public Sprite healerASprite;
    public Sprite healerBSprite;
    public Sprite healerCSprite;
    public Sprite guardianASprite;
    public Sprite guardianBSprite;
    public Sprite supporterASprite;
    public Sprite supporterBSprite;
    
    private GameObject statusGenerator;
    private GameObject charaPrefab;
    private GameObject explanationPrefab;
    private GameObject statusPrefab;
    private GameObject pageNumPrefab;

    // Use this for initialization
    void Start()
    {
        this.statusGenerator = GameObject.Find("StatusGenerator");
        this.charaPrefab = GameObject.Find("charaPrefab(Clone)");
        this.explanationPrefab = GameObject.Find("explanationPrefab(Clone)");
        this.statusPrefab = GameObject.Find("statusPrefab(Clone)");
        this.pageNumPrefab = GameObject.Find("pageNumPrefab(Clone)");
    }

    /// <summary>
    /// ファイターAを設定する。
    /// </summary>
    /// <param name="charaNum">ファイターキャラ人数</param>
    public void SetFighterA(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.fighterASprite;
        this.explanationPrefab.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterAExp;
        this.statusPrefab.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterAStatus;

        if (charaNum == 1)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }

    /// <summary>
    /// ファイターBを設定する。
    /// </summary>
    /// <param name="charaNum">ファイターキャラ人数</param>
    public void SetFighterB(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.fighterBSprite;
        this.explanationPrefab.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterBExp;
        this.statusPrefab.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterBStatus;

        if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText2;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText2;
        }
    }

    /// <summary>
    /// ファイターCを設定する。
    /// </summary>
    public void SetFighterC()
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(3);
        this.charaPrefab.GetComponent<Image>().sprite = this.fighterCSprite;
        this.explanationPrefab.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterCExp;
        this.statusPrefab.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterCStatus;
        this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText3;
    }

    /// <summary>
    /// ウィッチAを設定する。
    /// </summary>
    /// <param name="charaNum">ウィッチキャラ人数</param>
    public void SetWitchA(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.witchASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.WitchAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.WitchAStatus;

        if (charaNum == 1)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }

    /// <summary>
    /// ウィッチBを設定する。
    /// </summary>
    /// <param name="charaNum">ウィッチキャラ人数</param>
    public void SetWitchB(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.witchBSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.WitchBExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.WitchBStatus;

        if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText2;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText2;
        }
    }

    /// <summary>
    /// ヒーラーAを設定する。
    /// </summary>
    /// <param name="charaNum">ヒーラーキャラ人数</param>
    public void SetHealerA(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.healerASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.HealerAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.HealerAStatus;

        if (charaNum == 1)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }

    /// <summary>
    /// ヒーラーBを設定する。
    /// </summary>
    /// <param name="charaNum">ヒーラーキャラ人数</param>
    public void SetHealerB(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.healerBSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.HealerBExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.HealerBStatus;

        if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText2;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText2;
        }
    }

    /// <summary>
    /// ヒーラーCを設定する。
    /// </summary>
    public void SetHealerC()
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(3);
        this.charaPrefab.GetComponent<Image>().sprite = this.healerCSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.HealerCExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.HealerCStatus;
        this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText3;
    }

    /// <summary>
    /// ガーディアンAを設定する。
    /// </summary>
    /// <param name="charaNum">ガーディアンキャラ人数</param>
    public void SetGuardianA(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.guardianASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.GuardianAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.GuardianAStatus;

        if (charaNum == 1)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }

    /// <summary>
    /// ガーディアンBを設定する。
    /// </summary>
    /// <param name="charaNum">ガーディアンキャラ人数</param>
    public void SetGuardianB(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.guardianBSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.GuardianBExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.GuardianBStatus;

        if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText2;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText2;
        }
    }

    /// <summary>
    /// サポーターAを設定する。
    /// </summary>
    /// <param name="charaNum">サポーターキャラ人数</param>
    public void SetSupporterA(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.supporterASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.SupporterAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.SupporterAStatus;

        if (charaNum == 1)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }

    /// <summary>
    /// サポーターBを設定する。
    /// </summary>
    /// <param name="charaNum">サポーターキャラ人数</param>
    public void SetSupporterB(int charaNum)
    {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.supporterBSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.SupporterBExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.SupporterBStatus;

        if (charaNum == 2)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText2;
        }
        else if (charaNum == 3)
        {
            this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText2;
        }
    }
}
