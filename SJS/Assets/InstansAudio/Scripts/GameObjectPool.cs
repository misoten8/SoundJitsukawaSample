using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// ゲームオブジェクトプール
/// 製作者：実川
/// </summary>
public class GameObjectPool
{
	/// <summary>
	/// 活動しているゲームオブジェクトのプール
	/// </summary>
	private List<GameObject> playPool = new List<GameObject>();

	/// <summary>
	/// 活動していないゲームオブジェクトのプール
	/// </summary>
	private List<GameObject> stopPool = new List<GameObject>();

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="size">プールサイズ</param>
	public GameObjectPool(GameObject prefab, uint size)
	{
		for (int i = 0; i < size; i++)
		{
			GameObject gameObject = Object.Instantiate(prefab);
			gameObject.SetActive(false);
			stopPool.Add(gameObject);
		}
	}

	/// <summary>
	/// 使用されていないゲームオブジェクトを渡す
	/// </summary>
	public GameObject Get()
	{
		if (stopPool.Count == 0)
		{
			Restore();
		}
		GameObject value = stopPool.First();
		value.SetActive(true);
		playPool.Add(value);
		stopPool.RemoveAt(0);
		return value;
	}

	/// <summary>
	/// 使用されていないゲームオブジェクトのプールを復元する
	/// </summary>
	private void Restore()
	{
		stopPool = new List<GameObject>();
		stopPool = playPool.Where(x => x.activeSelf == false).ToList();
		playPool = playPool.Where(x => x.activeSelf == true).ToList();
	}
}
