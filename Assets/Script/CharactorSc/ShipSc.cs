using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 飛行船のコントローラー
/// </summary>
public class ShipSc : MonoBehaviour {

	[HideInInspector]
	public float hp = 200f;

	private const float SpeedScreenFadeout = 0.5f;
	private const float SpeedTextFadein = 0.2f;

	private Canvas canvas;
	private CurrentStatusVariables currentStatusVariables;
	private BattleTempGenerator battleTempGenerator;
	public GameObject damageUI;
	public GameObject hiddenScreenImageUI;
	public GameObject gameOverTextUI;
	private Image hiddenScreenImage;
	private Text gameOverText;
	private Slider slider;

	private float screenClearness = 0.0f;
	private float textClearness = 0.0f;
	private float time = 0.0f;

	private Dictionary<string, float> currentCharaHpMap = new Dictionary<string, float>();
	
    void Start () {
		this.canvas = GameObject.FindObjectOfType<Canvas>();
		this.slider = GameObject.Find("HPgage").GetComponent<Slider>();
        this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();
		this.battleTempGenerator = GameObject.Find("BattleTempGenerator").GetComponent<BattleTempGenerator>();
		this.hiddenScreenImage = this.hiddenScreenImageUI.GetComponent<Image>();
		this.gameOverText = this.gameOverTextUI.GetComponent<Text>();

		// 自分の名前をキーに、HPを登場キャラマップに登録する。
		this.currentStatusVariables.AddCharaHpToMap(this.gameObject.name, this.hp);
    }
	
	void Update () {

		// 最新のHPを取得し、スライダーに反映する。
        this.currentCharaHpMap = this.currentStatusVariables.CurrentCharaHpMap;
        this.hp = this.currentCharaHpMap[this.gameObject.name];
		this.slider.value = this.hp;

		// ゲームオーバー
		if (this.hp <= 0){

			if (this.screenClearness <= 1.0f) {

				this.hiddenScreenImageUI.transform.SetAsLastSibling();
				this.screenClearness += SpeedScreenFadeout * Time.deltaTime;
				this.hiddenScreenImage.color = new Color(0, 0, 0, screenClearness);
            }
			else if(this.textClearness <= 1.0f) {

				if (this.time == 0) {
					this.battleTempGenerator.isFinishMonster = true;

					foreach (string charaName in this.currentStatusVariables.CurrentCharaHpMap.Keys) {
						if (charaName == this.gameObject.name) continue;
						GameObject chara = GameObject.Find(charaName);
						Destroy(chara);
					}

					foreach (string monsterName in this.currentStatusVariables.CurrentMonsterHpMap.Keys) {
						GameObject monster = GameObject.Find(monsterName);
						Destroy(monster);
					}

					this.canvas.sortingOrder = 5;
				}

				if (this.time < 1.0f) {
					this.time += Time.deltaTime;
					return;
				}

				// ゲームオーバーの文字表示後、クリックしたらタイトルへ遷移
				if(Input.GetMouseButtonDown(0)) this.battleTempGenerator.LoadNextScene(true);

                this.battleTempGenerator.audioSource.Stop();
                this.gameOverTextUI.transform.SetAsLastSibling();
				this.textClearness += SpeedTextFadein * Time.deltaTime;
				this.gameOverText.color = new Color(1, 1, 1, textClearness);
			}
			else {
				// ゲームオーバーの文字表示後、クリックしたらタイトルへ遷移
				if (Input.GetMouseButtonDown(0)) this.battleTempGenerator.LoadNextScene(true);
			}
		}
	}

    /// <summary>
    /// 自分の受けたダメージを表示し、HPを更新する。
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damage(float damage) {

        DisplayDamageUI(damage);

        // 登場キャラマップのHPを更新する。
        this.currentStatusVariables.UpdateCharaHpOfMap(this.gameObject.name, this.hp);
    }

    /// <summary>
    /// 自分の受けたダメージを表示する。
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void DisplayDamageUI(float damage) {
		this.damageUI.GetComponent<damageUIChara>().damage = damage;

		GameObject damageText = Instantiate(this.damageUI) as GameObject;
        damageText.transform.position = new Vector2(
			transform.position.x - 0.3f, transform.position.y + 1.3f);
    }
}