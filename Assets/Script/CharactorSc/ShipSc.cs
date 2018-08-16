using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSc : MonoBehaviour {

    protected CurrentStatusVariables currentStatusVariables;
    public float hp = 150f;
    private string Name;
	public GameObject damageUI;
	Slider slider;

    private Dictionary<string, float> currentCharaHpMap = new Dictionary<string, float>();

    // Use this for initialization
    void Start () {
		slider = GameObject.Find("HPgage").GetComponent<Slider>();
        this.Name = this.gameObject.name;
        this.currentStatusVariables = GameObject.Find("CurrentStatusVariables").GetComponent<CurrentStatusVariables>();
        this.currentStatusVariables.AddCharaHpToMap(this.Name, this.hp);
    }
	
	// Update is called once per frame
	void Update () {

        this.currentCharaHpMap = this.currentStatusVariables.CurrentCharaHpMap;
        this.hp = this.currentCharaHpMap[this.Name];
        slider.value = hp;

        if (hp <= 0){
			SceneManager.LoadScene("GameOver");
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
	}
	
	public void Damage(float damage){

        DisplayDamageUI(damage);
        
        // 登場キャラマップのHPを更新する。
        this.currentStatusVariables.UpdateCharaHpOfMap(this.Name, this.hp);
    }

    public void DisplayDamageUI(float damage)
    {
        damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
        damageUIS.damage = damage;
        GameObject damageText = Instantiate(damageUI) as GameObject;
        damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
    }
}
