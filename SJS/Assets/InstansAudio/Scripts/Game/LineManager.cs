using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ラインを管理するクラス
/// 製作者：実川
/// </summary>
public class LineManager : SingletonMonoBehaviour<LineManager>
{
	/// <summary>
	/// ラインのプレハブ
	/// </summary>
	[SerializeField]
	private Liner linePrefab = null;

	/// <summary>
	/// 生成する数
	/// </summary>
	[SerializeField]
	private uint instanceNum = 10;

	/// <summary>
	/// 一度に引けるラインの長さ
	/// </summary>
	//[SerializeField]
	public float limitLineLength
	{
		get { return _limitLineLength; }
		private set { _limitLineLength = value; }
	}
	[SerializeField]
	private float _limitLineLength;

	/// <summary>
	/// 現在のラインの長さ
	/// </summary>
	public float currentLineLenght
	{
		get { return _currentLineLenght; }
		set { _currentLineLenght = value; }
	}
	private float _currentLineLenght = 0.0f;

	/// <summary>
	/// ラインのオブジェクトプール
	/// </summary>
	private GameObjectPool liners = null;

	void Start()
	{
		Debug.Log("呼ばれたぜ！Line");
		AudioManager.PlayBGM("千本桜");
		liners = new GameObjectPool(linePrefab.gameObject, instanceNum);
		currentLineLenght = 0.0f;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			liners.Get();
		}
	}
}
