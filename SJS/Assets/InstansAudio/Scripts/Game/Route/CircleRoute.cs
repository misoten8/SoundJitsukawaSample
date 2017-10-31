using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRoute : Route
{
    [SerializeField]
    private float reducedSpeed = 0.0f;
    private float length = 0.0f;
    private float angle = 0.0f;

    void OnEnable()
    {
        length = Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.z), new Vector2(transform.position.x, transform.position.z));
        angle = Mathf.Atan2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);
    }

    void OnDisable()
    {
        angle = 0.0f;
        length = 0.0f;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle)) * length;
        length -= reducedSpeed;
        angle += speed / ((Mathf.PI * 2) * length);
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
