using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageUIChara : MonoBehaviour {

    Text damageText;

    public float damage;

    //テキストの透明度
    float alpha;

    //フェードアウトするスピード
    float fadeSpeed = 1f;

    //テキストの移動値
    float moveValue = 0.4f;

    // Use this for initialization
    void Start()
    {
        damageText = GetComponentInChildren<Text>();
        damageText.text = damage.ToString();
        alpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //透明にしていく
        alpha -= fadeSpeed * Time.deltaTime;

        //テキストのcolor
        damageText.color = new Color(1, 0, 0, alpha);

        transform.position += Vector3.up * moveValue * Time.deltaTime;

        if (alpha < 0)
        {
            Destroy(gameObject);
        }
    }
}
