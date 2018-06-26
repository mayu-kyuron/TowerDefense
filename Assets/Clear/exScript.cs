using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exScript : MonoBehaviour {

    Slider ex;

	// Use this for initialization
	void Start () {
        ex = GameObject.Find("ex").GetComponent<Slider>();
	}

    float exGetPoint = 50;
    float exPoint = 0;
    float exFirstPoint = 0;
    float exMax = 100;
	// Update is called once per frame
	void Update () {
        if((exPoint - exFirstPoint)<= exGetPoint)
            exPoint += 0.01f;
        if(exPoint > exMax)
        {
            exPoint = 0;
        }
        ex.value = exPoint;
	}
}
