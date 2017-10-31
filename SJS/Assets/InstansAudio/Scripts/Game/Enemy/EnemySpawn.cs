using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Enemy = null;
    [SerializeField]
    private int interval = 0;
    [SerializeField]
    private int CreatMax = 0;
    [SerializeField]
    private float inSide;
    [SerializeField]
    private float outSide;

    private float timer = 0;
    private float splitAngle = Mathf.PI / 32;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= interval)
        {
            timer = 0;
            for(int count = 0; count < CreatMax; count++)
            {
                float radius = Random.Range(inSide, outSide);
                float angle = splitAngle * Random.Range(0, 64);
                Instantiate(Enemy[Random.Range(0, Enemy.Count)], new Vector3(Mathf.Sin(angle) * radius, transform.position.y, Mathf.Cos(angle) * radius), Quaternion.identity);
            }
        }

        timer += Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(new Vector3(0, 0 ,0), inSide);
        Gizmos.color = new Color(1, 0.92f, 0.016f, 0.5f);
        Gizmos.DrawSphere(new Vector3(0, 0, 0), outSide);
    }
}
