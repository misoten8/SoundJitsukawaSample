using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCollider : MonoBehaviour
{
	Vector3[] linePositions = null;

	void Update()
	{
		HitCheak();
	}

	public void BeginHitCheak(Vector3[] targetLinePositions)
	{
		linePositions = targetLinePositions;
	}


	private void HitCheak()
    {
        for(int i = 1; i < linePositions.Length; i++)
        {
			Vector3 
				prev = linePositions[i - 1],
				now = linePositions[i],
				origin = prev,
				direction = (prev - now).normalized;
			float distance = Vector3.Distance(prev, now);
			var targets = Physics.RaycastAll(origin, direction, distance);

			foreach(RaycastHit rayCastHit in targets)
			{
                GameObject target = rayCastHit.transform.gameObject;
                if (target.tag != "Enemy") continue;
                AudioManager.PlaySE("button");
				target.SetActive(false);
			}
        }
    }
}
