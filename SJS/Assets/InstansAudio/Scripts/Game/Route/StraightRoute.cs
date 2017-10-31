using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightRoute : Route
{
    private float angle = 0.0f;

    void OnEnable()
    {
        angle = Mathf.Atan2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);
    }

    void OnDisable()
    {
        angle = 0.0f;
    }

    void Update()
    {
        transform.position += new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle)) * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            AudioManager.PlaySE("button");
            gameObject.SetActive(false);
        }
    }
}
