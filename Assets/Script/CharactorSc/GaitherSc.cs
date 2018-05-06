using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaitherSc : MonoBehaviour {

	public float hp = 10;
	float moveSpeed = -0.025f;
	
	Fighter1Script fighter1S;
	Witch1Sc witch1S;
	GeneratorScript generatorSc;
	
	bool enemy = false;
	public bool move = true;
	
	GameObject player;
	public GameObject damageUI;
	GameObject generator;
	
	// Use this for initialization
	void Start () {
		generator = GameObject.Find("Generator");
		generatorSc = generator.GetComponent<GeneratorScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if(move)
			transform.Translate(moveSpeed, 0, 0);
		if(hp <= 0){
			generatorSc.Count();
			Destroy(gameObject);
		}
	}
	public void DamageUI(float damage){
		damageUIScript damageUIS = damageUI.GetComponent<damageUIScript>();
		damageUIS.damage = damage;
		GameObject damageText = Instantiate(damageUI) as GameObject;
		damageText.transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.3f);
	}
}
