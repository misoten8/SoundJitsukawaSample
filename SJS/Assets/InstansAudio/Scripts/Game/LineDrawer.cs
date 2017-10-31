using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {

	public enum MaterialType
	{
		Preparation,
		Max,
		Attack
	}

	/// <summary>
	/// ラインの描画クラス
	/// </summary>
	[SerializeField]
	private LineRenderer lineRenderer = null;

	[SerializeField]
	private Color[] matArray;

	public void Draw (Vector3[] vertexArray)
	{
		lineRenderer.positionCount = vertexArray.Length;
		lineRenderer.SetPositions(vertexArray);
	}
	
	public void Clear()
	{
		lineRenderer.positionCount = 0;
	}

	public void ChangeMaterial(MaterialType type)
	{
		lineRenderer.material.color = matArray[(int)type];
	}
}
