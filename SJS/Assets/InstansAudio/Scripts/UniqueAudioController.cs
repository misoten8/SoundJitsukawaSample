using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オーディオ操作クラス
/// このクラスは一つのオーディオにしか対応していません。
/// 製作者：実川
/// </summary>
public class UniqueAudioController : SingletonMonoBehaviour<UniqueAudioController>
{

	[SerializeField]
	private AudioSource m_audioSource;

    public static AudioSource Audio
    {
        get { return Instance.m_audioSource; }
    }

	/// <summary>
	/// オーディオの再生中断
	/// </summary>
	public static void Pause()
	{
		if (Instance == null) return;
		Instance.m_audioSource.Pause();
	}

	/// <summary>
	/// オーディオの再生続行
	/// </summary>
	public static void Continue()
	{
		if (Instance == null) return;
		if (Instance.m_audioSource.isPlaying) return;
        Instance.m_audioSource.Play();
	}

	/// <summary>
	/// オーディオを最初から再生
	/// </summary>
	public static void RePlay()
	{
		if (Instance == null) return;
        Instance.m_audioSource.Stop();
        Instance.m_audioSource.Play();
	}

	/// <summary>
	/// オーディオの音量を調整する
	/// </summary>
	/// <param name="volume">音量</param>
	public static void SetVolume(float volume)
	{
		if (Instance == null) return;
        Instance.m_audioSource.volume = volume;
	}
}
