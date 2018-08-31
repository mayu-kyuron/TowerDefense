using UnityEngine;

/// <summary>
/// ジョーカースクリプト用ゲーム初期化クラス
/// スクリーンサイズ（正確には解像度）を指定する。
/// </summary>
public class GameInitializerForJoker {

	[RuntimeInitializeOnLoadMethod]
	static void OnRuntimeMethodLoad() {
		Screen.SetResolution(GameInitializer.Width, GameInitializer.Height, GameInitializer.IsFullScreen);
	}
}