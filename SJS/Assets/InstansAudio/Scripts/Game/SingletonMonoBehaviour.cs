using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// このクラスを使用する場合、継承先のクラスはAwakeを使用してはいけない
/// 派生先の方が先に呼ばれるため
/// </summary>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
	public static T Instance
	{
		get
		{	
			return instance;
		}
		private set
		{
			instance = value;
		}
	}
	protected static T instance = null;

    void Awake()
    {
        if (instance == null)
        {
			instance = (T)this;
			Debug.Log("呼ばれたぜ！" + instance.ToString());
			DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}