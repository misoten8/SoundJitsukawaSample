using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> target;
    [SerializeField]
    private List<GameObject> Object;
    [SerializeField]
    private float interval;
    [SerializeField]
    private float radius;
    [SerializeField]
    private int split;
    private float time;
    private float angle;

    // Use this for initialization
    void Start()
    {
        time = 0.0f;
        angle = (Mathf.PI * 2) / split;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= interval)
        {
            time = 0.0f;
            GameObject obj = EnemyManager.Instance.Creat(Object[Random.Range(0, Object.Count)], new Vector3(Mathf.Sin(angle * Random.Range(0, split)) * radius, transform.position.y, Mathf.Cos(angle * Random.Range(0, split)) * radius));
        }

        time += Time.deltaTime;
    }
}
