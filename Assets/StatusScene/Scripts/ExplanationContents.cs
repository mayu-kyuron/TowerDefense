using UnityEngine;

/// <summary>
/// キャラ説明内容
/// </summary>
public class ExplanationContents : MonoBehaviour {

	public const string FighterAName = "サキ";
	public const string FighterBName = "ユノ";
	public const string FighterCName = "リリー";
	public const string WitchAName = "アナ";
	public const string WitchBName = "ローズ";
	public const string HealerAName = "カノン";
	public const string HealerCName = "オリヴィア";
	public const string SupporterAName = "ライラ";
	public const string SupporterBName = "ケイト";

	public const string FighterAExp =
		FighterAName + "\n" +
		"\n" +
		"魔物たちを地球から一掃するため\n" +
		"旅をする女剣士。\n" +
		"\n" +
		"何に対しても物怖じすることなく、\n" +
		"いつも堂々とした立ち居振る舞い。\n" +
		"みんなのリーダー的な存在。";

    public const string FighterBExp =
		FighterBName + "\n" +
		"\n" +
		"強いヒトと戦うことが生きがいの\n" +
		"戦闘マニア。\n" +
		"\n" +
		HealerAName + "と2人で魔物退治の\n" +
		"旅をしていた。\n" +
		"好奇心旺盛で、恐いもの知らず。";

    public const string FighterCExp =
		FighterCName + "\n" +
		"\n" +
		"幼くして" + WitchBName + "を厚く師事する\n" +
		"村出身の少女。\n" +
		"\n" +
		WitchBName + "を先生と慕い、彼女に\n" +
		"仇なすとみたものには容赦がない。\n" +
		"人形を操れたりと、潜在魔力が高い。";

	public const string WitchAExp =
		WitchAName + "\n" +
		"\n" +
		FighterAName + "とともに旅をする魔法使い。\n" +
		"\n" +
		"明るく天真爛漫なムードメーカー。\n" +
		"少し甘えたなところも。\n" +
		FighterAName + "を誰よりも信頼している。";

    public const string WitchBExp =
		WitchBName + "\n" +
		"\n" +
		"人助けをしつつ各地を放浪していた\n" +
		"高名な魔法使い。\n" +
		"\n" +
		"古めかしい話し方や飄々とした態度など\n" +
		"癖はあるが、意外にも常識的な人物。\n" +
		FighterCName + "に先生と慕われている。";

	public const string HealerAExp =
		HealerAName + "\n" +
		"\n" +
		"魔物の襲来後に一念発起して旅に出た\n" +
		"治癒術師。\n" +
		"\n" +
		"一見すると気弱だが、しっかりとした\n" +
		"意志と行動力をもつ。\n" +
		"純粋で、やや仲間に振り回されがち。";

  //  public const string HealerBExp =
		//FighterCName + "\n" +
		//"\n" +
		//"幼くして" + WitchBName + "を厚く師事する\n" +
		//"村出身の少女。\n" +
		//"\n" +
		//WitchBName + "を先生と慕い、彼女に\n" +
		//"仇なすとみたものには容赦がない。\n" +
		//"人形を操れたりと、潜在魔力が高い。";

    public const string HealerCExp =
		HealerCName + "\n" +
		"\n" +
		"魔界で穏やかに暮らすエルフ族の1人。\n" +
		"\n" +
		"魔界に住み着いた余所者の侵略により、\n" +
		"人間界で戦うことを余儀なくされた。\n" +
		"誰に対しても丁寧で、物腰穏やか。";

    //public const string GuardianAExp = "ガーディアンAの説明";

    //public const string GuardianBExp = "ガーディアンBの説明";

    public const string SupporterAExp =
		SupporterAName + "\n" +
		"\n" +
		FighterAName + "とともに旅をする踊り子。\n" +
		"\n" +
		"彼女の闘いの舞は、仲間の闘争心と\n" +
		"攻撃力を高める効果がある。\n" +
		FighterAName + "とは前からつきあいがある。";

    public const string SupporterBExp =
		SupporterBName + "\n" +
		"\n" +
		"各地に赴き世情を探る過程で\n" +
		"旅に加わった研究者。\n" +
		"\n" +
		"自ら開発した杖は、ヒトの基礎体力の\n" +
		"底上げを可能にする。\n" +
		"冷静な判断力の持ち主。";

    //public const string MonsterAExp = "モンスターAの説明";
}