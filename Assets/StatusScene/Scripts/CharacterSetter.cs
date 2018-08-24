using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステータス画面のキャラクターセッター
/// </summary>
public class CharacterSetter : MonoBehaviour {

    public Sprite fighterASprite;
    public Sprite fighterBSprite;
    public Sprite fighterCSprite;
    public Sprite witchASprite;
    public Sprite witchBSprite;
    public Sprite healerASprite;
    //public Sprite healerBSprite;
    public Sprite healerCSprite;
    //public Sprite guardianASprite;
    //public Sprite guardianBSprite;
    public Sprite supporterASprite;
    public Sprite supporterBSprite;
    
    private GameObject statusGenerator;
    private GameObject charaPrefab;
    private GameObject explanationPrefab;
    private GameObject statusPrefab;
    private GameObject pageNumPrefab;
	
    void Start() {
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
    public void SetFighterA(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.fighterASprite;
        this.explanationPrefab.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterAExp;
        this.statusPrefab.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterAStatus;
        this.statusPrefab.transform.Find("Text2").GetComponent<Text>().text = StatusContents.FighterAStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(225, 490);

		if (charaNum == 1) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All1personPageText1;
        }
        else if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText1;
        }
		else if (charaNum == 3) {
			this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText1;
		}
	}

    /// <summary>
    /// ファイターBを設定する。
    /// </summary>
    /// <param name="charaNum">ファイターキャラ人数</param>
    public void SetFighterB(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.fighterBSprite;
        this.explanationPrefab.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterBExp;
        this.statusPrefab.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterBStatus;
        this.statusPrefab.transform.Find("Text2").GetComponent<Text>().text = StatusContents.FighterBStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(193, 420);

		if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText2;
        }
        else if (charaNum == 3) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText2;
        }
    }

	/// <summary>
	/// ファイターCを設定する。
	/// </summary>
	public void SetFighterC() {
		this.statusGenerator.GetComponent<StatusGenerator>()
					.variables.GetComponent<Variables>().SetJudgeCharaPageNum(3);
		this.charaPrefab.GetComponent<Image>().sprite = this.fighterCSprite;
		this.explanationPrefab.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.FighterCExp;
		this.statusPrefab.transform.Find("Text").GetComponent<Text>().text = StatusContents.FighterCStatus;
		this.statusPrefab.transform.Find("Text2").GetComponent<Text>().text = StatusContents.FighterCStatus2;
		this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText3;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(225, 490);
	}

	/// <summary>
	/// ウィッチAを設定する。
	/// </summary>
	/// <param name="charaNum">ウィッチキャラ人数</param>
	public void SetWitchA(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.witchASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.WitchAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.WitchAStatus;
        this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.WitchAStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(225, 490);

		if (charaNum == 1) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All1personPageText1;
        }
        else if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText1;
        }
        else if (charaNum == 3) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText1;
        }
    }

    /// <summary>
    /// ウィッチBを設定する。
    /// </summary>
    /// <param name="charaNum">ウィッチキャラ人数</param>
    public void SetWitchB(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.witchBSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.WitchBExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.WitchBStatus;
        this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.WitchBStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(207, 450);

		if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText2;
        }
        else if (charaNum == 3) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText2;
        }
    }

    /// <summary>
    /// ヒーラーAを設定する。
    /// </summary>
    /// <param name="charaNum">ヒーラーキャラ人数</param>
    public void SetHealerA(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.healerASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.HealerAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.HealerAStatus;
        this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.HealerAStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(184, 400);

		if (charaNum == 1) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All1personPageText1;
        }
        else if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText1;
        }
        else if (charaNum == 3) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText1;
        }
    }

    /// <summary>
    /// ヒーラーBを設定する。
    /// </summary>
    /// <param name="charaNum">ヒーラーキャラ人数</param>
  //  public void SetHealerB(int charaNum) {
  //      this.statusGenerator.GetComponent<StatusGenerator>()
  //                  .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
  //      this.charaPrefab.GetComponent<Image>().sprite = this.healerBSprite;
  //      this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.HealerBExp;
  //      this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.HealerBStatus;
  //      this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.HealerBStatus2;

		//RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		//charaRectTransform.sizeDelta = new Vector2(225, 490);

		//if (charaNum == 2) {
  //          this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText2;
  //      }
  //      else if (charaNum == 3) {
  //          this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText2;
  //      }
  //  }

    /// <summary>
    /// ヒーラーCを設定する。
    /// </summary>
    public void SetHealerC(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.healerCSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.HealerCExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.HealerCStatus;
        this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.HealerCStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(225, 490);

		if (charaNum == 2) {
			this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText2;
		}
		else if (charaNum == 3) {
			this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText2;
		}
	}

	/// <summary>
	/// ガーディアンAを設定する。
	/// </summary>
	/// <param name="charaNum">ガーディアンキャラ人数</param>
	//public void SetGuardianA(int charaNum)
	//{
	//    this.statusGenerator.GetComponent<StatusGenerator>()
	//                .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
	//    this.charaPrefab.GetComponent<Image>().sprite = this.guardianASprite;
	//    this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.GuardianAExp;
	//    this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.GuardianAStatus;

	//    if (charaNum == 1)
	//    {
	//        this.pageNumPrefab.GetComponent<Text>().text = Consts.All1personPageText1;
	//    }
	//    else if (charaNum == 2)
	//    {
	//        this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText1;
	//    }
	//    else if (charaNum == 3)
	//    {
	//        this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText1;
	//    }
	//}

	/// <summary>
	/// ガーディアンBを設定する。
	/// </summary>
	/// <param name="charaNum">ガーディアンキャラ人数</param>
	//public void SetGuardianB(int charaNum)
	//{
	//    this.statusGenerator.GetComponent<StatusGenerator>()
	//                .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
	//    this.charaPrefab.GetComponent<Image>().sprite = this.guardianBSprite;
	//    this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.GuardianBExp;
	//    this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.GuardianBStatus;

	//    if (charaNum == 2)
	//    {
	//        this.pageNumPrefab.GetComponent<Text>().text = Consts.All2peoplePageText2;
	//    }
	//    else if (charaNum == 3)
	//    {
	//        this.pageNumPrefab.GetComponent<Text>().text = Consts.All3peoplePageText2;
	//    }
	//}

	/// <summary>
	/// サポーターAを設定する。
	/// </summary>
	/// <param name="charaNum">サポーターキャラ人数</param>
	public void SetSupporterA(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.charaPrefab.GetComponent<Image>().sprite = this.supporterASprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.SupporterAExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.SupporterAStatus;
        this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.SupporterAStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(225, 490);

		if (charaNum == 1) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All1personPageText1;
        }
        else if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText1;
        }
        else if (charaNum == 3) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText1;
        }
    }

    /// <summary>
    /// サポーターBを設定する。
    /// </summary>
    /// <param name="charaNum">サポーターキャラ人数</param>
    public void SetSupporterB(int charaNum) {
        this.statusGenerator.GetComponent<StatusGenerator>()
                    .variables.GetComponent<Variables>().SetJudgeCharaPageNum(2);
        this.charaPrefab.GetComponent<Image>().sprite = this.supporterBSprite;
        this.explanationPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = ExplanationContents.SupporterBExp;
        this.statusPrefab.gameObject.transform.Find("Text").GetComponent<Text>().text = StatusContents.SupporterBStatus;
        this.statusPrefab.gameObject.transform.Find("Text2").GetComponent<Text>().text = StatusContents.SupporterBStatus2;

		RectTransform charaRectTransform = this.charaPrefab.GetComponent(typeof(RectTransform)) as RectTransform;
		charaRectTransform.sizeDelta = new Vector2(193, 420);

		if (charaNum == 2) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All2peoplePageText2;
        }
        else if (charaNum == 3) {
            this.pageNumPrefab.GetComponent<Text>().text = StatusSceneConst.All3peoplePageText2;
        }
    }
}