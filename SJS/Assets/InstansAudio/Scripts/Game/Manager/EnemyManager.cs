using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
{
    [SerializeField]
    private List<GameObject> EnemyType;
    private List<List<GameObject>> PoolEnemyList = new List<List<GameObject>>();

    private void Start()
    {
        for (int i = 0; i++ < EnemyType.Count; PoolEnemyList.Add(new List<GameObject>())) ;
    }
    
    public GameObject Creat(GameObject enemy, Vector3 pos)
    {
        for (int count = 0; count < EnemyType.Count; count++ )
        {
            if (EnemyType[count] != enemy) continue;

            foreach (GameObject _obj in PoolEnemyList[count])
            {
                if(_obj.activeSelf == false)
                {
                    _obj.transform.position = pos;
                    _obj.SetActive(true);
                    return _obj;
                }
            }

            GameObject _enemy = Instantiate(enemy, pos, Quaternion.identity);
            PoolEnemyList[count].Add(_enemy);
            return _enemy;
        }

        return null;
    }
}
