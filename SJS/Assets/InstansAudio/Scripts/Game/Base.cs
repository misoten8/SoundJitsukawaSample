using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    static private GameObject Own;
    void Awake()
    {
        Own = gameObject;
    }

    static public GameObject GetBase()
    {
        return Own;
    }
}
