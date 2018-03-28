using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusGenerator : MonoBehaviour {

    public GameObject backBtnPrefab;
    public GameObject fighterBtnPrefab;
    public GameObject witchBtnPrefab;
    public GameObject healerBtnPrefab;
    public GameObject guardianBtnPrefab;
    public GameObject supporterBtnPrefab;
    public GameObject monsterBtnPrefab;
    public GameObject charaPrefab;
    public GameObject explanationPrefab;
    public GameObject statusPrefab;
    public GameObject leftArrowBtnPrefab;
    public GameObject rightArrowBtnPrefab;
    public GameObject pageNumPrefab;
    public GameObject variables;

    private double stageNum;
    private Canvas canvas;

    // Use this for initialization
    void Start () {

        string expText = ExplanationContents.FighterAExp;
        string statusText = StatusContents.FighterAStatus;

        this.canvas = GameObject.FindObjectOfType<Canvas>();
        //this.stageNum = 9;
        this.stageNum = double.Parse(GlobalObject.getInstance().StringParam);

        // ボタン表示
        GameObject backBtnInstance = Instantiate(this.backBtnPrefab) as GameObject;
        backBtnInstance.transform.position = new Vector3(-450, 260, 0);
        backBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject fighterBtnInstance = Instantiate(this.fighterBtnPrefab) as GameObject;
        fighterBtnInstance.transform.position = new Vector3(-400, 170, 0);
        fighterBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject witchBtnInstance = Instantiate(this.witchBtnPrefab) as GameObject;
        witchBtnInstance.transform.position = new Vector3(-400, 90, 0);
        witchBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject healerBtnInstance = Instantiate(this.healerBtnPrefab) as GameObject;
        healerBtnInstance.transform.position = new Vector3(-400, 10, 0);
        healerBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject guardianBtnInstance = Instantiate(this.guardianBtnPrefab) as GameObject;
        guardianBtnInstance.transform.position = new Vector3(-400, -70, 0);
        guardianBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject supporterBtnInstance = Instantiate(this.supporterBtnPrefab) as GameObject;
        supporterBtnInstance.transform.position = new Vector3(-400, -150, 0);
        supporterBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject monsterBtnInstance = Instantiate(this.monsterBtnPrefab) as GameObject;
        monsterBtnInstance.transform.position = new Vector3(-400, -230, 0);
        monsterBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject leftArrowBtnInstance = Instantiate(this.leftArrowBtnPrefab) as GameObject;
        leftArrowBtnInstance.transform.position = new Vector3(-50, -255, 0);
        leftArrowBtnInstance.transform.SetParent(this.canvas.transform, false);

        GameObject rightArrowBtnInstance = Instantiate(this.rightArrowBtnPrefab) as GameObject;
        rightArrowBtnInstance.transform.position = new Vector3(280, -255, 0);
        rightArrowBtnInstance.transform.SetParent(this.canvas.transform, false);

        // キャラクター表示
        GameObject charaInstance = Instantiate(this.charaPrefab) as GameObject;
        charaInstance.transform.position = new Vector3(-140, 45, 0);
        charaInstance.transform.SetParent(this.canvas.transform, false);

        // 説明ウィンドウ表示
        GameObject explanationInstance = Instantiate(this.explanationPrefab) as GameObject;
        explanationInstance.transform.position = new Vector3(250, 120, 0);
        explanationInstance.transform.SetParent(this.canvas.transform, false);

        // ステータスウィンドウ表示
        GameObject statusInstance = Instantiate(this.statusPrefab) as GameObject;
        statusInstance.transform.position = new Vector3(250, -120, 0);
        statusInstance.transform.SetParent(this.canvas.transform, false);

        // ページ番号表示
        GameObject pageNumInstance = Instantiate(this.pageNumPrefab) as GameObject;
        pageNumInstance.transform.position = new Vector3(142, -263, 0);
        pageNumInstance.transform.SetParent(this.canvas.transform, false);

        // 初期設定（ファイターAのステータスを表示）
        this.variables.GetComponent<Variables>().SetJudgeCharaTypeNum(1);
        this.variables.GetComponent<Variables>().SetJudgeCharaPageNum(1);
        this.canvas.gameObject.transform.FindChild("explanationPrefab(Clone)")
            .gameObject.transform.Find("Text").GetComponent<Text>().text = expText;
        this.canvas.gameObject.transform.FindChild("statusPrefab(Clone)")
            .gameObject.transform.Find("Text").GetComponent<Text>().text = statusText;

        if (this.stageNum == 1)
        {
            guardianBtnInstance.GetComponent<Button>().interactable = false;
            supporterBtnInstance.GetComponent<Button>().interactable = false;
            monsterBtnInstance.GetComponent<Button>().interactable = false;

            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (this.stageNum == 2)
        {
            guardianBtnInstance.GetComponent<Button>().interactable = false;
            supporterBtnInstance.GetComponent<Button>().interactable = false;

            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (this.stageNum == 3)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (this.stageNum == 4)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All1personPageText1;
        }
        else if (this.stageNum == 5)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (this.stageNum == 6)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (this.stageNum == 7)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (this.stageNum == 8)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (this.stageNum == 9)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All2peoplePageText1;
        }
        else if (this.stageNum == 10)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All3peoplePageText1;

        }
        else if (this.stageNum == 11)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
        else if (this.stageNum == 12)
        {
            pageNumInstance.GetComponent<Text>().text = Consts.All3peoplePageText1;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
