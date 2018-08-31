using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// エネルギー表示UIのコントローラー
/// </summary>
public class EnergyNumController : MonoBehaviour {

	private const float TimeForEnergyUp = 0.4f;
    private const float TimeForEnergyUp2 = 0.25f;
    private const float TimeForEnergyUp3 = 0.15f;
    private const float ChangeTime = 45.0f;
    private const int MaxEnergy = 40;

    private int energyNum = 0;
    private float timeForEnergyUp;
    private float time = 0;
    private float totalTime = 0;
	
	void Start () {
        this.timeForEnergyUp = TimeForEnergyUp;
    }
	
	void Update () {
        this.time += Time.deltaTime;
        this.totalTime += Time.deltaTime;

        // エネルギー数を増やす
        if (totalTime > ChangeTime)  this.timeForEnergyUp = TimeForEnergyUp2;

        if(totalTime > ChangeTime * 3)  this.timeForEnergyUp = TimeForEnergyUp3;

        if (this.time >= this.timeForEnergyUp && this.energyNum < MaxEnergy){
            this.time = 0;
            this.energyNum += 1;
            this.gameObject.GetComponent<Text>().text = this.energyNum.ToString();
            
		}
	}
	
    /// <summary>
    /// キャラクター召喚に必要な分のエネルギーを減らす。
    /// </summary>
    /// <param name="charaEnergy">キャラの必要エネルギー</param>
	public void DecreaseEnergy(int charaEnergy){
		this.energyNum -= charaEnergy;
		this.gameObject.GetComponent<Text>().text = this.energyNum.ToString();
	}

	/// <summary>
	/// 残りエネルギーを取得する。
	/// </summary>
	public int EnergyNum
	{
		get { return this.energyNum; }
	}
}