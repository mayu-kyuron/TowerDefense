using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorScript : MonoBehaviour {
	
	//オブジェクトの登録
	public GameObject fighter1Pre;
    public GameObject fighter3Pre;
    public GameObject witch1Pre;
	public GameObject healer1Pre;
	public GameObject slimePre;
	public GameObject gaitherPre;
	
	//public GameObject firstBPre;
	
	//FirstScript firstS;
	
	//出すオブジェクトの宣言
	GameObject go;
	GameObject MGo;

    //最新情報のオブジェクト
    private GameObject latestInfo;
    private LatestInfo latestInfo_sc;

    //確率
    int dice;
	
	//時間
	float time = 0;
	float callTime = 0;

    int stageNum;
	int number;
	int maxNum;
	int deathNum;

    //ステージナンバーとそれに対するモンスターの出現数
    private Dictionary<int, int> stage_monsNumDic = new Dictionary<int, int>();

    //ステージについての情報の構造体
    private struct StageInfo
    {
        public int stageNum;
        public int maxNum;
        public string[] monsterName;
        public int randamNum;
    }

    StageInfo[] stageInfolist = new StageInfo[12];

    // Use this for initialization
    void Start () {

        //最新情報のスクリプト取得
        latestInfo = GameObject.Find("最新情報");
        latestInfo_sc = latestInfo.GetComponent<LatestInfo>();

        //ステージナンバーとそれに対するモンスターの出現数取得
        //stage_monsNumDic = latestInfo_sc.GetStage_monsNum;
        //maxNum = stage_monsNumDic[stageNum];
    }
	
	// Update is called once per frame
	void Update () {
		//if(firstS.flag){

			time += Time.deltaTime;

			if(number < maxNum){
				if(time >= callTime){
					time = 0;
					dice = Random.Range(1, 6);
					if(dice <= 3){
						MGo = Instantiate(slimePre) as GameObject;
					}else{
						MGo = Instantiate(gaitherPre) as GameObject;
					}
					MGo.transform.position = new Vector2(7, -2);
					number++;
					callTime = Random.Range(1, 7);
				}
			}
		//}
		if(deathNum == maxNum){
			Invoke("Clear", 2.0f);
		}
	}
	public void Generate(int charaBango){
		if(charaBango == 1){
			go = Instantiate(fighter1Pre) as GameObject;
		}
		else if(charaBango == 4){
			go = Instantiate(witch1Pre) as GameObject;
		}
		else if(charaBango == 6){
			go = Instantiate(healer1Pre) as GameObject;
		}
		go.transform.position = new Vector2(-7, -2);
	}
	
	public void Count(){
		deathNum++;
	}
	
	void Clear(){
		SceneManager.LoadScene("Clear");
	}
}
