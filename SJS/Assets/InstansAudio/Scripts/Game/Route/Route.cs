using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    //protected float ratio;
    protected GameObject target;

    void Awake()
    {
        target = Base.GetBase();
    }

    //public float Ratio
    //{
    //    get
    //    {
    //        return ratio;
    //    }
    //}
}
