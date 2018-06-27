using UnityEngine;
using UnityEngine.UI;

public class EnergyNumController : MonoBehaviour {

	private const float TimeForEnergyUp = 1.0f;
	
	private int energyNum = 0;
	private float time = TimeForEnergyUp;
	
	void Start () {
	}
	
	void Update () {
        this.time -= Time.deltaTime;
			
        // エネルギー数を増やす
		if(this.time <= 0.0f && this.energyNum < 20){
            this.energyNum += 5;
            this.gameObject.GetComponent<Text>().text = this.energyNum.ToString();
            this.time = TimeForEnergyUp;
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