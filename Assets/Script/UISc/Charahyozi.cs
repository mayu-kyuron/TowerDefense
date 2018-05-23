using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charahyozi : MonoBehaviour {

    public static int EmptyImageCount = 5;
    public static int CharaBtnCount = 13;

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
    public Sprite emptySprite;
    public Dictionary<int, Sprite> spriteNumMap = new Dictionary<int, Sprite>();

    public GameObject directionalLight;
    public GameObject charaBtnPrefab;
    public GameObject clearBtnPrefab;
    public GameObject selectBtnPrefab;
    public GameObject emptyImgPrefab;
    public GameObject cautionText;

    public bool selectedAnyChara = false;
    public Image[] emptyImages = new Image[EmptyImageCount];

    private Light sunLight;
    private Sprite[] sprites;
    private SelectBtnController[] selectBtnControllers = new SelectBtnController[EmptyImageCount];

    // Use this for initialization
    void Start () {
        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        //this.sunLight = directionalLight.GetComponent<Light>();

        this.sprites = new Sprite[] { fighterASprite, fighterBSprite, fighterCSprite,
            witchASprite, witchBSprite, healerASprite, healerBSprite, healerCSprite,
            guardianASprite, guardianBSprite, supporterASprite, supporterBSprite };

        for (int i = 0; i < this.sprites.Length; i++)
        {
            this.spriteNumMap.Add(i, this.sprites[i]);
        }

        // キャラクターボタン表示
        GameObject charaBtnInstance1 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance1.transform.position = new Vector3(230, 182, 0);
        charaBtnInstance1.GetComponent<Image>().sprite = this.fighterASprite;
        charaBtnInstance1.transform.SetParent(canvas.transform, false);
        charaBtnInstance1.name = "charaBtnInstance1";

        GameObject charaBtnInstance2 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance2.transform.position = new Vector3(285, 182, 0);
        charaBtnInstance2.GetComponent<Image>().sprite = this.fighterBSprite;
        charaBtnInstance2.transform.SetParent(canvas.transform, false);
        charaBtnInstance2.name = "charaBtnInstance2";

        GameObject charaBtnInstance3 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance3.transform.position = new Vector3(340, 182, 0);
        charaBtnInstance3.GetComponent<Image>().sprite = this.fighterCSprite;
        charaBtnInstance3.transform.SetParent(canvas.transform, false);
        charaBtnInstance3.name = "charaBtnInstance3";

        GameObject charaBtnInstance4 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance4.transform.position = new Vector3(230, 130, 0);
        charaBtnInstance4.GetComponent<Image>().sprite = this.witchASprite;
        charaBtnInstance4.transform.SetParent(canvas.transform, false);
        charaBtnInstance4.name = "charaBtnInstance4";

        GameObject charaBtnInstance5 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance5.transform.position = new Vector3(285, 130, 0);
        charaBtnInstance5.GetComponent<Image>().sprite = this.witchBSprite;
        charaBtnInstance5.transform.SetParent(canvas.transform, false);
        charaBtnInstance5.name = "charaBtnInstance5";

        GameObject charaBtnInstance6 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance6.transform.position = new Vector3(230, 78, 0);
        charaBtnInstance6.GetComponent<Image>().sprite = this.healerASprite;
        charaBtnInstance6.transform.SetParent(canvas.transform, false);
        charaBtnInstance6.name = "charaBtnInstance6";

        GameObject charaBtnInstance7 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance7.transform.position = new Vector3(285, 78, 0);
        charaBtnInstance7.GetComponent<Image>().sprite = this.healerBSprite;
        charaBtnInstance7.transform.SetParent(canvas.transform, false);
        charaBtnInstance7.name = "charaBtnInstance7";

        GameObject charaBtnInstance8 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance8.transform.position = new Vector3(340, 78, 0);
        charaBtnInstance8.GetComponent<Image>().sprite = this.healerCSprite;
        charaBtnInstance8.transform.SetParent(canvas.transform, false);
        charaBtnInstance8.name = "charaBtnInstance8";

        GameObject charaBtnInstance9 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance9.transform.position = new Vector3(230, 26, 0);
        charaBtnInstance9.GetComponent<Image>().sprite = this.guardianASprite;
        charaBtnInstance9.transform.SetParent(canvas.transform, false);
        charaBtnInstance9.name = "charaBtnInstance9";

        GameObject charaBtnInstance10 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance10.transform.position = new Vector3(285, 26, 0);
        charaBtnInstance10.GetComponent<Image>().sprite = this.guardianBSprite;
        charaBtnInstance10.transform.SetParent(canvas.transform, false);
        charaBtnInstance10.name = "charaBtnInstance10";

        GameObject charaBtnInstance11 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance11.transform.position = new Vector3(230, -26, 0);
        charaBtnInstance11.GetComponent<Image>().sprite = this.supporterASprite;
        charaBtnInstance11.transform.SetParent(canvas.transform, false);
        charaBtnInstance11.name = "charaBtnInstance11";

        GameObject charaBtnInstance12 = Instantiate(this.charaBtnPrefab) as GameObject;
        charaBtnInstance12.transform.position = new Vector3(285, -26, 0);
        charaBtnInstance12.GetComponent<Image>().sprite = this.supporterBSprite;
        charaBtnInstance12.transform.SetParent(canvas.transform, false);
        charaBtnInstance12.name = "charaBtnInstance12";

        GameObject charaBtnInstance13 = Instantiate(this.clearBtnPrefab) as GameObject;
        charaBtnInstance13.transform.position = new Vector3(250, -78, 0);
        charaBtnInstance13.transform.SetParent(canvas.transform, false);
        charaBtnInstance13.name = "charaBtnInstance13";

        var charaBtnControllers = new CharaBtnController[CharaBtnCount];
        for (int i = 0; i < charaBtnControllers.Length; i++)
        {
            var instanceName = String.Format("charaBtnInstance{0}", i + 1);
            charaBtnControllers[i] = GameObject.Find(instanceName).GetComponent<CharaBtnController>();
        }

        // 選択ボタン表示
        GameObject selectBtnInstance1 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance1.transform.position = new Vector3(-300, -177, 0);
        selectBtnInstance1.transform.SetParent(canvas.transform, false);
        selectBtnInstance1.name = "selectBtnInstance1";

        GameObject selectBtnInstance2 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance2.transform.position = new Vector3(-197.5f, -177, 0);
        selectBtnInstance2.transform.SetParent(canvas.transform, false);
        selectBtnInstance2.name = "selectBtnInstance2";

        GameObject selectBtnInstance3 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance3.transform.position = new Vector3(-95, -177, 0);
        selectBtnInstance3.transform.SetParent(canvas.transform, false);
        selectBtnInstance3.name = "selectBtnInstance3";

        GameObject selectBtnInstance4 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance4.transform.position = new Vector3(7.5f, -177, 0);
        selectBtnInstance4.transform.SetParent(canvas.transform, false);
        selectBtnInstance4.name = "selectBtnInstance4";

        GameObject selectBtnInstance5 = Instantiate(this.selectBtnPrefab) as GameObject;
        selectBtnInstance5.transform.position = new Vector3(110, -177, 0);
        selectBtnInstance5.transform.SetParent(canvas.transform, false);
        selectBtnInstance5.name = "selectBtnInstance5";

        for (int i = 0; i < this.selectBtnControllers.Length; i++)
        {
            var instanceName = String.Format("selectBtnInstance{0}", i + 1);
            this.selectBtnControllers[i] = GameObject.Find(instanceName).GetComponent<SelectBtnController>();
        }

        foreach (CharaBtnController charaBtnController in charaBtnControllers)
        {
            charaBtnController.SetSelectBtnControllers();
        }

        // 選択キャラ表示用の空イメージ表示
        GameObject emptyImgInstance1 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance1.transform.position = new Vector3(-300, -62, 0);
        emptyImgInstance1.transform.SetParent(canvas.transform, false);
        emptyImgInstance1.name = "emptyImgInstance1";

        GameObject emptyImgInstance2 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance2.transform.position = new Vector3(-197.5f, -62, 0);
        emptyImgInstance2.transform.SetParent(canvas.transform, false);
        emptyImgInstance2.name = "emptyImgInstance2";

        GameObject emptyImgInstance3 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance3.transform.position = new Vector3(-95, -62, 0);
        emptyImgInstance3.transform.SetParent(canvas.transform, false);
        emptyImgInstance3.name = "emptyImgInstance3";

        GameObject emptyImgInstance4 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance4.transform.position = new Vector3(7.5f, -62, 0);
        emptyImgInstance4.transform.SetParent(canvas.transform, false);
        emptyImgInstance4.name = "emptyImgInstance4";

        GameObject emptyImgInstance5 = Instantiate(this.emptyImgPrefab) as GameObject;
        emptyImgInstance5.transform.position = new Vector3(110, -62, 0);
        emptyImgInstance5.transform.SetParent(canvas.transform, false);
        emptyImgInstance5.name = "emptyImgInstance5";

        for (int i = 0; i < EmptyImageCount; i++)
        {
            var instanceName = String.Format("emptyImgInstance{0}", i + 1);
            this.emptyImages[i] = GameObject.Find(instanceName).GetComponent<Image>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DisplayAndStoreCharaBtns()
    {

    }

    /// <summary>
    /// 選択されたボタン以外の真偽値をfalseに設定する。
    /// </summary>
    /// <param name="selectBtnInstance">選択されたボタン</param>
    public void SetFalseToOtherSelectBtns(GameObject selectBtnInstance)
    {
        foreach (SelectBtnController selectBtnController in this.selectBtnControllers)
        {
            selectBtnController.selected = false;
        }

        selectBtnInstance.GetComponent<SelectBtnController>().selected = true;
    }
	
    /// <summary>
    /// キャラクターを選択キャラ表示欄に表示する。
    /// </summary>
    /// <param name="charaNum">キャラクター番号</param>
	public void DisplayCharaAtSelectedArea(int charaNum)
    {
        if (charaNum != CharaBtnCount - 1) this.selectedAnyChara = true;

        bool[] selectedBtns = new bool[EmptyImageCount];
        for (int i = 0; i < selectedBtns.Length; i++)
        {
            selectedBtns[i] = this.selectBtnControllers[i].GetComponent<SelectBtnController>().selected;
        }

        // 選択されたボタンを特定
        for (int i = 0; i < selectedBtns.Length; i++)
        {
            if (selectedBtns[i])
            {
                var emptySpriteList = new List<Sprite>();
                foreach (Image image in emptyImages)
                {
                    emptySpriteList.Add(image.sprite);
                }

                if (charaNum != CharaBtnCount - 1 && emptySpriteList.Contains(this.sprites[charaNum]))
                {
                    this.cautionText.GetComponent<Text>().text = "同じキャラクターは選択できません！";
                }
                // 重複のないキャラクターボタンが選択された場合
                else
                {
                    if (charaNum == CharaBtnCount - 1)
                    {
                        this.emptyImages[i].sprite = emptySprite;
                    }
                    else
                    {
                        this.emptyImages[i].sprite = this.sprites[charaNum];
                    }
                }

                selectedBtns[i] = false;
            }
        }
		
		//this.sunLight.color = new Color(0, 0, 0, 1);
	}
}
