using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// シーン間で変数を引き継ぐための定義クラス
public class GlobalObject : MonoBehaviour {

    private static GlobalObject sharedInstance = null;
    private string mStringParam = null;
    private object mParam = null;
    private object[] mParams = null;

    public string StringParam
    {
        get { return mStringParam; }
    }
    
    public void SetStringParam(string mStringParam)
    {
        this.mStringParam = mStringParam;
    }

    public object Param
    {
        get { return mParam; }
    }

    public void SetParam(object mParam)
    {
        this.mParam = mParam;
    }

    public object[] Params
    {
        get { return mParams; }
    }

    public void SetParams(object[] mParams)
    {
        this.mParams = mParams;
    }

    public static GlobalObject getInstance()
    {
        return sharedInstance;
    }

    public static void LoadLevelWithString(string levelName, string stringParam)
    {
        getInstance().mStringParam = stringParam;
        SceneManager.LoadScene(levelName);
    }

    public static void LoadLevelWithObject(string levelName, object theParam)
    {
        getInstance().mParam = theParam;
        SceneManager.LoadScene(levelName);
    }

    public static void LoadLevelWithParams(string levelName, params object[] theParams)
    {
        getInstance().mParams = theParams;
        SceneManager.LoadScene(levelName);
    }

    public void Awake()
    {
        if (sharedInstance == null)
        {
            Debug.Log("Awake GlobalObject");

            sharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        Debug.Log("StringParam = " + getInstance().StringParam);
    }
}
