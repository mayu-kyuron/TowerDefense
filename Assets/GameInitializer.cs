using UnityEngine;

/// <summary>
/// ゲーム初期化クラス
/// スクリーンサイズ（正確には解像度）を指定する。
/// </summary>
public class GameInitializer {

	public const int Width = 1920;
	public const int Height = 1080;
	public const bool IsFullScreen = false;

	[RuntimeInitializeOnLoadMethod]
	static void OnRuntimeMethodLoad() {
		Screen.SetResolution(Width, Height, IsFullScreen);
	}
}