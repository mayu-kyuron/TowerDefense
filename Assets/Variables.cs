using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

    // キャラボタン選択の判断用変数
    // 1:ファイター、2:ウィッチ、3:ヒーラー、4:ガーディアン、5:サポーター、6:モンスター
    private int judgeCharaTypeNum;

    // ページ番号
    private int judgeCharaPageNum;

    /// <summary>
    /// キャラボタン選択の判断用変数を取得する。
    /// </summary>
    public int JudgeCharaTypeNum
    {
        get { return this.judgeCharaTypeNum; }
    }

    /// <summary>
    /// キャラボタン選択の判断用変数を設定する。
    /// </summary>
    /// <param name="judgeCharaTypeNum"></param>
    public void SetJudgeCharaTypeNum(int judgeCharaTypeNum)
    {
        this.judgeCharaTypeNum = judgeCharaTypeNum;
    }

    /// <summary>
    /// ページ番号を取得する。
    /// </summary>
    public int JudgeCharaPageNum
    {
        get { return this.judgeCharaPageNum; }
    }

    /// <summary>
    /// ページ番号を設定する。
    /// </summary>
    /// <param name="judgeCharaPageNum"></param>
    public void SetJudgeCharaPageNum(int judgeCharaPageNum)
    {
        this.judgeCharaPageNum = judgeCharaPageNum;
    }
}
