using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

/// <summary>
/// ラインクラス
/// このクラスはライン一つに対するクラス
/// </summary>
//[RequireComponent(typeof(LineRenderer))]
public class Liner : MonoBehaviour
{
	/// <summary>
	/// ラインの描画クラス
	/// </summary>
	[SerializeField]
	private LineDrawer drawer = null;

    /// <summary>
    /// ラインのあたり判定クラス
    /// </summary>
    [SerializeField]
    private LineCollider lineCollider = null;

    /// <summary>
    /// 次の頂点を設置するのに必要な、最後の頂点から選択している点の最小距離
    /// </summary>
    [SerializeField]
    private float interval = 0.0f;

    /// <summary>
    /// ラインが表示される時間
    /// </summary>
    [SerializeField]
    private float activeTime = 0.0f;

    /// <summary>
    /// ラインが有効かどうか
    /// </summary>
    [SerializeField]
    private bool isActiveLine = false;

    /// <summary>
    /// ラインを引くために必要な頂点座標のリスト
    /// </summary>
    private List<Vector3> position = new List<Vector3>();

    /// <summary>
    /// メインカメラのキャッシュ
    /// </summary>
    private Camera mainCamera = null;

	/// <summary>
	/// 使用しているラインの容量
	/// </summary>
	private float usingLineCap = 0.0f;

	void Awake()
	{
		mainCamera = Camera.main;	
	}

	void OnEnable()
    {
		position.Clear();
		drawer.Draw(position.ToArray());
		drawer.ChangeMaterial(LineDrawer.MaterialType.Preparation);
		isActiveLine = false;
	}

    void Update()
    {
		if (isActiveLine) return;

		if (Input.GetMouseButton(0))
        {
            Vector3 pos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y - 1));
			int count = position.Count;
			float length = count == 0 ? interval : Vector3.Distance(pos, position[count - 1]);
            if (length >= interval)
            {
				if(LineManager.Instance.currentLineLenght < LineManager.Instance.limitLineLength)
				{
					LineManager.Instance.currentLineLenght += length;
					usingLineCap += length;
					position.Add(pos);
					drawer.Draw(position.ToArray());
					if (LineManager.Instance.currentLineLenght > LineManager.Instance.limitLineLength)
					{
						drawer.ChangeMaterial(LineDrawer.MaterialType.Max);
					}
					else
					{
						drawer.ChangeMaterial(LineDrawer.MaterialType.Preparation);
					}
				}
			}
        }
		
		if (Input.GetMouseButtonUp(0))
        {
            // あたり判定有効化
            lineCollider.enabled = true;
            lineCollider.BeginHitCheak(position.ToArray());
            isActiveLine = true;
            position.Clear();
			drawer.ChangeMaterial(LineDrawer.MaterialType.Attack);
			Observable.Timer(TimeSpan.FromSeconds(activeTime)).Subscribe(_ => LineDelete());
		}
    }

	void LineDelete()
	{
		LineManager.Instance.currentLineLenght = Mathf.Max(LineManager.Instance.currentLineLenght - usingLineCap, 0.0f);
		isActiveLine = false;
		lineCollider.enabled = false;
		drawer.Clear();
		gameObject.SetActive(false);
	}
}
