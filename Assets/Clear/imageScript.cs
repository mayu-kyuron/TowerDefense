using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageScript : MonoBehaviour {

    public GameObject canvasPre;
    public GameObject imagePre;

	// Use this for initialization
	void Start () {
        GameObject image = Instantiate(imagePre) as GameObject;
        image.transform.SetParent(canvasPre.transform, false);
        image.transform.position = new Vector2(-6.5f, 2.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
