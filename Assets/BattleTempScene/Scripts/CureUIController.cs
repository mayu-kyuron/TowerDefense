using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 回復ポイント表示UIのコントローラー
/// </summary>
public class CureUIController : MonoBehaviour {
	
	private const float SpeedToFadeout = 1.3f;
	private const float ValueToMove = 0.4f;

	[HideInInspector]
	public float cure = 0;

	private Text cureText;
	private float clearness;
	
	// Use this for initialization
	void Start () {
		cureText = GetComponentInChildren<Text>();
		cureText.text = cure.ToString();
		clearness = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

		//透明にしていく
		clearness -= SpeedToFadeout * Time.deltaTime;
		cureText.color = new Color(0, 1, 1, clearness);
		
		// UIの場所を変えていく
		this.transform.position += Vector3.up * ValueToMove * Time.deltaTime;
		
		if(clearness < 0) Destroy(gameObject);
	}
}