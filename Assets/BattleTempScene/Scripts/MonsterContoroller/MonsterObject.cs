using UnityEngine;

/// <summary>
/// モンスターオブジェクト生成用クラス
/// </summary>
public class MonsterObject : MonoBehaviour {

	public MonsterObject(GameObject prefab, string objectName) {
		this.prefab = prefab;
		this.objectName = objectName;
	}

	/// <summary>
	/// プレファブ
	/// </summary>
	public GameObject prefab;

	/// <summary>
	/// オブジェクト名
	/// </summary>
	public string objectName;
}